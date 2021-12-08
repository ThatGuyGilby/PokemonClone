using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RuntimeMonsterMove))]
public class RuntimeMovePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(_position, _label, _property);

        // Draw label
        _position = EditorGUI.PrefixLabel(_position, GUIUtility.GetControlID(FocusType.Passive), GUIContent.none);

        // Don't make child fields be indented
        int _indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        Rect _usesRect = new Rect(_position.x, _position.y, 30, _position.height);
        Rect _maxUsesRect = new Rect(_position.x + 35, _position.y, 30, _position.height);
        Rect _finalValueRect = new Rect(_position.x + 80, _position.y, 200, _position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(_usesRect, _property.FindPropertyRelative("uses"), GUIContent.none);

        EditorGUI.PropertyField(_maxUsesRect, _property.FindPropertyRelative("maxUses"), GUIContent.none);

        EditorGUI.PropertyField(_finalValueRect, _property.FindPropertyRelative("move"), GUIContent.none);
        //EditorGUI.LabelField(_usesRect, new GUIContent("", "Base Value")); // <-- Displays tooltip

        // Set indent back to what it was
        EditorGUI.indentLevel = _indent;

        EditorGUI.EndProperty();
    }
}
