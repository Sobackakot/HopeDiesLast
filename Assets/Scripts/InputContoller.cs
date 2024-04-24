
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
        InputKeyJumpPerson();
        InputKeyRunnigPerson(); 
    } 
    private void LateUpdate()
    {    
        InputAxisDirectionMove();
        InputMouseDrectionRotateCamera();
        if(!isPressedMouseButton) 
            InputMouseScroll();
        
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
            isPressedMouseButton = true;
        else if (Input.GetMouseButtonUp(0))
            isPressedMouseButton = false;
        if (isKeyDown)
            onAimBowPersonAnimator.Invoke(isPressedMouseButton);
    } 
    private void InputMouseDrectionRotateCamera()
    {   
        inputMouseX += Input.GetAxis("Mouse X");
        inputMouseY -= Input.GetAxis("Mouse Y"); 
        onAxisDirectionRotateCamera.Invoke(inputMouseX, inputMouseY); 
    }
    private void InputMouseScroll()
    {
        currentZoomMouse -= Input.GetAxis("Mouse ScrollWheel");
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
