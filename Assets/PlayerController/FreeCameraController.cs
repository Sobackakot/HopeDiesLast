
using UnityEngine; 

public class FreeCameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    public float sensitivityMouse = 5f;
    public float maxAngle = 45f;
    public float minAngle = -45;
     
    public float currentZoomMouse = 3f;
    public float minZoom = 2f;
    public float maxZoom = 10f;
    public float speedZoom = 5f;

    private float mouseX;
    private float mouseY;
    private void Start()
    {
        offset = transform.position - player.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        GetDirectionRotateCamera();
        RotateCamera();
        ZoomCamera();
    }
    public void RotateCamera()
    {
        transform.localEulerAngles = new Vector3(mouseY, mouseX, 0);
        transform.position = transform.localRotation * offset + player.transform.position;

    }
    private void GetDirectionRotateCamera()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivityMouse;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivityMouse;
        mouseY = Mathf.Clamp(mouseY, minAngle, maxAngle);
    }
    public void ZoomCamera()
    {
        currentZoomMouse -= Input.GetAxis("Mouse ScrollWheel") * speedZoom;
        currentZoomMouse = Mathf.Clamp(currentZoomMouse, minZoom, maxZoom);
        transform.position = player.transform.position - transform.forward * currentZoomMouse;
    }
}
