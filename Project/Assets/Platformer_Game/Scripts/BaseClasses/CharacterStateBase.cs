using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer_Game
{
    public class CharacterStateBase : StateMachineBehaviour
    {
        private CharacterController characterController;

        public CharacterController GetCharacterController(Animator animator)
        {
            if(characterController == null)
            {
                characterController = animator.GetComponentInParent<CharacterController>();
            }
            return characterController;
        }
    }

}
