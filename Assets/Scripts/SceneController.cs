using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    private int CurrentSceneIndex;

    private float count;
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        count += Time.unscaledDeltaTime;
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
