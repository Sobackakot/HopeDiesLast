
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private Transform ropeTransform;
    private Vector3 freeLocalPosition;
    [SerializeField] private Vector3 tenseLocalPosition; 
    private float tension; 
    public List<Vector3> positions = new List<Vector3>();

    private bool isPressed = false;
    public void Start()
    {
        freeLocalPosition = ropeTransform.localPosition; 
        foreach(var list in positions)
        {
            positions.Add(freeLocalPosition);
        }
    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            tension = 0;
            ropeTransform.localPosition = freeLocalPosition;
        }
        if(isPressed && tension <= 1)
        {
            tension += Time.deltaTime;
            tension = Mathf.Clamp01(tension);
            ropeTransform.localPosition = Vector3.Lerp(freeLocalPosition, tenseLocalPosition, tension); 
        }   
    }
}
    