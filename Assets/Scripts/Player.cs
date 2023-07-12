using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Push(Vector2 dir,float power){
        GetComponent<Rigidbody2D>().AddForce(dir*power,ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bot")){
            Vector2 dir = transform.position - other.gameObject.GetComponent<Transform>().position;
            Push(Vector2.up + dir.normalized,5);
        }
    }
}
