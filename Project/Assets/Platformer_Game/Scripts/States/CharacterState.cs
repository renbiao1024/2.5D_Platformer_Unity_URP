using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer_Game
{
    public class CharacterState : StateMachineBehaviour
    {
        private CharacterControl characterControl;
        public List<StateData> ListAbilityData = new List<StateData>();


        public CharacterControl GetCharacterControl(Animator animator)
        {
            if(characterControl == null)
            {
                characterControl = animator.GetComponentInParent<CharacterControl>();
            }
            return characterControl;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator);
        }

        public void UpdateAll(CharacterState characterState, Animator animator) 
        { 
            foreach(var stateData in ListAbilityData)
            {
                stateData.UpdateAbility(characterState, animator);
            }
        }
    }

}
