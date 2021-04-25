using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="NvlleOptionDialogue", menuName = "Creer Option Dialogue")]
public class OptionDialogue : ScriptableObject
{
    public UnityEvent quandChoisi;

    [TextArea(30,200)]
    public string texte;
}
