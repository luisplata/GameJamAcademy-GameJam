using System.Collections;
using UnityEngine;

public class StatusGameMono : MonoBehaviour, IStatusGame
{
    [SerializeField] private GameObject panel;
    public void GameOver()
    {
        StartCoroutine(GameOverCorrutine());
    }

    IEnumerator GameOverCorrutine()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(10f);
        panel.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
    }
}