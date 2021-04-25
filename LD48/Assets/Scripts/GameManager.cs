using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static private GameManager cela;

    static public GameManager Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<GameManager>();
            return cela;
        }
    }

    [SerializeField] private Nivo nivo;
    [SerializeField] private GestionnaireEvenement gestionnaireEvenement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CommencerJeu()
    {
        nivo.Init();
        gestionnaireEvenement.Init();
    }
    
    

}
