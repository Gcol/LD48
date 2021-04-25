using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GestionnaireEvenement : MonoBehaviour
{
    static private GestionnaireEvenement cela;

    static public GestionnaireEvenement Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<GestionnaireEvenement>();
            return cela;
        }
    }

    [SerializeField] private Evenement premierEvnement;

    // Start is called before the first frame update
    void Start()
    {
        LancerEvenement(premierEvnement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LancerEvenement(Evenement evenement)
    {
        evenement.quandLance.Invoke();
        StartCoroutine(RoutineEvenement(evenement, evenement.tempsEvenement));
    }


    public void LancerSuite(Evenement evenement)
    {
        foreach (Evenement.Suite suite in evenement.suites)
        {
            StartCoroutine(RoutineSuites(suite.prochaineEvent, suite.delai));
        }
    }

    private IEnumerator RoutineEvenement(Evenement evenement, float delai)
    {
        yield return new WaitForSeconds(delai);
        LancerSuite(evenement);
    }

    private IEnumerator RoutineSuites(UnityEvent uEvent, float delai)
    {
        yield return new WaitForSeconds(delai);
        uEvent.Invoke();
    }
}
