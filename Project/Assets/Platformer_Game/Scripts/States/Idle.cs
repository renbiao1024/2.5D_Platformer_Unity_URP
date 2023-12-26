using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    [CreateAssetMenu(fileName = "New State", menuName = "Platformer_Game/AbilityData/Idle")]
    public class Idle : StateData
    {
        CharacterControl control;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Jump.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            if (control.Attack)
            {
                animator.SetBool(TransitionParameter.Attack.ToString(), true);
            }

            if (control.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (control.MoveLeft && control.MoveRight)
            {
                return;
            }

            if (!control.MoveLeft && !control.MoveRight)
            {
                return;
            }

            if (control.MoveLeft)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }

            if (control.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), true);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }
    }

}
