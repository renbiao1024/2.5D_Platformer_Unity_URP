using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Platformer_Game
{
    [CreateAssetMenu(fileName = "New State", menuName = "Platformer_Game/AbilityData/MoveRight")]
    public class MoveRight : StateData
    {
        public float Speed;
        public AnimationCurve speedCurve;
        public float BlockDistance;
        public bool constant;
        private CharacterControl characterControl;
        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterControl = characterState.GetCharacterControl(animator);
            if (characterControl.Jump)
            {
                animator.SetBool(TransitionParameter.Jump.ToString(), true);
            }

            if(constant)
            {
                ConstantMove(characterState, animator, stateInfo);
            }
            else
            {
                ControlledMove(characterState, animator, stateInfo);
            }
        }
        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
        }

        private void ControlledMove(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
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

            if (characterControl.MoveLeft)
            {
                characterControl.transform.rotation = Quaternion.Euler(0, -90, 0);
                if (!CheckFront())
                    characterControl.transform.Translate(Vector3.forward * Speed * speedCurve.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }

            if (characterControl.MoveRight)
            {
                characterControl.transform.rotation = Quaternion.Euler(0, 90, 0);
                if (!CheckFront())
                    characterControl.transform.Translate(Vector3.forward * Speed * speedCurve.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
            }
        }

        private void ConstantMove(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (!CheckFront())
                characterControl.transform.Translate(Vector3.forward * Speed * speedCurve.Evaluate(stateInfo.normalizedTime) * Time.deltaTime);
        }

        private bool CheckFront()
        {
            foreach (var sphere in characterControl.frontSphereLst)
            {
                Debug.DrawRay(sphere.transform.position, characterControl.transform.forward, Color.red);
                RaycastHit hit;
                if (Physics.Raycast(sphere.transform.position, characterControl.transform.forward, out hit, BlockDistance))
                {
                   if(IsBodyPart(hit.collider))
                        return true;
                }
            }
            return false;
        }

        private bool IsBodyPart(Collider collider)
        {
            CharacterControl control = collider.transform.root.GetComponent<CharacterControl>();
            if(control == null) 
                return false;
            if(control.gameObject == collider.gameObject) 
                return false;
            if (characterControl.RagdollLst.Contains(collider))
                return true;
            return false;
        }
    }
}
