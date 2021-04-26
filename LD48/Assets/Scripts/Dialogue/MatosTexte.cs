using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class MatosTexte : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI texte;
    private float tempsFondu = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTempsFondu(float nvTemps)
    {
        tempsFondu = nvTemps;
    }

    public void AfficherTexte(string texteAAfficher)
    {
        texte.text = texteAAfficher;
        StartCoroutine(FondreTexte(tempsFondu, false));
    }

    public void CacherTexte()
    {
        StartCoroutine(FondreTexte(tempsFondu, true));
    }

    private IEnumerator FondreTexte(float tempsDuFondu, bool disparaitre)
    {
        if(disparaitre)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime / tempsDuFondu)
            {
                // set color with i as alpha
                texte.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime / tempsDuFondu)
            {
                // set color with i as alpha
                texte.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }   
    }
}
