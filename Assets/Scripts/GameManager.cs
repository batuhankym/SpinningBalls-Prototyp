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
    public static GameManager instance;
    
    [SerializeField] private Camera mainCam;
    private SceneController _sceneController;
    private CheckColors _checkColors;

    [SerializeField] private List<GameObject> ballCount = new List<GameObject>();
    [SerializeField] private Ease MotionType;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject TouchText, TouchButton, healthCounter, playAgainButton, playAgainText;
    
    public int healthValue = 5;

  
  
    private void Start()
    {
        mainCam = GetComponent<Camera>();
        mainCam = Camera.main;
        
        mainCam.transform.DOMoveX(0, 3f).SetLoops(1).SetEase(MotionType).SetUpdate(true);
        
        playAgainText.transform.DOScale(1.2f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);

        playAgainButton.transform.DOMoveX(355f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);

        TouchText.transform.DOScale(1.2f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);
        TouchButton.transform.DOMoveX(355f, 1f).SetLoops(1000, LoopType.Yoyo).SetEase(MotionType).SetUpdate(true);


       
        
        _sceneController = FindObjectOfType<SceneController>();
        Time.timeScale = 0;
        
    }

    private void Update()
    {
        
        
        if (Input.GetMouseButtonDown(0))
        {
            if (healthValue <= 0)
            {
                _sceneController.RestartGame();
            }
        }

       
    }

    public void DecreaseHealth()
    {
        healthValue--;
        if (healthValue < 0)
        {

            healthValue = 0;
        } 
        if(healthValue <= 0)
        {
            _sceneController.Invoke("GameOver",1f);
            Debug.Log("GameOver");

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
            
            mainCam.transform.DOMoveX(8, 2f).SetLoops(1).SetEase(MotionType).SetUpdate(true);

            TouchButton.SetActive(true);
            TouchText.SetActive(true);
            healthCounter.SetActive(false);


            _sceneController.Invoke(nameof(_sceneController.LoadNextScene),2.1f);

        }
    }

   private void SetTimeActive()
   {
       Time.timeScale = 1;
   }

}


    

    

