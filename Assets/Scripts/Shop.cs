using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{   
    public float FirePower;
    public Slider upgradeBar;
    public float upgradeBa = 3;
    private float upgradecurrentBa = 0;
    [SerializeField] GameObject pauseMenu;
    private GameObject ScoreManager;
    private GameObject Bullet;
    
    // Start is called before the first frame update
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    // Start is called before the first frame update
    void Start()
    {
        upgradeBar.maxValue = upgradeBa;
        upgradeBar.value = upgradecurrentBa;
        upgradeBar.minValue = 0;

        
    }
    public void UpgradeSlider(){
        if(!FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>().UsePoint()) return;
        FirePower++;
        upgradecurrentBa += 1;
        upgradeBar.value = upgradecurrentBa;
       // ScoreManager.GetComponent<ScoreManager>().UsePoint();
        //Bullet.GetComponent<Bullet>().Upgrade();
        
        //Resume();

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
