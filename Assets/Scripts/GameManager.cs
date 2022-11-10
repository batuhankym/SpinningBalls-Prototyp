using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private SceneController _sceneController;
    
    [SerializeField] private TextMeshProUGUI healthText;
    private int healthValue = 5;
    [SerializeField] private GameObject TouchButton, TouchText, TitleText;
    void Awake()
    {
        _sceneController = FindObjectOfType<SceneController>();
        Time.timeScale = 0;
    } 
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            HideStarterUI();
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
            _sceneController.GameOver();
            Debug.Log("GameOver");
        }

        healthText.text = healthValue.ToString();
    }


    private void HideStarterUI()
    {
        Time.timeScale = 1;
        TouchButton.SetActive(false);
        TouchText.SetActive(false);
        TitleText.SetActive(false);
    }

}
