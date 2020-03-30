// OSC Jack - Open Sound Control plugin for Unity
// https://github.com/keijiro/OscJack

using UnityEngine;
using UnityEditor;
using DataType = OscJack.OscEventReceiver.DataType;

namespace OscJack
{
    [CanEditMultipleObjects, CustomEditor(typeof(OscEventReceiver))]
    class OscEventReceiverEditor : Editor
    {

        SerializedProperty intData;
        SerializedProperty floatData;
        SerializedProperty stringData;
        SerializedProperty vector2Data;
        SerializedProperty vector3Data;
        SerializedProperty vector4Data;
        SerializedProperty vector2IntData;
        SerializedProperty vector3IntData;

        SerializedProperty _udpPort;
        SerializedProperty _oscAddress;
        SerializedProperty _dataType;

        SerializedProperty _event;
        SerializedProperty _intEvent;
        SerializedProperty _floatEvent;
        SerializedProperty _stringEvent;
        SerializedProperty _vector2Event;
        SerializedProperty _vector3Event;
        SerializedProperty _vector4Event;
        SerializedProperty _vector2IntEvent;
        SerializedProperty _vector3IntEvent;

        static class Labels
        {
            public static readonly GUIContent UDPPortNumber = new GUIContent("UDP Port Number");
            public static readonly GUIContent OSCAddress = new GUIContent("OSC Address");
            public static readonly GUIContent intDataValue = new GUIContent("intData");
            public static readonly GUIContent floatDataValue = new GUIContent("floatData");
            public static readonly GUIContent stringDataValue = new GUIContent("stringData");
            public static readonly GUIContent vector2DataValue = new GUIContent("vector2Data");
            public static readonly GUIContent vector3DataValue = new GUIContent("vector3Data");
            public static readonly GUIContent vector4DataValue = new GUIContent("vector4Data");
            public static readonly GUIContent vector2IntDataValue = new GUIContent("vector2IntData");
            public static readonly GUIContent vector3IntDataValue = new GUIContent("vector3IntData");

        }

        void OnEnable()
        {
            intData = serializedObject.FindProperty("intData");
            floatData = serializedObject.FindProperty("floatData");
            stringData = serializedObject.FindProperty("stringData");
            vector2Data = serializedObject.FindProperty("vector2Data");
            vector3Data = serializedObject.FindProperty("vector3Data");
            vector4Data = serializedObject.FindProperty("vector4Data");
            vector2IntData = serializedObject.FindProperty("vector2IntData");
            vector3IntData = serializedObject.FindProperty("vector3IntData");


            _udpPort = serializedObject.FindProperty("_udpPort");
            _oscAddress = serializedObject.FindProperty("_oscAddress");
            _dataType = serializedObject.FindProperty("_dataType");

            _event           = serializedObject.FindProperty("_event");
            _intEvent        = serializedObject.FindProperty("_intEvent");
            _floatEvent      = serializedObject.FindProperty("_floatEvent");
            _stringEvent     = serializedObject.FindProperty("_stringEvent");
            _vector2Event    = serializedObject.FindProperty("_vector2Event");
            _vector3Event    = serializedObject.FindProperty("_vector3Event");
            _vector4Event    = serializedObject.FindProperty("_vector4Event");
            _vector2IntEvent = serializedObject.FindProperty("_vector2IntEvent");
            _vector3IntEvent = serializedObject.FindProperty("_vector3IntEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.DelayedIntField(_udpPort, Labels.UDPPortNumber);
            EditorGUILayout.DelayedTextField(_oscAddress, Labels.OSCAddress);

            EditorGUILayout.DelayedIntField(intData, Labels.intDataValue);
            EditorGUILayout.DelayedFloatField(floatData, Labels.floatDataValue);
            EditorGUILayout.DelayedTextField(stringData, Labels.stringDataValue);


            EditorGUILayout.PropertyField(_dataType);

            if (!_dataType.hasMultipleDifferentValues)
            {
                switch ((DataType)_dataType.enumValueIndex)
                {
                    case DataType.None:       EditorGUILayout.PropertyField(_event);           break;
                    case DataType.Int:        EditorGUILayout.PropertyField(_intEvent);        break;
                    case DataType.Float:      EditorGUILayout.PropertyField(_floatEvent);      break;
                    case DataType.String:     EditorGUILayout.PropertyField(_stringEvent);     break;
                    case DataType.Vector2:    EditorGUILayout.PropertyField(_vector2Event);    break;
                    case DataType.Vector3:    EditorGUILayout.PropertyField(_vector3Event);    break;
                    case DataType.Vector4:    EditorGUILayout.PropertyField(_vector4Event);    break;
                    case DataType.Vector2Int: EditorGUILayout.PropertyField(_vector2IntEvent); break;
                    case DataType.Vector3Int: EditorGUILayout.PropertyField(_vector3IntEvent); break;
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
