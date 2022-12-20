using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
using DG.Tweening;
public class CheckColors : MonoBehaviour
{
    public bool isGameActive;

    private GameManager _gameManager;
    private SceneController _sceneController;

    private bool isInSameColor;
    private bool isGamePause;
    
    [SerializeField] private GameObject confettiParticle;
    private void Start()
    {        
        isGameActive = false;

        _gameManager = FindObjectOfType<GameManager>();

    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            if (!isGameActive)
            {
                isGameActive = true;
                _gameManager.HideStarterUI();

            }
            else if (isInSameColor && isGameActive) 
            {
                Instantiate(confettiParticle, transform.position, transform.rotation);
                Invoke(nameof(DestroyBall), 0.1f);
                _gameManager.Invoke(nameof(GameManager.DestroyList), 1f);
            }
            
            else
            {
                _gameManager.DecreaseHealth();
                ChangeScale();
            }
           
        }
         
        if (_gameManager.healthValue <= 0)
        {
            Destroy(gameObject);
        } 
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(gameObject.tag)) 
        {
                isInSameColor = true;

        }
        else
        {
                isInSameColor = false;
                
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

    private void DestroyBall()
    {
        Destroy(gameObject);

    }

  
}
