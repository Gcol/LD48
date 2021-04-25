using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName ="nvleEvenement", menuName = "Creer Evenement")]
public class Evenement : ScriptableObject
{
    [Tooltip("Le temps que dure l'evenement")]
    public float tempsEvenement;
    public UnityEvent quandLance;
    public Suite[] suites;

    [System.Serializable]
    public struct Suite
    {
        public float delai;
        public UnityEvent prochaineEvent;
    }


    public void LancerEvenement()
    {
        GestionnaireEvenement.Instance.LancerEvenement(this);
    }

    public void ChangerTempsFondu(float tempsFondu)
    {
        RepliqueRobot.Instance.SetTempsFondu(tempsFondu);
    }

    public void LancerRepliqueRobot(Replique replique)
    {
        RepliqueRobot.Instance.AfficherTexte(replique.texte);
    }

    public void CacherRepliqueRobot()
    {
        RepliqueRobot.Instance.CacherTexte();
    }


    public void OuvrirRoueDialogue(bool ouvrir)
    {
        RoueDialogue.Instance.OuvrirRoue(ouvrir);
    }

    public void AjouterOptionDialogue(OptionDialogue option)
    {
        RoueDialogue.Instance.AjouterOptionDialogue(option);
    }

    public void ChangerGradientSection(GradientScript gradient)
    {
        Nivo.Instance.ChangerGradientGenerationSection(gradient.gradient);
    }
}
