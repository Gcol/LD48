using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private GameObject menuPause;
    [SerializeField] private Nivo nivo;
    [SerializeField] private GestionnaireEvenement gestionnaireEvenement;

    private bool enPause = false;

    // Start is called before the first frame update
    void Start()
    {
        menuPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            MettreEnPause(!enPause);
        }
    }

    public void CommencerJeu()
    {
        nivo.Init();
        gestionnaireEvenement.Init();
    }
    
    public void MettreEnPause(bool pause)
    {
        enPause = pause;
        Time.timeScale = pause ? 0 : 1;
        menuPause.SetActive(pause);
    }

    public void RelancerJeu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }

    public void Quitter()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
            Application.Quit();
#elif (UNITY_WEBGL)
            Application.OpenURL("https://www.youtube.com/watch?v=zXvTfca7i6A");
#endif
    }
}
