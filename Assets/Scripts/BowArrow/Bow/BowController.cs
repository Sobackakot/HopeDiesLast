
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private Transform ropeTransform;
    private Vector3 freeLocalPosition;
    [SerializeField] private Vector3 tenseLocalPosition; 
    private float tension; 
    public List<Vector3> positions = new List<Vector3>();
     
    public void Start()
    {
        freeLocalPosition = ropeTransform.localPosition; 
        foreach(var list in positions)
        {
            positions.Add(freeLocalPosition);
        }
    }
    public void AimBow(bool isPressedMouseButton)
    { 
        if (isPressedMouseButton && tension <= 1)
        {
            tension += Time.deltaTime; 
            ropeTransform.localPosition = Vector3.Lerp(freeLocalPosition, tenseLocalPosition, tension);
        }
        if (!isPressedMouseButton)
        {
            tension = 0;
            ropeTransform.localPosition = freeLocalPosition;
        }
    }
}
    