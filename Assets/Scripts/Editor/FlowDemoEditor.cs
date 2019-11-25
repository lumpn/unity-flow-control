using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlowDemo))]
public class FlowDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var demo = (FlowDemo)target;

        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.FloatField("Buffer", demo.Count);
        EditorGUILayout.EndVertical();

        Repaint();
    }
}
