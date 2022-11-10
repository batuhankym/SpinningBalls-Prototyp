using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;
public class CheckColors : MonoBehaviour
{
    private GameManager _gameManager;
    
    [SerializeField] private List<GameObject> healtsList = new List<GameObject>();
    [SerializeField] private GameObject healthPrefab;

    private int index;
    private bool isCollided;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        healtsList.Add(healthPrefab);

    }
    private void OnTriggerStay(Collider other)
    {
        isCollided = true;
        
        if (Input.GetMouseButtonDown(0) && isCollided)
        {
            if (gameObject.CompareTag("RedBall") && other.gameObject.CompareTag("RedCircle"))
            {
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("RedBall") && !other.gameObject.CompareTag("RedCircle"))
            {
                _gameManager.DecreaseHealth();

                Invoke(nameof(DestroyList),1);
                Debug.Log("ThisNotRed");
            }
            
            if (gameObject.CompareTag("GreenBall") && other.gameObject.CompareTag("GreenCircle"))
            {
                Destroy(gameObject);
                
            }
            else if (gameObject.CompareTag("GreenBall") && !other.gameObject.CompareTag("GreenCircle"))
            {
                _gameManager.DecreaseHealth();

                Invoke(nameof(DestroyList),1);
                Debug.Log("ThisNotGreen");
            }
            
            if (gameObject.CompareTag("YellowBall") && other.gameObject.CompareTag("YellowCircle"))
            {
                Destroy(gameObject);
               
            }
            else if (gameObject.CompareTag("YellowBall") && !other.gameObject.CompareTag("YellowCircle"))
            {
                _gameManager.DecreaseHealth();

                Invoke(nameof(DestroyList),1);
                Debug.Log("ThisNotYellow");
            }
        }
    } 
    private void OnTriggerExit(Collider other)
    {
        isCollided = false;
        
    }
    private void DestroyList()
    {
        healtsList.RemoveAt(1);
        Destroy(healtsList[1]);
    }
}
