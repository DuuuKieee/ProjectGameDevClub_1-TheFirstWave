using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Scene : MonoBehaviour
{
    public void ButtonMoveScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
}