using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinoControler : MonoBehaviour {

    public int minoHealth = 3;
    private Animator anim;
   // private bool isShooten;
  //  public float shootTime = 0.5f;
    public bool isAttack = false;
    public float attackTime = 1;
   private float lastAttackTime = 0;
   private GameObject tower;
    private AudioSource audioS;
        public AudioClip playerFire;
        public AudioClip MinoHit;

         public float jumpHeight;
    Rigidbody2D rb;
    //public bool IsShooten
   // {
      //  get { return isShooten; }
      //  set
      //  {
       //     isShooten = value;
       //     ShootenAnim(isShooten);
       //     UpdateShootenTime();
       // }
   // }
   // private float lastShootenTime = 0;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
       // IsShooten = false;
        anim.SetBool("isDead", false);
        tower = GameObject.FindGameObjectWithTag("Tower");
        audioS = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

   // void UpdateShootenTime()
    //{
    //    lastShootenTime = Time.time;
    //}

    void UpdateAttackTime()
    {
        lastAttackTime = Time.time;
    }

   // void ShootenAnim(bool isShooten)
    //{
      //  anim.SetBool("isShooten", isShooten);
    //}

    void AttackAnim(bool isAttack)
    {
        anim.SetBool("isAttack", isAttack);
    }
	
    public void GetHit(int damge)
    {
       // IsShooten = true;
        minoHealth -= damge;     

        if (minoHealth >=1)
        {
            rb.AddForce(Vector2.up * jumpHeight);   
        }
        if (minoHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        anim.SetBool("isDead", true);
        Destroy(gameObject, 0.5f);
        ScoreManager.instance.AddPoint();
    }

    void Attack()
    {
        if (Time.time >= lastAttackTime + attackTime)
        {
            AttackAnim(true);
            UpdateAttackTime();
            tower.GetComponent<PlayerController>().GetHit(1);
            audioS.clip = playerFire;
            audioS.Play();
            Dead();
        }
        else
        {
            AttackAnim(false);
        }
    }

	// Update is called once per frame
	void Update () {
       // if (IsShooten && Time.time >= lastShootenTime + shootTime)
        //{
        //    IsShooten = false;
       // }
        if (isAttack)
        {
            Attack();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Bullet")){
             audioS.clip = MinoHit;
            audioS.Play();

            GetHit(1);
        }

    }
}
