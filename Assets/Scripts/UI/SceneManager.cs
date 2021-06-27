using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private int characterIndex;

    public void LoadScene(string character)
    {
        PlayerPrefs.SetString("character",character);
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

    public void SelectYourCharacter()
    {
        PlayerPrefs.SetInt("Character", characterIndex);
        //Debug.Log("Character is: " + PlayerPrefs.GetInt("Character") + characterIndex);
    }
}
