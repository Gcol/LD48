using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomberProfond : MonoBehaviour
{
    public float tempsChute;
    private Vector3 positionDepart;
    private Vector3 tailleDepart;
    private float temps;

    // Start is called before the first frame update
    void Start()
    {
        positionDepart = transform.position;
        tailleDepart = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        temps += Time.deltaTime / tempsChute;
        Tomber();
    }

    private void Tomber()
    {
        transform.position = Vector3.Lerp(positionDepart, Vector3.zero - Vector3.forward, temps);
        transform.localScale = Vector3.Lerp(tailleDepart, Vector3.zero, temps);
        transform.localEulerAngles += Vector3.forward * 10 * Time.deltaTime;
        if (temps > 1) Destroy(gameObject);
    }
}
