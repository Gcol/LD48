using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwn : MonoBehaviour
{
    [SerializeField] float t;
    float chrono=0;
   [SerializeField] GameObject go;
    int l = 0;
    void Start()
    {
        chrono = t*Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(chrono<=0)
        {
            GameObject g = Instantiate(go);
            g.transform.position = Vector2.zero;
            g.GetComponent<SpriteRenderer>().sortingOrder = l;
            l++;
            chrono = t;
            //spawn
        }
        else { chrono-= Time.fixedDeltaTime; }
    }
}
