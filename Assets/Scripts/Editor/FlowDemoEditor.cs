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
        EditorGUILayout.FloatField("Min Latency", demo.minLatency);
        EditorGUILayout.FloatField("Max Latency", demo.maxLatency);
        EditorGUILayout.FloatField("Avg Latency", demo.avgLatency);

        if (GUILayout.Button("Add 10")) demo.Add(10);
        if (GUILayout.Button("Add 100")) demo.Add(100);
        if (GUILayout.Button("Add 500")) demo.Add(500);

        EditorGUILayout.EndVertical();

        Repaint();
    }
}
