using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class QueueCerfVolant : MonoBehaviour
{
    [SerializeField] private Transform cible;
    [SerializeField] private LineRenderer lineRend;
    [SerializeField] [Min(0.001f)] private float distanceEntreSegments;
    [SerializeField] [Min(0.001f)] private float tempsSegment;
    [SerializeField] [Min(0)] private float vitesseOndulation;
    [SerializeField] [Min(0)] private float amplitudeOndulation;
    [SerializeField] [Min(0)] private int nbrSection;

    private void OnValidate()
    {
        InitialiserQueue();
    }

    private void Awake()
    {
        InitialiserQueue();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SimulerQueue();
    }

    private void InitialiserQueue()
    {
        lineRend.positionCount = nbrSection;
        for (int i = 0; i < lineRend.positionCount; i++)
        {
            lineRend.SetPosition(i, new Vector3(-distanceEntreSegments * i, 0, 0) + transform.parent.position);
        }
    }
    private void SimulerQueue()
    {
        lineRend.SetPosition(0, transform.position);
        for (int i = 1; i < lineRend.positionCount; i++)
        {
            Vector3 velocite = Vector3.zero;
            Vector3 positionPrec = lineRend.GetPosition(i - 1);
            Vector2 positionAct = lineRend.GetPosition(i);
            Vector3 position = Vector3.SmoothDamp(positionAct, positionPrec - cible.transform.right * distanceEntreSegments, ref velocite, tempsSegment * Time.deltaTime);
            
            position += transform.up * Mathf.Sin(Time.time * (vitesseOndulation)) * amplitudeOndulation ;
            position.z = cible.transform.position.z;

            lineRend.SetPosition(i, position);
        }
    }
}
