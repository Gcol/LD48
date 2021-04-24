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
    [SerializeField] [Min(0)] private float vitesse;
    [Tooltip("Vitesse de déplacement pendant le aircontrole")]
    [SerializeField] [Min(0)] private float vitesseMaxSaut;
    [SerializeField] [Min(0)] private float puissanceSaut;
    [SerializeField] [Min(0)] private float distanceSaut;

    private float profondeurDefaut;

    private bool saute
    {
        get
        {
            return rb.velocity.z > 0.001f || rb.velocity.z < -0.001f;
        }
    }

    [Header("Controles")]
    [SerializeField] private ControlesParam paramControles;

    private void OnDrawGizmos()
    {
        if(debug)
        {
            Gizmos.DrawWireSphere(transform.position, distanceMin);
            Gizmos.DrawWireSphere(transform.position, distanceMax);
        }
        Vector3 positionSouris = Input.mousePosition;
        positionSouris.z = Camera.main.transform.position.z + 300;
        positionSouris = Camera.main.ScreenToWorldPoint(positionSouris);

        //Gizmos.DrawCube(positionSouris, Vector3.one);
        //Gizmos.DrawLine(transform.position, transform.position + transform.right);
    }

    private void Awake()
    {
        Physics.gravity = Vector3.forward * 9.8f;
        profondeurDefaut = transform.position.z;
    }

    private void Update()
    {
        
        //AffecterControles();
        //SimulerPerspective();
    }

    private void FixedUpdate()
    {
        SuiveSouris();
    }

    private void SuiveSouris()
    {

        Vector3 positionSouris = Input.mousePosition;
        positionSouris.z = Camera.main.transform.position.z + 250;
        positionSouris = Camera.main.ScreenToWorldPoint(positionSouris);
        Vector3 direction = (positionSouris - transform.position).normalized;

        float distance = Mathf.Max(0, Vector2.Distance(transform.position, positionSouris) - distanceMin);
        distance = Mathf.Min(distance, distanceMax);

        float curseur = distance / distanceMax;

        float vitesseAppliquee;

        if (saute)
        {
            vitesseAppliquee = Mathf.Lerp(0, vitesseMaxSaut, curseur);
        }
        else
        {
            vitesseAppliquee = Mathf.Lerp(0, vitesseMax, curseur);
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.velocity =  direction * vitesseAppliquee * distance * Time.fixedDeltaTime + Vector3.forward * rb.velocity.z;

        Debug.DrawLine(transform.position, positionSouris,Color.magenta);
    }

    private void AffecterControles()
    {
        Vector3 direction = Vector3.zero;

        if(Input.GetKey(KeyCode.Q))
        {
            direction.x -= 1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            direction.x += 1;
        }
        if(Input.GetKey(KeyCode.Z))
        {
            direction.y += 1;
        }
        if(Input.GetKey(KeyCode.S))
        {
            direction.y -= 1;
        }

        rb.AddForce(direction * vitesse * Time.deltaTime);
        if(rb.velocity.magnitude > vitesseMax)
        {
            rb.velocity = rb.velocity.normalized * vitesseMax;
        }
        if (direction != Vector3.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if(Input.GetMouseButtonUp(0))
        {
            //if (saute == false)
            //{
            //    Vector2 positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    Vector2 direction = (positionSouris - (Vector2)transform.position).normalized;
            //    Sauter(direction);
            //}
        }
    }
    
    private void Sauter(Vector2 direction)
    {
        rb.AddForce(((Vector3)direction - Vector3.forward) * puissanceSaut);
    }

    private void SimulerPerspective()
    {
        transform.localScale = Vector3.Max(Vector3.zero, Vector3.one * (1 - transform.position.z - profondeurDefaut));
    }

    //private IEnumerator AppliquerSaut(Vector2 direction)
    //{

    //}
}
