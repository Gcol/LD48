using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Nivo))]
public class NivoEditor : Editor
{
    

    public override void OnInspectorGUI()
    {
        Nivo nivo = target as Nivo;
        base.OnInspectorGUI();

        if(GUILayout.Button("Génerer Nivo"))
        {
            nivo.InitSections();
        }
    }
}
