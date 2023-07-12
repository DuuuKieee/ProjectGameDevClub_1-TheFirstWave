using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    public float pushPower;

    Rigidbody2D rb;

    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && isGrounded)
        {
            Vector3 dir = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = dir.normalized;

            rb.AddForce(-dir * pushPower, ForceMode2D.Force);
            rb.velocity = -dir * pushPower;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
}