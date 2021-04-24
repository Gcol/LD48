using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "nvControleParam", menuName = "Controle/Creer Parametre")]
public class ControlesParam : ScriptableObject
{
    public Controle[] controles;

    [System.Serializable]
    public struct Controle
    {
        public string nomControle;
        public KeyCode inputPrincipal;
        public KeyCode inputSecondaire;
    }

    public bool InputEstAppuye(string nomControle)
    {
        foreach (Controle controle in controles)
        {
            if(controle.nomControle == nomControle)
            {
                if(Input.GetKey(controle.inputPrincipal) || Input.GetKey(controle.inputSecondaire))
                {
                    return true;
                }
                return false;
            }
        }
        throw new System.Exception("Ce controle n'existe pas. Vérifie le nom ou ajoute le controle dans les paramettre");
    }

    public bool InputEnfonce(string nomControle)
    {
        foreach (Controle controle in controles)
        {
            if (controle.nomControle == nomControle)
            {
                if (Input.GetKeyDown(controle.inputPrincipal) || Input.GetKeyDown(controle.inputSecondaire))
                {
                    return true;
                }
                return false;
            }
        }
        throw new System.Exception("Ce controle n'existe pas. Vérifie le nom ou ajoute le controle dans les paramettre");
    }

    public bool InputReleve(string nomControle)
    {
        foreach (Controle controle in controles)
        {
            if (controle.nomControle == nomControle)
            {
                if (Input.GetKeyUp(controle.inputPrincipal) || Input.GetKeyUp(controle.inputSecondaire))
                {
                    return true;
                }
                return false;
            }
        }
        throw new System.Exception("Ce controle n'existe pas. Vérifie le nom ou ajoute le controle dans les paramettre");
    }
}
