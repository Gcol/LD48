using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepliqueRobot : MatosTexte
{
    static private RepliqueRobot cela;

    static public RepliqueRobot Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<RepliqueRobot>();
            return cela;
        }
    }

    private void Start()
    {
        texte.color = new Color(1,1,1,0);
    }
}
