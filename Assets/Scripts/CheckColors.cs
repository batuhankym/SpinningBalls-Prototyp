using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class CheckColors : MonoBehaviour
{
    [SerializeField] private List<GameObject> healtsList = new List<GameObject>();
    [SerializeField] private GameObject healthPrefab;
    private bool isCollided;

    private void Start()
    {
        healtsList.Add(healthPrefab);
    }

    private void OnTriggerStay(Collider other)
    {
        isCollided = true;

        if (Input.GetMouseButtonDown(0) && isCollided)
        {
            if (this.gameObject.CompareTag("RedBall") && other.gameObject.CompareTag("RedCircle"))
            {
                Destroy(gameObject);
                
               
            }
            else if (this.gameObject.CompareTag("RedBall") && !other.gameObject.CompareTag("RedCircle"))
            {
                Invoke(nameof(DestroyList),1);
                Debug.Log("ThisNotRed");
            }
            if (this.gameObject.CompareTag("GreenBall") && other.gameObject.CompareTag("GreenCircle"))
            {
                Destroy(gameObject);
                
            }
            else if (this.gameObject.CompareTag("GreenBall") && !other.gameObject.CompareTag("GreenCircle"))
            {
                Invoke(nameof(DestroyList),1);
                Debug.Log("ThisNotGreen");
            }
            if (this.gameObject.CompareTag("YellowBall") && other.gameObject.CompareTag("YellowCircle"))
            {
                Destroy(gameObject);
               
            }
            else if (this.gameObject.CompareTag("YellowBall") && !other.gameObject.CompareTag("YellowCircle"))
            {
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
