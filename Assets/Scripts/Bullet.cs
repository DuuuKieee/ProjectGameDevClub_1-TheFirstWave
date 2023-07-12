using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float FirePower;

    public float maxDistance;
    Gun gun;
    Player player;
    void Start()
    {   
        player = FindObjectOfType<Player>();
        gun = FindObjectOfType<Gun>();
        FirePower = FindObjectOfType<Shop>().GetComponent<Shop>().FirePower;
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,player.transform.position) >= maxDistance){
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Bot") || other.gameObject.CompareTag("Tower")){
            Destroy(gameObject);
        }

    }
    

    public void Fire(){  
        Vector3 dir = transform.position - gun.transform.position;
        GetComponent<Rigidbody2D>().AddForce((Vector2)(dir)*FirePower);
        player.Push(-(Vector2)dir,FirePower/2);
    }
   
}
