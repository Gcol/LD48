using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoueDialogue : MonoBehaviour
{
    static private RoueDialogue cela;

    static public RoueDialogue Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<RoueDialogue>();
            return cela;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AjouterOptionDialogue()
    {

    }
}
