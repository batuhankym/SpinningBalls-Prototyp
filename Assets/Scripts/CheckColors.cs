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
        if (Input.GetMouseButtonDown(0))
        {

            if (other.gameObject.CompareTag(gameObject.tag))
            {
                Destroy(gameObject);
                _gameManager.DestroyList();

            }
            if (!other.gameObject.CompareTag(gameObject.tag))
            {
                _gameManager.DecreaseHealth();
                ChangeScale();
                Debug.Log("ThisNotRed");
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
