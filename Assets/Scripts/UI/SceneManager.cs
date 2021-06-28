using System;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    [SerializeField] private string music;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        ServiceLocator.Instance.GetService<IMusic>().StartMusic(music);
    }

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
