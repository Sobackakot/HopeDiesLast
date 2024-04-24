
using UnityEngine;

public class BowArrowState : MonoBehaviour
{
    [SerializeField] private GameObject bowHand;
    [SerializeField] private GameObject bowBack;
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform cameraPerson;
    private bool _isKeyDown = false;
    public void ArrowActive(bool isPressed)//call in InputContoller Aim
    { 
        if(isPressed && _isKeyDown)
            arrow.SetActive(true);
        else arrow.SetActive(false);
    }
    public void BowActive(bool isKeyDown) //call in InputContoller Equip
    {
        _isKeyDown = isKeyDown;
        if (isKeyDown)
        {
            bowHand.SetActive(true);
            bowBack.SetActive(false);
        }
        else
        {
            bowHand.SetActive(false);
            bowBack.SetActive(true);
        }
    }
    public void BowAim(bool isPressed) //call in InputContoller Equip
    {
        if (isPressed)
        {
            Quaternion direction = Quaternion.LookRotation(cameraPerson.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, direction, 10 * Time.deltaTime);
        }
    }
}
