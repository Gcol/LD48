using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="nvlleReplique", menuName = "Creer Replique")]
public class Replique : ScriptableObject
{
    [TextArea(100,200)]
    public string texte;

}
