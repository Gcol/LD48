    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivo : MonoBehaviour
{
    public Section[] sections;
    [SerializeField] private float tailleDestruction;
    [SerializeField] private float vitesseDilatation;
    [SerializeField] private Section prefabSection;
    [SerializeField] private float ratioDistance;
    [SerializeField] [Min(0)] private int nbrSectionsAGenerer;

    private int nbrSections;

    private void Awake()
    {
        //InitSections();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenererSections());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //SimulerProfondeur();
    }

    private void SimulerProfondeur()
    {
        //for (int i = 0; i < sections.Length; i++)
        //{
        //    Vector3 nvlleTaile = sections[i].transform.localScale;
        //    nvlleTaile.x = Mathf.Pow(vitesseDilatation, nvlleTaile.x);
        //    nvlleTaile.y = Mathf.Pow(vitesseDilatation, nvlleTaile.y);

        //    if (i == 0) print(nvlleTaile.x - sections[i].transform.localScale.x);

        //    sections[i].transform.localScale += new Vector3(1,1,0)   * vitesseDilatation  * Time.fixedDeltaTime;
        //}

        Vector3 nvlleTaille = transform.localScale;
        nvlleTaille.x += Mathf.Pow(1 + vitesseDilatation * Time.fixedDeltaTime, 1 + Time.timeSinceLevelLoad/100);
        nvlleTaille.y += Mathf.Pow(1 + vitesseDilatation * Time.fixedDeltaTime, 1 +Time.timeSinceLevelLoad/100);

        print(nvlleTaille.x - transform.localScale.x);
        //print(Time.timeSinceLevelLoad);

        transform.transform.localScale = nvlleTaille;
    }

    public void InitSections()
    {
        NettoyerSections();
        sections = new Section[nbrSectionsAGenerer];
        for (int i = 0; i < sections.Length; i++)
        {
            if(Instantiate(prefabSection.gameObject, transform).TryGetComponent(out sections[i]))
            {
                sections[i].sprRend.color = Random.ColorHSV();
            }
        }

        for (int i = 0; i < sections.Length; i++)
        {
            if (i > 0)
            {
                Vector3 nvlleTaile = sections[i - 1].transform.localScale;
                nvlleTaile.x -= nvlleTaile.x / ratioDistance;
                nvlleTaile.y -= nvlleTaile.y / ratioDistance;

                //print(sections[i - 1].transform.localScale.x + " - " + sections[i - 1].transform.localScale.x / 12 + " = " + nvlleTaile.x);

                sections[i].transform.localScale = nvlleTaile;
            }
            else
            {
                sections[i].transform.localScale = new Vector3(1, 1, 0) * 30 + Vector3.forward;
            }
            sections[i].sprRend.sortingOrder = i;
        }
    }

    private void NettoyerSections()
    {
        for (int i = 0; i < sections.Length; i++)
        {       
            if (Application.isPlaying) Destroy(sections[i].gameObject);
            else
            {

                DestroyImmediate(sections[i].gameObject);
            }
                
        }
    }


    [SerializeField] private float delai;

    private IEnumerator GenererSections()
    {
        while(true)
        {
            yield return new WaitForSeconds(delai);
            if(Instantiate(prefabSection,transform).TryGetComponent(out Section nvlleSection))
            {
                nbrSections++;
                nvlleSection.transform.localScale = new Vector3(0.1f, 0.1f);
                nvlleSection.sprRend.color = Random.ColorHSV();
                nvlleSection.sprRend.sortingOrder = nbrSections;
            }
        }
    }
}
