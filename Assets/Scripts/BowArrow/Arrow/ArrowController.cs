using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Transform row;
    public void Start()
    {
        transform.parent = row;
        transform.localPosition = Vector3.zero;
    }

    public void MoveArow()
    {

    }
}
