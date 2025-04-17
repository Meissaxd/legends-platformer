using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private float smoothing = 5;
    private Vector3 offset;
    public float smoothTime = 5;
    void Start()
    {
        offset = transform.position - target.position;
    }
    void Update()
    {
        Vector3 targetCameraPosition = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position, 
            targetCameraPosition, 
            Time.deltaTime * smoothTime);
    }
}
