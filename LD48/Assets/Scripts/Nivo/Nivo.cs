    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivo : MonoBehaviour
{

    static private Nivo cela;

    static public Nivo Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<Nivo>();
            return cela;
        }
    }

    [SerializeField] private float delaiSpawnSection;
    [SerializeField] private Section prefabSection;
    private int nbrSections;
    [SerializeField] private Gradient gradient;

    private void Awake()
    {
        //InitSections();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    public void Init()
    {
        StartCoroutine(RoutineSpawn());
    }


    private IEnumerator RoutineSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(delaiSpawnSection);
            
            if(Instantiate(prefabSection, transform).TryGetComponent(out Section section))
            {
                section.transform.localScale = new Vector3(0, 0, 1);
                section.sprRend.color = gradient.Evaluate(Random.Range(0f, 1f));
                section.sprRend.sortingOrder = nbrSections;
                nbrSections++;
            }
        }
    }

    public void ChangerGradientGenerationSection(Gradient nvgradient)
    {
        gradient = nvgradient;
    }
}