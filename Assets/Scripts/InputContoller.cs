 
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputContoller : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onAimBowPersonAnimator;
    [SerializeField] private UnityEvent<bool> onEquipBowPersonAnimator; 
    [SerializeField] private UnityEvent<bool> onJumpPerson;
    [SerializeField] private UnityEvent<bool> onRunPerson;
    [SerializeField] private UnityEvent<Vector3> onAxisDirectionMove;
    [SerializeField] private UnityEvent<float,float> onAxisDirectionRotateCamera;
    [SerializeField] private UnityEvent<float> onInputZoomCamera;


    private bool isKeyDown = false;
    private bool isPressedMouseButton = false;
     
    private Vector3 InputAxis;
    private float inputMouseX;
    private float inputMouseY;
    private float currentZoomMouse; 

    private void Update()
    {
        InputKeyEquipBowPerson();
        LeftMouseAimWithBowPerson();
        InputMouseDrectionRotateCamera(); 
        InputAxisDirectionMove();
        InputKeyJumpPerson();
        InputKeyRunnigPerson();
    } 
    private void LateUpdate()
    {
        InputMouseDrectionRotateCamera();
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
    private void InputMouseDrectionRotateCamera()
    {   
        inputMouseX += Input.GetAxis("Mouse X");
        inputMouseY -= Input.GetAxis("Mouse Y");
        currentZoomMouse -= Input.GetAxis("Mouse ScrollWheel");
        onAxisDirectionRotateCamera.Invoke(inputMouseX, inputMouseY);
        onInputZoomCamera.Invoke(currentZoomMouse);
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
        InputAxis = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        onAxisDirectionMove.Invoke(InputAxis);
    } 
}
