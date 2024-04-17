
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


    private void Update()
    {
        CalculateDirectionMove();
    }

    private void CalculateDirectionMove()
    {   
        Vector3 directionVertical = cameraPerson.forward; // получаем текуще направление камеры
        Vector3 directionHorizontal = cameraPerson.right;
        directionVertical.y = 0; // сбрасываем трансформ по вертикальной оси 
        directionHorizontal.y = 0;
         
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // получаем текущее направление движения 
        newDirectionMove = (m_Input.z * directionVertical) + (m_Input.x * directionHorizontal);// приводим напрвление к направлению камеры
        
        if (newDirectionMove.sqrMagnitude >= 0.2f)
            transform.rotation = Quaternion.LookRotation(newDirectionMove, Vector3.up); //поворачиваем персонажа в сторону камеры
         
        onMoveAnimator.Invoke(m_Input, _isRunning);
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
