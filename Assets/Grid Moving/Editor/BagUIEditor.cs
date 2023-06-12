using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BagUI))]
public class BagUIEditor : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        BagUI bagUI = (BagUI)target;
    }
}
