using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBalls : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;
    
    [SerializeField] private Transform rotatePoint;
    
    void Start()
    {
        
    }

    void Update()
    {
    transform.RotateAround(rotatePoint.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
