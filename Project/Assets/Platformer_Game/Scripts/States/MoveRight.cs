using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer_Game
{
    [CreateAssetMenu(fileName = "New State", menuName = "Platformer_Game/AbilityData/MoveRight")]
    public class MoveRight : StateData
    {
        public float Speed;
        public AnimationCurve speedCurve;
        public float BlockDistance;
        private CharacterControl characterControl;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl = characterState.GetCharacterControl(animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

            if(characterControl.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if (characterControl.MoveLeft && characterControl.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!characterControl.MoveLeft && !characterControl.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (characterControl.MoveLeft && !CheckFront())
            {
                characterControl.transform.rotation = Quaternion.Euler(0, -90, 0);
                characterControl.transform.Translate(Vector3.forward * Speed * speedCurve.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }

            if (characterControl.MoveRight && !CheckFront())
            {
                characterControl.transform.rotation = Quaternion.Euler(0, 90, 0);
                characterControl.transform.Translate(Vector3.forward * Speed * speedCurve.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        private bool CheckFront()
        {
            foreach (var sphere in characterControl.frontSphereLst)
            {
                Debug.DrawRay(sphere.transform.position, characterControl.transform.forward, Color.red);
                RaycastHit hit;
                if (Physics.Raycast(sphere.transform.position, characterControl.transform.forward, out hit, BlockDistance))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
