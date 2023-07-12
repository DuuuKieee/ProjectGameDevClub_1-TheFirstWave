using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MoveToPlayer : MonoBehaviour {

    float moveSpeed;
    public float minMoveSpeed = 0.05f;
    public float maxMoveSpeed = 0.3f;
    public float attackRange = 1;
    GameObject tower;
	// Use this for initialization
	void Start () {
        tower = GameObject.FindGameObjectWithTag("Tower");
        UpdateMoveSpeed();
	}

    void UpdateMoveSpeed()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }
	
    void Move()
    {
        if (tower == null)
            return;
        if (Vector3.Distance(transform.position, tower.transform.position) > attackRange)
        {
            float step = moveSpeed* Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,tower.transform.position,step);
        }
        else
        {
            gameObject.GetComponent<MinoControler>().isAttack = true;
            gameObject.GetComponent<MoveToPlayer>().enabled = false;
        }
    }

	// Update is called once per frame
	void Update () {
        Move();
	}
}
