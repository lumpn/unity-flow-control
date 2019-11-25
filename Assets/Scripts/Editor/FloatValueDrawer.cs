using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FloatValue))]
public class FloatValueDrawer : PropertyDrawer
{
    private const float valueWidth = 70;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var obj = property.objectReferenceValue;
        if (obj == null)
        {
            EditorGUI.PropertyField(position, property, GUIContent.none);
        }
        else
        {
            // Calculate rects
            var objectRect = new Rect(position.x, position.y, position.width - valueWidth, position.height);
            var valueRect = new Rect(position.x + position.width - valueWidth, position.y, valueWidth, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            var valueProperty = new SerializedObject(obj).FindProperty("value");
            EditorGUI.PropertyField(objectRect, property, GUIContent.none);
            EditorGUI.PropertyField(valueRect, valueProperty, GUIContent.none);
        }

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
