using MonoBehaviours;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(InventoryScript))]
    public class InventoryEditor : UnityEditor.Editor
    {
        private readonly bool[] _showItemSlots = new bool[InventoryScript.NumItemSlots];
        private SerializedProperty _itemImagesProperty;
        private SerializedProperty _itemsProperty;
        private const string InventoryPropItemImagesName = "itemImages";
        private const string InventoryPropItemsName = "items";
        private void OnEnable()
        {
            _itemImagesProperty = serializedObject.FindProperty(InventoryPropItemImagesName);
            _itemsProperty = serializedObject.FindProperty(InventoryPropItemsName);
        }
    
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            for (var i = 0; i < InventoryScript.NumItemSlots; i++)
                ItemSlotGUI(i);
            serializedObject.ApplyModifiedProperties();
        }
    
        private void ItemSlotGUI(int index)
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUI.indentLevel++;

            _showItemSlots[index] = EditorGUILayout.Foldout(_showItemSlots[index], "Item slot " + index);
            if (_showItemSlots[index])
            {
                EditorGUILayout.PropertyField(_itemImagesProperty.GetArrayElementAtIndex(index));
                EditorGUILayout.PropertyField(_itemsProperty.GetArrayElementAtIndex(index));
            }
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }
    }
}