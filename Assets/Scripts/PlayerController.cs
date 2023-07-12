using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    [SerializeField] GameObject endMenu;

    public float towerHealth = 10;
    public float towerCurrentHealth = 10;
   // public AudioClip towerDeathSound;
    public Slider healthBar;

    //private float towerCurrentHealth = 10;
   // private Animator anim;
    private GameObject gameController;
	// Use this for initialization
	void Start () {
        //anim = gameObject.GetComponent<Animator>();
        healthBar.maxValue = towerHealth;
        healthBar.value = towerCurrentHealth;
        healthBar.minValue = 0;
	}

    private void Update() {
        healthBar.value = towerCurrentHealth;
    }
    public void GetHit(float damge)
    {
        towerCurrentHealth -= damge;

        if (towerCurrentHealth <= 0)
        {
            Invoke("Dead", 1);
        }
    }

    void Dead()
    {
        endMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    
}

	// Update is called once per frame

