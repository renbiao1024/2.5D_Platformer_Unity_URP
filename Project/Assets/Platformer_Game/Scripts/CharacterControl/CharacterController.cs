using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    public class CharacterController : MonoBehaviour
    {
        public float speed;
        [SerializeField] Material material;
        public enum TransitionParameter
        {
            Move,
        }

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
