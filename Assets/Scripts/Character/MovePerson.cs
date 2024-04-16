
using UnityEngine;
using UnityEngine.Events;

public class MovePerson : MonoBehaviour
{
    public UnityEvent<bool, bool> onJumpAnimator;
    public UnityEvent<Vector3, bool> onMoveAnimator;


    public Transform cameraPerson; 
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
        Vector3 directionVertical = cameraPerson.forward; // получаем текуще направление камеры
        Vector3 directionHorizontal = cameraPerson.right;
        directionVertical.y = 0; // сбрасываем трансформ по вертикальной оси 
        directionHorizontal.y = 0;
         
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // получаем текущее направление движения 
        Vector3 directionMove = (m_Input.z * directionVertical) + (m_Input.x * directionHorizontal);// приводим напрвление к направлению камеры
        
        if (directionMove.sqrMagnitude >= 0.2f)
            transform.rotation = Quaternion.LookRotation(directionMove); //поворачиваем персонажа в сторону камеры

        MovingPerson(directionMove); 
        onMoveAnimator.Invoke(m_Input, isRunning);
    }

    private void MovingPerson(Vector3 directionMove)
    {
        isRunning = Input.GetKey(KeyCode.LeftShift); 
        float moveSpeed = currentSpeed * (isRunning ? 1 : 0.4f); 
        rb_Person.MovePosition(rb_Person.position + directionMove * moveSpeed * Time.deltaTime); 
    }

    private void Jumping()
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);
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
