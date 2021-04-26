using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="NvlleOptionDialogue", menuName = "Creer Option Dialogue")]
public class OptionDialogue : ScriptableObject
{
    public UnityEvent quandChoisi;
    public UnityEvent quandHover;
    public Gradient gradientHover;

    [TextArea(30,200)]
    public string texte;

    public void OuvrirRoueDialogue(bool ouvrir)
    {
        RoueDialogue.Instance.OuvrirRoue(ouvrir);
    }

    public void AjouterOptionDialogue(OptionDialogue option)
    {
        RoueDialogue.Instance.AjouterOptionDialogue(option);
    }
    public void AjouterOptionDialogue()
    {
        RoueDialogue.Instance.AjouterOptionDialogue(this);
    }

    public void OuvrirURL(string URL)
    {
        Application.OpenURL(URL);
    }

}
