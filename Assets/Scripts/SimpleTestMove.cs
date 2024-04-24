using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTestMove : MonoBehaviour
{   
    public Rigidbody body;
    public Animator prsonAnim;
    public float speedMove = 10f;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z= Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x,0,z).normalized;
        if(direction.sqrMagnitude > 0)
        {
            prsonAnim.SetFloat("velocityX", direction.x * speedMove, 0.1f, Time.deltaTime);
            prsonAnim.SetFloat("velocityY", direction.z * speedMove, 0.1f, Time.deltaTime);
            body.MovePosition(body.position + direction * speedMove * Time.deltaTime);
        } 
        else
        {
            prsonAnim.SetFloat("velocityX", 0, 0.1f, Time.deltaTime);
            prsonAnim.SetFloat("velocityY", 0, 0.1f, Time.deltaTime);
        }
    }
}
