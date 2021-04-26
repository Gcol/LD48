using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListeAnimations : MonoBehaviour
{
    static private ListeAnimations cela;

    static public ListeAnimations Instance
    {
        get
        {
            if (!cela) cela = FindObjectOfType<ListeAnimations>();
            return cela;
        }
    }

    [SerializeField] private List<Animator> animations = new List<Animator>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LancerAnimation(int index)
    {
        if (index > animations.Count - 1) throw new System.Exception("L'index d'animation est plus grand que le nombre d'animation,\n" +
              "Regarde bien l'objet ListeAnimations dans ta scene pour vérifier le nombre d'animations");
        if(Instantiate(animations[index].transform.root.gameObject, transform).TryGetComponent(out TomberProfond anim))
        {
            anim.transform.position = Random.insideUnitSphere + Vector3.one * 2;
        }
    }
}
