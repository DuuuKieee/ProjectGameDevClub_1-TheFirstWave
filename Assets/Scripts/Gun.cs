using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject bullet;
       private AudioSource audioS;
        public AudioClip playerFire;

    public GameObject head;

    public float fireSpeed;

   
    float m_fireTime;
    void Start()
    {
        m_fireTime = 0;
        audioS = gameObject.GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {   m_fireTime -= Time.deltaTime;
        if(Input.GetMouseButton(0) && m_fireTime <= 0){
            float angle = Vector2.SignedAngle(Vector2.left,head.transform.position - transform.position);
            Instantiate(bullet,head.transform.position,Quaternion.Euler(0,0,angle));
            m_fireTime = fireSpeed;
            audioS.clip = playerFire;
            audioS.Play();
            
        }
    }

    
}
