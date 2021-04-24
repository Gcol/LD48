using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public SpriteRenderer sprRend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1,1) * 3 * Time.deltaTime;
        if (transform.localScale.x > 40) Destroy(gameObject);
    }


}
