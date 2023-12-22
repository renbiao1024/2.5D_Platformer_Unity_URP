using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    [CreateAssetMenu(fileName = "New State", menuName = "Platformer_Game/AbilityData/GroundDetector")]
    public class GroundDetector : StateData
    {
        public float Distance;
        [Range(0.01f, 1f)]
        public float CheckTime;
        private CharacterControl characterControl;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl = characterState.GetCharacterControl(animator);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= CheckTime)
            {
                if(IsGrounded())
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), true);
                }
                else
                {
                    animator.SetBool(TransitionParameter.Grounded.ToString(), false);
                }
            }

        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {

        }

        private bool IsGrounded()
        {
            var velocityY = characterControl.RB.velocity.y;
            if (velocityY > -0.001f && velocityY <= 0)
                return true;

            if(velocityY < 0f)
            {
                foreach (var sphere in characterControl.bottomSphereLst)
                {
                    Debug.DrawRay(sphere.transform.position, Vector3.down, Color.red);

                    RaycastHit hit;
                    if (Physics.Raycast(sphere.transform.position, Vector3.down, out hit, Distance))
                    {
                        if(hit.rigidbody != characterControl.RB)
                            return true;
                    }
                }
            }

            return false;
        }
    }

}
