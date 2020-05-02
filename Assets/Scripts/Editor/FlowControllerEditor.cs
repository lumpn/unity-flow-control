using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FlowController))]
public class FlowControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var controller = (FlowController)target;

        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUILayout.FloatField("Smooth In", controller.smoothIn);
        EditorGUILayout.FloatField("Smooth Buffer", controller.smoothBuffer);
        EditorGUILayout.FloatField("Velocity In", controller.velIn);
        EditorGUILayout.FloatField("Velocity Buffer", controller.velBuffer);
        EditorGUILayout.EndVertical();
    }
}
