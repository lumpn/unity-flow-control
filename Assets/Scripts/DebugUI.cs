using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    [SerializeField] private IntValue[] ints;
    [SerializeField] private FloatValue[] floats;

    void OnGUI()
    {
        GUILayout.BeginVertical(GUI.skin.box);

        foreach (var v in ints)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(v.name, GUILayout.Width(100));
            GUILayout.TextField(v.value.ToString(), GUILayout.Width(50));
            GUILayout.EndHorizontal();
        }

        foreach (var v in floats)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(v.name, GUILayout.Width(100));
            GUILayout.TextField(v.value.ToString(), GUILayout.Width(50));
            GUILayout.EndHorizontal();
        }

        GUILayout.EndVertical();
    }
}
