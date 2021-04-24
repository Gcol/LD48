using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puce : MonoBehaviour
{
    [SerializeField] private bool debug;
    [Header("Physique")]
    [SerializeField] private Rigidbody rb;
    [Header("Deplacements")]
    [Tooltip("distance à de la puce en dessous de laquelle les mouvements de la souris ne sont pas pris en compte ")]
    [SerializeField] [Min(0)] private float distanceMin;
    [Tooltip("distance à de la puce au dessus de laquelle les mouvements de la souris ne sont pas pris en compte ")]
    [SerializeField] [Min(0)] private float distanceMax;
    [SerializeField] [Min(0)] private float vitesseMax;
    [Tooltip("Vitesse de déplacement pendant le aircontrole")]
    [SerializeField] [Min(0)] private float vitesseSaut;
    [SerializeField] [Min(0)] private float puissanceSaut;
    [SerializeField] [Min(0)] private float distanceSaut;

    private bool saute = false;

    [Header("Controles")]
    [SerializeField] private ControlesParam paramControles;

    private void OnDrawGizmos()
    {
        if(debug)
        {
            Gizmos.DrawWireSphere(transform.position, distanceMin);
            Gizmos.DrawWireSphere(transform.position, distanceMax);
        }
    }

    private void Awake()
    {
        Physics.gravity = Vector3.forward * 9.8f;
    }

    private void Update()
    {
        
        AffecterControles();
        
    }

    private void FixedUpdate()
    {
        SuiveSouris();
    }

    private void SuiveSouris()
    {
        Vector2 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (positionSouris - (Vector2)transform.position).normalized;
        float distance = Mathf.Max(0, Vector2.Distance(transform.position, positionSouris) - distanceMin);
        distance = Mathf.Min(distance, distanceMax);

        float curseur = distance / distanceMax;

        float vitesseAppliquee = Mathf.Lerp(0, vitesseMax, curseur);

        rb.velocity =  (Vector3)direction * vitesseAppliquee * distance * Time.fixedDeltaTime + Vector3.forward * rb.velocity.z;

        Debug.DrawLine(transform.position, positionSouris,Color.magenta);
    }

    private void AffecterControles()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Vector2 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (positionSouris - (Vector2)transform.position).normalized;
            Sauter(direction);
        }
    }
    
    private void Sauter(Vector2 direction)
    {
        rb.AddForce(-Vector3.forward * puissanceSaut);
    }

    //private IEnumerator AppliquerSaut(Vector2 direction)
    //{

    //}
}
