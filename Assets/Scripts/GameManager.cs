using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    private int healthValue = 5;
    [SerializeField] private GameObject TouchButton, TouchText, TitleText;


    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            TouchButton.SetActive(false);
            TouchText.SetActive(false);
            TitleText.SetActive(false);
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
            Debug.Log("GameOver");
        }

        healthText.text = healthValue.ToString();
    }

}
