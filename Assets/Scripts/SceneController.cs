using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverUI;
    private int CurrentSceneIndex;
    
    
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
