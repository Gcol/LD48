using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    

    private List<ChoixDialogueUI> listeOptions = new List<ChoixDialogueUI>();

    [SerializeField] private GameObject baseOption;
    [SerializeField] private float angleDecalage;
    [SerializeField] private OptionDialogue test;
    [SerializeField] private RectTransform rectTrans;
    [SerializeField] private float vitesseRotationRoue;
    private int curseur = 0;

    void Start()
    {
        OuvrirRoue(false);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Incrementercurseur(true);
        }
        else if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A))
        {
            Incrementercurseur(false);
        }
    }

    public void AjouterOptionDialogue(OptionDialogue optionDialogue)
    {
        listeOptions.Add(Instantiate(baseOption, rectTrans.transform).GetComponent<ChoixDialogueUI>());
        listeOptions.Last().transform.localRotation = Quaternion.AngleAxis(angleDecalage * (listeOptions.Count -1), Vector3.forward);
        if (listeOptions.Count == 1) listeOptions.Last().estHover = true;
        listeOptions.Last().Init(optionDialogue);
    }

    public void OuvrirRoue(bool ouvrir)
    {
        rectTrans.gameObject.SetActive(ouvrir);
    }

    public void Incrementercurseur(bool increm)
    {
        if(!increm)
        {
            curseur = Mathf.Max(0, curseur -1 );
        }
        else
        {
            curseur = Mathf.Min(listeOptions.Count - 1, curseur + 1);
        }

        foreach (ChoixDialogueUI choix in listeOptions)
        {
            choix.estHover = false;
        }
        StartCoroutine(RoutineRotationRoue(Quaternion.AngleAxis(angleDecalage * -curseur, Vector3.forward)));
    }

    private IEnumerator RoutineRotationRoue(Quaternion rotationCible)
    {
        float temps = 0 ;
        Quaternion rotationDepart = rectTrans.localRotation;
        while (rectTrans.localRotation != rotationCible)
        {
            rectTrans.localRotation = Quaternion.Lerp(rotationDepart, rotationCible, temps);
            yield return new WaitForEndOfFrame();
            temps += vitesseRotationRoue * Time.deltaTime;
        }
        listeOptions[curseur].estHover = true;
    }
}
