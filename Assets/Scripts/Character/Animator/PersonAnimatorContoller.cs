 
using UnityEngine;

public class PersonAnimatorContoller : MonoBehaviour
{
    public Animator person; 
   
    public void PersonAimBowAnimator(bool isPressed) //call in InputContoller
    {   
        if (isPressed)
            person.SetBool("isAim", true);
        else person.SetBool("isAim", false);
    }
    public void PersonEquipBowAmimator(bool isKeyDown) //call in InputContoller 
    {
        if(isKeyDown)
            person.SetBool("isReady", true);
        else person.SetBool("isReady", false); 
    }
    public void RunningPersonAnimator(Vector3 m_Input, bool isRunning) //call in MovePerson
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
    public void JumpingPersonAnimator(bool isJump, bool isTerra) //call in MovePerson  
    {   
        if (isJump && isTerra)
            person.SetBool("isJumping", true);
        else
            person.SetBool("isJumping", false);
    }
    public void TurnWithBowPersonAnimator(float slowMouseX) //call in InputContoller 
    {
        person.SetFloat("MouseX", slowMouseX);
    }
}
