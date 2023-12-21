using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    [CreateAssetMenu(fileName = "New State", menuName = "Platformer_Game/AbilityData/MoveRight")]
    public class MoveRight : StateData
    {
        public float Speed;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            var control = characterState.GetCharacterControl(animator);
            if (control.MoveLeft && control.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!control.MoveLeft && !control.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (control.MoveLeft)
            {
                control.transform.rotation = Quaternion.Euler(0, -90, 0);
                control.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                return;
            }

            if (control.MoveRight)
            {
                control.transform.rotation = Quaternion.Euler(0, 90, 0);
                control.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                return;
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }
    }
}
