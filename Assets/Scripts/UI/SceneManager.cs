using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    public void LoadScene(int character)
    {
        PlayerPrefs.SetInt("character",character);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
    
    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
    
    public void ExitGame()
    {
        Application.Quit();
        print("Quit Application");
    }

    public void ShotBossScream()
    {
        ServiceLocator.Instance.GetService<ISoundBossScream>().ShotScreamBoss();
    }

}
