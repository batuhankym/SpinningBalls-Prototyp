using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
// ReSharper disable All
public class GameManager : MonoBehaviour
{
    private SceneController _sceneController;

    [SerializeField] private List<GameObject> ballCount = new List<GameObject>();
    [SerializeField] private Ease MotionType;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject TouchButton, TouchText, healthCounter, playAgainButton, playAgainText;

    [SerializeField] private GameObject victoryVFX;

    private int healthValue = 5;

    
    private void Start()
    {
        TouchText.transform.DOScale(1.2f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);
        playAgainText.transform.DOScale(1.2f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);

        TouchButton.transform.DOMoveX(355f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);
        playAgainButton.transform.DOMoveX(355f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);

        

        _sceneController = FindObjectOfType<SceneController>();
        Time.timeScale = 0;
        
    }

   
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            
        }
  
        
        
    }
    public void DecreaseHealth()
    {
        healthValue--;
        if (healthValue < 0)
        {
            healthValue = 0;
        }
        else if(healthValue <= 0)
        {
            _sceneController.Invoke("GameOver",1f);
            
            Debug.Log("GameOver");
            if (Input.GetMouseButtonDown(0))
            {
                _sceneController.RestartGame();
            }
        }

        healthText.text = healthValue.ToString();
    }


    public void HideStarterUI()
    {
        Time.timeScale = 1;
        TouchButton.SetActive(false);
        TouchText.SetActive(false);
        healthCounter.SetActive(true);
    }
    

   public void DestroyList()
   {
       ballCount.Remove(ballCount[ballCount.Count -1]);

        if (ballCount.Count == 0)
        {
            Instantiate(victoryVFX, transform.position, transform.rotation);

            _sceneController.Invoke(nameof(_sceneController.LoadNextScene),1f);

        }
    }

   private void SetTimeActive()
   {
       Time.timeScale = 1;
   }

}


    

    

