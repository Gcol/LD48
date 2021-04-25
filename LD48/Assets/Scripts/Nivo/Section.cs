using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    // avec r le rayon max du cercle et t le temps entre lecercle qui est un point et sa taille max, r*(t^2)
    public SpriteRenderer sprRend;
    [SerializeField] float temps = 10; //in second
    [SerializeField] float forceRayon = 1.2f;
    [SerializeField] float rayonMax = 40;
    float tempsDepuisDebut = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempsDepuisDebut += Time.deltaTime;
        float fps = 1 / Time.deltaTime ;
        transform.localScale = new Vector3(forceRayon * (Mathf.Pow(tempsDepuisDebut, 2)) / (temps), forceRayon * (Mathf.Pow(tempsDepuisDebut, 2)) / (temps), 1f);


        if (transform.localScale.x > rayonMax) Destroy(gameObject);
    }

}
