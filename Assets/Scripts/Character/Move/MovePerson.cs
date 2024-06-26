
using UnityEngine;
using UnityEngine.Events;

public class MovePerson : MonoBehaviour
{
    public UnityEvent<bool, bool> onJumpAnimator;
    public UnityEvent<Vector3, bool> onMoveAnimator;


    public Transform cameraPerson; 
    public Rigidbody rb_Person;

    private Vector3 newDirectionMove;

    public float currentSpeed = 10f;
    public float jumpForce = 5f;
       
    private bool isTerra = false;
    private bool _isRunning = false; 

    public void CalculateDirectionMove(Vector3 InputAxis) //call in InputContoller 
    {   
        Vector3 directionVertical = cameraPerson.forward; // �������� ������ ����������� ������
        Vector3 directionHorizontal = cameraPerson.right;
        directionVertical.y = 0; // ���������� ��������� �� ������������ ��� 
        directionHorizontal.y = 0; 
        newDirectionMove = (InputAxis.z * directionVertical) + (InputAxis.x * directionHorizontal);// �������� ���������� � ����������� ������

        if (newDirectionMove.sqrMagnitude >= 0.2f)//������������ ��������� � ������� ������ 
        {
            Quaternion targetRotation = Quaternion.LookRotation(newDirectionMove, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
        onMoveAnimator.Invoke(InputAxis, _isRunning);
    }

    public void Running(bool isRunning) //call in InputContoller 
    {
        _isRunning = isRunning;
        float moveSpeed = currentSpeed * (_isRunning ? 1 : 0.4f); 
        rb_Person.MovePosition(rb_Person.position + newDirectionMove * moveSpeed * Time.deltaTime); 
    }

    public void Jumping(bool isJump) //call in InputContoller 
    { 
        onJumpAnimator.Invoke(isJump, isTerra); 
        if (isTerra & isJump) 
        { 
            rb_Person.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isTerra = false; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terra") 
            isTerra = true;
    }

}
