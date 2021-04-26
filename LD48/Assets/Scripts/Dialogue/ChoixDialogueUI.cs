using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ChoixDialogueUI : MonoBehaviour
{
    [SerializeField] private OptionDialogue optionDialogue;
    [SerializeField] private Image PanelFond;
    [SerializeField] private TextMeshProUGUI texte;
    [SerializeField] private Color couleurTexteDefaut;

    public bool estHover;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hover());
        texte.color = couleurTexteDefaut - new Color(0, 0, 0, 1);
        PanelFond.color = PanelFond.color - new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(OptionDialogue option)
    {
        optionDialogue = option;
        texte.text = option.texte;
    }


    private IEnumerator Hover()
    {
        texte.color = couleurTexteDefaut;
        yield return new WaitUntil(() => estHover == true);
        optionDialogue.quandHover.Invoke();
        float vitesseGradientHover = 0.7f;
        float temps=0;
        bool monte = true;
        while(estHover)
        {
            texte.color = optionDialogue.gradientHover.Evaluate(temps * vitesseGradientHover);
            yield return new WaitForEndOfFrame();

            if (monte && temps > 1) monte = false;
            else if (!monte && temps < 0) monte = true;

            temps += monte ? Time.deltaTime : -Time.deltaTime;
        }
        StartCoroutine(Hover());
    }

    public void Choisir()
    {
        optionDialogue.quandChoisi.Invoke();
    }

}
