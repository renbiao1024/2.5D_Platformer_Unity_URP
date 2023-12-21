using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    public enum TransitionParameter
    {
        Move,
        Jump,
        ForceTransition,
    }
    public class CharacterControl : MonoBehaviour
    {
        public float speed;
        [SerializeField] Material material;
        public bool MoveRight;
        public bool MoveLeft;
        public bool Jump;

        public void ChangeMaterial()
        {
            if(material == null)
            {
                Debug.LogError("no material specified");
                return;
            }

            Renderer[] arrMaterial = gameObject.GetComponentsInChildren<Renderer>();

            foreach(var  renderer in arrMaterial)
            {
                renderer.material = material;
            }
        }
    }

}
