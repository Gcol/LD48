using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuDebut : MonoBehaviour
{
    [SerializeField] private float tempsFondu;
    public bool estActif = true;

    private System.Action quandFonduFini;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DemarerJeu()
    {
        if(estActif)
        {
            estActif = false;
            quandFonduFini = new System.Action(() =>
            {
                GameManager.Instance.CommencerJeu();
            });
            StartCoroutine(FonduMenu());
        }
    }

    private IEnumerator FonduMenu()
    {
        Image[] graphismeMenu = GetComponentsInChildren<Image>();
        TextMeshProUGUI[] textes = GetComponentsInChildren<TextMeshProUGUI>();

        for (float i = 1; i > 0; i -= Time.deltaTime/tempsFondu)
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
        quandFonduFini.Invoke();
    }

    public void Quitter()
    {
        estActif = false;
        quandFonduFini = new System.Action(() =>
        {
#if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
            Application.Quit();
#elif (UNITY_WEBGL)
            Application.OpenURL("https://www.youtube.com/watch?v=zXvTfca7i6A");
#endif
        });
        StartCoroutine(FonduMenu());
    }
}

