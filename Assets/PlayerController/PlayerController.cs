
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
         
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // получаем текущее направление движения 
        Vector3 directionMove = (m_Input.z * directionVertical) + (m_Input.x * directionHorizontal);// приводим напрвление к направлению камеры
        
        if (directionMove.sqrMagnitude >= 0.2f)
            transform.rotation = Quaternion.LookRotation(directionMove); //поворачиваем персонажа в сторону камеры

        MovePerson(directionMove); // включаем движение персонажа по направлению камеры
        PlayPersonAnim(m_Input); // включаем анимацию персонажа с помошью полученых осей
    }
    private void MovePerson(Vector3 directionMove)
    {
        isRunning = Input.GetKey(KeyCode.LeftShift); // считываем нажатие кнопки Shift
        float moveSpeed = currentSpeed * (isRunning ? 1 : 0.4f); // без shift -> уменьшаем текущую скорость движения 
        
        rb_Person.MovePosition(rb_Person.position + directionMove * moveSpeed * Time.deltaTime); // включаем движение персон по осям
        
    }
    private void PlayPersonAnim(Vector3 m_Input)
    {
        float animationSpeed = isRunning ? 1 : 0.6f; // без shift -> уменьшаем текущую скорость анимации
        if (m_Input.sqrMagnitude > 0) // получаем значение в магнитуде чтобы проверить скорость от 0 и до 1
        {
            anim_Person.SetFloat("velocityX", m_Input.x * animationSpeed, 0.1f, Time.deltaTime); // вкл Аним и указываем плавность 0,1 и время
            anim_Person.SetFloat("velocityY", m_Input.z * animationSpeed, 0.1f, Time.deltaTime); // вкл Аним и указываем плавность 0,1 и время
        }
        else
        {
            anim_Person.SetFloat("velocityX", 0, 0.1f, Time.deltaTime); // откл Аним и указываем плавность 0,1 и время
            anim_Person.SetFloat("velocityY", 0, 0.1f, Time.deltaTime); // откл Аним и указываем плавность 0,1 и время
        }
    }
    private void Jumping()
    {
        bool isJump = Input.GetKeyDown(KeyCode.Space);
        if (isTerra & isJump) // проверяем что нажата кнока Space и что земля
        {
            anim_Person.SetBool("isJumping", true); // вкл Аним прыж
            rb_Person.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // применяем силу в верх
            isTerra = false; // после прыжка сбрасываем переменную
        }
        else anim_Person.SetBool("isJumping", false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terra") // если земля то можно прыгать
            isTerra = true;
    }

}
