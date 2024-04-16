
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public Transform cameraPerson;
    public Animator anim_Person;
    public Rigidbody rb_Person; 

    public float currentSpeed = 10f;
    public float jumpForce = 5f;
       
    private bool isTerra = false;
    private bool isRunning = false;

    private void Update()
    {
        CalculateDirectionMove();
        Jumping();
    }
    private void CalculateDirectionMove()
    {   
        Vector3 directionVertical = cameraPerson.forward;
        Vector3 directionHorizontal = cameraPerson.right;
        directionVertical.y = 0;
        directionHorizontal.y = 0;
         
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // �������� ������� ����������� �������� 
        Vector3 directionMove = (m_Input.z * directionVertical) + (m_Input.x * directionHorizontal);// �������� ���������� � ����������� ������
        
        if (directionMove.sqrMagnitude >= 0.2f)
            transform.rotation = Quaternion.LookRotation(directionMove); //������������ ��������� � ������� ������

        MovePerson(directionMove); // �������� �������� ��������� �� ����������� ������
        PlayPersonAnim(m_Input); // �������� �������� ��������� � ������� ��������� ����
    }
    private void MovePerson(Vector3 directionMove)
    {
        isRunning = Input.GetKey(KeyCode.LeftShift); // ��������� ������� ������ Shift
        float moveSpeed = currentSpeed * (isRunning ? 1 : 0.4f); // ��� shift -> ��������� ������� �������� �������� 
        
        rb_Person.MovePosition(rb_Person.position + directionMove * moveSpeed * Time.deltaTime); // �������� �������� ������ �� ����
        
    }
    private void PlayPersonAnim(Vector3 m_Input)
    {
        float animationSpeed = isRunning ? 1 : 0.6f; // ��� shift -> ��������� ������� �������� ��������
        if (m_Input.sqrMagnitude > 0) // �������� �������� � ��������� ����� ��������� �������� �� 0 � �� 1
        {
            anim_Person.SetFloat("velocityX", m_Input.x * animationSpeed, 0.1f, Time.deltaTime); // ��� ���� � ��������� ��������� 0,1 � �����
            anim_Person.SetFloat("velocityY", m_Input.z * animationSpeed, 0.1f, Time.deltaTime); // ��� ���� � ��������� ��������� 0,1 � �����
        }
        else
        {
            anim_Person.SetFloat("velocityX", 0, 0.1f, Time.deltaTime); // ���� ���� � ��������� ��������� 0,1 � �����
            anim_Person.SetFloat("velocityY", 0, 0.1f, Time.deltaTime); // ���� ���� � ��������� ��������� 0,1 � �����
        }
    }
    private void Jumping()
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);
        if (isTerra & isJump) // ��������� ��� ������ ����� Space � ��� �����
        {
            anim_Person.SetBool("isJumping", true); // ��� ���� ����
            rb_Person.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // ��������� ���� � ����
            isTerra = false; // ����� ������ ���������� ����������
        }
        else anim_Person.SetBool("isJumping", false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terra") // ���� ����� �� ����� �������
            isTerra = true;
    }

}
