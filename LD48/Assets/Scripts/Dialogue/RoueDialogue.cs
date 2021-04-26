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

    bool estOuvert = false;

    void Start()
    {

    }

    void Update()
    {
        if(estOuvert)
        {
            if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                Incrementercurseur(true);
            }
            else if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A))
            {
                Incrementercurseur(false);
            }
            else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Return))
            {
                listeOptions[curseur].Choisir();
            }
        }
    }

    public void AjouterOptionDialogue(OptionDialogue optionDialogue)
    {
        listeOptions.Add(Instantiate(baseOption, rectTrans.transform).GetComponent<ChoixDialogueUI>());
        listeOptions.Last().transform.localRotation = Quaternion.AngleAxis(angleDecalage * (listeOptions.Count -1), Vector3.forward);
        if (listeOptions.Count == 1 && estOuvert) listeOptions.Last().estHover = true;
        listeOptions.Last().Init(optionDialogue);
    }

    public void OuvrirRoue(bool ouvrir)
    {
        StartCoroutine(Fondu(ouvrir));
        rectTrans.localRotation = new Quaternion();
        curseur = 0;

        if (!ouvrir)
        {    
            listeOptions[curseur].estHover = false;
        }
    }


    private void Nettoyer()
    {
        for (int i = 0; i < listeOptions.Count; i++)
        {
            Destroy(listeOptions[i].gameObject);
        }
        listeOptions.Clear();
    }

    private IEnumerator Fondu(bool apparaitre)
    {
        Image[] graphismeMenu = GetComponentsInChildren<Image>();
        TextMeshProUGUI[] textes = GetComponentsInChildren<TextMeshProUGUI>();
        float tempsFondu = 1.5f;
        if(apparaitre)
        {
            for (float i = 0; i < 1; i += Time.deltaTime / tempsFondu)
            {
                foreach (Image image in graphismeMenu)
                {
                    image.color += new Color(0, 0, 0, Time.deltaTime / tempsFondu);
                }
                foreach (TextMeshProUGUI texte in textes)
                {
                    texte.color += new Color(0, 0, 0, Time.deltaTime / tempsFondu);
                }
                yield return new WaitForEndOfFrame();
            }
            estOuvert = true;
        }
        else
        {
            for (float i = 1; i > 0; i -= Time.deltaTime / tempsFondu)
            {
                foreach (Image image in graphismeMenu)
                {
                    image.color -= new Color(0, 0, 0, Time.deltaTime / tempsFondu);
                }
                foreach (TextMeshProUGUI texte in textes)
                {
                    texte.color -= new Color(0, 0, 0, Time.deltaTime / tempsFondu);
                }
                yield return new WaitForEndOfFrame();
            }
            Nettoyer();
            estOuvert = false;
        }
        if (listeOptions.Count >= 1 && estOuvert) listeOptions[0].estHover = true;
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
