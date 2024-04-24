
using UnityEditor.Rendering;
using UnityEngine; 

public class FreeCameraController : MonoBehaviour
{
    [SerializeField] private Transform targetLookPoint;
    [SerializeField] private Vector3 offset;

    [SerializeField] private Transform aimCameraPos; 


    public float sensitivityMouse = 2f;
    public float maxAngle = 45f;
    public float minAngle = -45;
    private float _inputMouseX = 0f;
    private float _inputMouseY = 0f;

    private float _currentZoomMouse = 5f;
    public float minZoom = 2f;
    public float maxZoom = 10f;
    public float speedZoom = 5f;
    
    private void Start()
    { 
        offset = transform.position - targetLookPoint.transform.position; 
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void RotateCamera(float inputMouseX,float inputMouseY) // call in InputContoller
    {
        _inputMouseX = inputMouseX * sensitivityMouse;
        _inputMouseY = Mathf.Clamp(inputMouseY * sensitivityMouse, minAngle, maxAngle); 
        transform.localEulerAngles = new Vector3(_inputMouseY, _inputMouseX, 0);  
        transform.position = transform.localRotation * offset + targetLookPoint.position;
    } 
    public void ZoomCamera(float currentZoomMouse) // call in InputContoller
    { 
        _currentZoomMouse = Mathf.Clamp(currentZoomMouse * speedZoom, minZoom, maxZoom); 
        transform.position = targetLookPoint.transform.position - transform.forward * _currentZoomMouse;
    } 
}
