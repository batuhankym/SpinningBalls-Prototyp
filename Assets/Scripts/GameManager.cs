using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }


}
