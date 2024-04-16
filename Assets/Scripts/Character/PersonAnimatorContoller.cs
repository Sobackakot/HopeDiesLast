 
using UnityEngine;
using UnityEngine.Events;

public class PersonAnimatorContoller : MonoBehaviour
{
    public Animator person; 
   
    public void PersonAimBow(bool isPressed)
    {   
        if (isPressed)
            person.SetBool("isAim", true);
        if(!isPressed)
            person.SetBool("isAim", false);
    }
    public void EquipBow(bool isKeyDown)
    {
        if(isKeyDown)
            person.SetBool("isReady", true);
        if(!isKeyDown)
            person.SetBool("isReady", false);
    }
    public void Moving(Vector3 m_Input, bool isRunning)
    { 
        float animationSpeed = isRunning ? 1 : 0.6f; 
        if (m_Input.sqrMagnitude > 0) 
        {
            person.SetFloat("velocityX", m_Input.x * animationSpeed, 0.1f, Time.deltaTime); 
            person.SetFloat("velocityY", m_Input.z * animationSpeed, 0.1f, Time.deltaTime); 
        }
        else
        {
            person.SetFloat("velocityX", 0, 0.1f, Time.deltaTime); 
            person.SetFloat("velocityY", 0, 0.1f, Time.deltaTime); 
        }
    }
    public void Jumping(bool isJump, bool isTerra)
    {   
        if (isJump && isTerra)
            person.SetBool("isJumping", true);
        else
            person.SetBool("isJumping", false);
    }
}
