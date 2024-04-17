 
using UnityEngine;
using UnityEngine.Events;

public class InputContoller : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onAimBowPersonAnimator;
    [SerializeField] private UnityEvent<bool> onEquipBowPersonAnimator;
    [SerializeField] private UnityEvent<float> onTurnBowPersonAnimator;
    [SerializeField] private UnityEvent<bool> onJumpPerson;
    [SerializeField] private UnityEvent<bool> onRunPerson;
    [SerializeField] private UnityEvent<Vector3> onAxisDirectionMove;

    private bool isKeyDown = false;
    private bool isPressedMouseButton = false;
    private float slowMouseX = 0f;  

    private void Update()
    {
        InputKeyEquipBowPerson();
        LeftMouseAimWithBowPerson();
        InputMouseXTurnWithBowPerson();
        InputKeyJumpPerson();
        InputKeyRunnigPerson();
        InputAxisDirectionMove();
    }
    private void InputKeyEquipBowPerson()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isKeyDown = !isKeyDown;
            onEquipBowPersonAnimator.Invoke(isKeyDown);
        }
    }
    private void LeftMouseAimWithBowPerson()
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
    private void InputMouseXTurnWithBowPerson()
    {
        float mouseX = Input.GetAxis("Mouse X");
        slowMouseX = Mathf.Lerp(slowMouseX, mouseX, 10 * Time.deltaTime);
        onTurnBowPersonAnimator.Invoke(slowMouseX);
    }
    private void InputKeyJumpPerson()
    {
        bool isJumping = Input.GetKeyDown(KeyCode.Space);
        onJumpPerson.Invoke(isJumping);
    }
    private void InputKeyRunnigPerson()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        onRunPerson.Invoke(isRunning);
    }
    private void InputAxisDirectionMove()
    {
        Vector3 InputAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        onAxisDirectionMove.Invoke(InputAxis);
    }
}
