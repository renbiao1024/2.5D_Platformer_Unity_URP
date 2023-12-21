using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;

namespace Platformer_Game
{
    [CustomEditor(typeof(CharacterController))]
    public class MaterialChanger : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CharacterControl controller = (CharacterControl)target;
            if(GUILayout.Button("Change Material"))
            {
                controller.ChangeMaterial();
            }
        }
    }

}
