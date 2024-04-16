 
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCameraController : MonoBehaviour
{
    [Header("------------GameObjects------------")]

    [SerializeField] private Transform personPoint;
    [SerializeField] private Vector3 offset;

    [Header("------------Settings option camera------------")]

    [SerializeField] private float currentZoom = 30f;
    [SerializeField] private float maxZoom = 30f;
    [SerializeField] private float minZoom = 1f;
    [SerializeField] private float speedZoom = 10f;
    [SerializeField] private float speedRotate = 10f;
    [SerializeField] private float maxAngle = 45f;
    [SerializeField] private float minAngle = -45f;

    private float horizontalInput = 0f;
    private float verticalInput = 0f;

    public void Start()
    {
        offset = transform.position - personPoint.position;
        transform.LookAt(personPoint.position);
    }
    private void Update()
    {    
        ChangeOffsetZoom();
        GetMouseDirection();
    }
    private void FixedUpdate()
    {
        RotateCamera();
    }

    public void GetMouseDirection()
    {
        if (Mouse.current.middleButton.isPressed)
        {
            horizontalInput += Input.GetAxis("Mouse X") * speedRotate;
            verticalInput -= Input.GetAxis("Mouse Y") * speedRotate;
            verticalInput = Mathf.Clamp(verticalInput, minAngle, maxAngle);
        }
    }
    private void RotateCamera()
    {
        if (Mouse.current.middleButton.isPressed)
        {
            Quaternion horizontalRotation = Quaternion.Euler(0, horizontalInput, 0);
            transform.position = horizontalRotation * offset + personPoint.position;

            transform.LookAt(personPoint.position);
            transform.RotateAround(personPoint.position, transform.right, verticalInput);
        }
    }
    private void ChangeOffsetZoom()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * speedZoom;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        transform.position =  personPoint.position - currentZoom * transform.forward;
    }
}
