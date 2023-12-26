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


        public CharacterControl GetCharacterControl(Animator animator) //when enter a new state, animator might be null, so this should be used in update function.
        {
            if(characterControl == null)
            {
                characterControl = animator.GetComponentInParent<CharacterControl>();
                //Debug.LogWarning("characterControl is " + characterControl);
            }
            return characterControl;
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var stateData in ListAbilityData)
            {
                stateData.OnEnter(this, animator, stateInfo);
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(this, animator, stateInfo);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var stateData in ListAbilityData)
            {
                stateData.OnExit(this, animator, stateInfo);
            }
        }

        public void UpdateAll(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo) 
        { 
            foreach(var stateData in ListAbilityData)
            {
                stateData.UpdateAbility(characterState, animator, stateInfo);
            }
        }
    }
}
