using UnityEditor;
using UnityEngine;
using Showroom.Datas;

namespace Showroom.Datas.Editors
{
    [CustomEditor(typeof(CharacterData))]
    public class CharacterDataEditor : Editor
    {

     
        public override void OnInspectorGUI()
        {

            CharacterData PlayerData = (CharacterData)target;
            string[] tagStr = UnityEditorInternal.InternalEditorUtility.tags;
            int tagIndex = 0;
            base.OnInspectorGUI();
           
            EditorUtility.SetDirty(target);
        }
    
    }
}
