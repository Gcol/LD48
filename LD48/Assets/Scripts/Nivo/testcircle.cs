using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcircle : MonoBehaviour
{
    // avec r le rayon max du cercle et t le temps entre lecercle qui est un point et sa taille max, r*(t^2)
    [SerializeField] private SpriteRenderer srpRend;
    [SerializeField] float vitesse = 10; //in second
    [SerializeField] float forceRayon = 1.2f;
    [SerializeField] float rayonMax = 40;
    int frames = 0;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        transform.localScale = new Vector3 (forceRayon * (Mathf.Pow(frames,2))/(vitesse* Time.deltaTime), forceRayon * (Mathf.Pow(frames, 2)) / (vitesse* Time.deltaTime), 1f);

        if (transform.localScale.x > rayonMax) Destroy(gameObject);
    }


}
