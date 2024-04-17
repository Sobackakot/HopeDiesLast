 
using UnityEngine;
using UnityEngine.Events;

public class InputContoller : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onAimBowPersonAnimator;
    [SerializeField] private UnityEvent<bool> onEquipBowPersonAnimator;
    [SerializeField] private UnityEvent<float> onTurnBowPersonAnimator;

    private bool isKeyDown = false;
    private bool isPressedMouseButton = false;
    private float slowMouseX = 0f;  

    private void Update()
    {
        EquipBowPerson();
        AimBowPerson();
        TurnWithBowPerson();
    }
    private void EquipBowPerson()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isKeyDown = !isKeyDown;
            onEquipBowPersonAnimator.Invoke(isKeyDown);
        }
    }
    private void AimBowPerson()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressedMouseButton = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPressedMouseButton = false;
        }
        onAimBowPersonAnimator.Invoke(isPressedMouseButton);
    }
    private void TurnWithBowPerson()
    {
        float mouseX = Input.GetAxis("Mouse X");
        slowMouseX = Mathf.Lerp(slowMouseX, mouseX, 10 * Time.deltaTime);
        onTurnBowPersonAnimator.Invoke(slowMouseX);
    }
}
