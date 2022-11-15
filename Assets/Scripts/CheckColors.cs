using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using DG.Tweening;
public class CheckColors : MonoBehaviour
{
    private GameManager _gameManager;
    

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (transform.CompareTag("Red") && other.transform.CompareTag("Red"))
            {
                Destroy(gameObject);
                _gameManager.DestroyList();

            }
            else if (transform.CompareTag("Red") && !other.transform.CompareTag("Red"))
            {
                _gameManager.DecreaseHealth();
                ChangeScale();
                Debug.Log("ThisNotRed");
            }
            
            if (transform.CompareTag("Green") && other.transform.CompareTag("Green"))
            {
                Destroy(gameObject);
                _gameManager.DestroyList();


                
            }
            else if (transform.CompareTag("Green") && !transform.CompareTag("Green"))
            {
                _gameManager.DecreaseHealth();
                ChangeScale();

                Debug.Log("ThisNotGreen");
            }
            
            if (transform.CompareTag("Yellow") && other.transform.CompareTag("Yellow"))
            {
                Destroy(gameObject);
                _gameManager.DestroyList();


               
            }
            else if (transform.CompareTag("Yellow") && !other.transform.CompareTag("Yellow")) 
            {
                _gameManager.DecreaseHealth();
                ChangeScale();

                Debug.Log("ThisNotYellow");
            }
        }
    }
    
    private void ChangeScale()
    {
        transform.DOScale(Vector3.one * 1.5f, 0.5f).OnComplete(ReturnOriginalScale);

    }

    private void ReturnOriginalScale()
    {
        transform.DOScale(new Vector3(0.8f,0.8f,0.8f),0.5f);
    }
    
    
}
