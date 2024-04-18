
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private Transform ropeTransform; // ������� ������� ������ 
    private Vector3 freeLocalPosition; // ��������� ������ � ��������� ���������
    [SerializeField] private Vector3 tenseLocalPosition; // ��������� ������ � ��������� ���������
    private float tension; // �������� ��������� ������
     
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
    