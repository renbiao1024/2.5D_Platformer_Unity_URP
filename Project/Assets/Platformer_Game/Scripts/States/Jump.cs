using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    [CreateAssetMenu(fileName = "New State", menuName = "Platformer_Game/AbilityData/Jump")]
    public class Jump : StateData
    {
        public float JumpForce;
        public AnimationCurve Gravity;
        public AnimationCurve Pull;

        CharacterControl control;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.GetCharacterControl(animator).GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
            animator.SetBool(TransitionParameter.Grounded.ToString(), false);
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            control = characterState.GetCharacterControl(animator);
            control.GravityMultiplier = Gravity.Evaluate(stateInfo.normalizedTime);
            control.PullMultiplier = Pull.Evaluate(stateInfo.normalizedTime);
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            
        }
    }

}
