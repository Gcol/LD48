using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] private float vitesseZoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera.main.fieldOfView -= (vitesseZoom + Mathf.Exp(1 + Time.timeSinceLevelLoad / 4)) * Time.deltaTime ;
        transform.position = transform.position + Vector3.forward * vitesseZoom * Time.deltaTime;
    }
}
