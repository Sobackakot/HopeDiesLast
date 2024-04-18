
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private Transform ropeTransform; // текущая позиция тетивы 
    private Vector3 freeLocalPosition; // состояние тетивы в свободном положении
    [SerializeField] private Vector3 tenseLocalPosition; // состояние тетевы в натянутом положении
    private float tension; // прогресс натяжения тетевы
     
    public void Start()
    {
        freeLocalPosition = ropeTransform.localPosition; 
    } 
    public void TensionBowStrings(bool isPressedMouseButton) //call in InputContoller Aim Bow
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
    