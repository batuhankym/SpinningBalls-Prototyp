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
    

    private int index;
    private bool isCollided;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();

    }
    private void OnTriggerStay(Collider other)
    {
        isCollided = true;
        
        if (Input.GetMouseButtonDown(0) && isCollided)
        {
            if (gameObject.CompareTag("RedBall") && other.gameObject.CompareTag("RedCircle"))
            {
                Destroy(gameObject);
                _gameManager.DestroyList();

            }
            else if (gameObject.CompareTag("RedBall") && !other.gameObject.CompareTag("RedCircle"))
            {
                _gameManager.DecreaseHealth();
                ChangeScale();
                Debug.Log("ThisNotRed");
            }
            
            if (gameObject.CompareTag("GreenBall") && other.gameObject.CompareTag("GreenCircle"))
            {
                Destroy(gameObject);
                _gameManager.DestroyList();


                
            }
            else if (gameObject.CompareTag("GreenBall") && !other.gameObject.CompareTag("GreenCircle"))
            {
                _gameManager.DecreaseHealth();
                ChangeScale();

                Debug.Log("ThisNotGreen");
            }
            
            if (gameObject.CompareTag("YellowBall") && other.gameObject.CompareTag("YellowCircle"))
            {
                Destroy(gameObject);
                _gameManager.DestroyList();


               
            }
            else if (gameObject.CompareTag("YellowBall") && !other.gameObject.CompareTag("YellowCircle"))
            {
                _gameManager.DecreaseHealth();
                ChangeScale();

                Debug.Log("ThisNotYellow");
            }
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        isCollided = false;
        
    }
   

    private void ChangeScale()
    {
        transform.DOScale(Vector3.one * 1f, 0.5f).OnComplete(ReturnOriginalScale);

    }

    private void ReturnOriginalScale()
    {
        transform.DOScale(new Vector3(0.8f,0.8f,0.8f),0.5f);
    }
    
    
}
