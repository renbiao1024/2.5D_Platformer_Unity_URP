using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer_Game.CharacterController;

namespace Platformer_Game
{
    public class PlayerWalk : CharacterStateBase
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            var virtualInputMgr = VirtualInputManager.Instance;
            var controller = GetCharacterController(animator);
            if (virtualInputMgr.MoveLeft && virtualInputMgr.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (!virtualInputMgr.MoveLeft && !virtualInputMgr.MoveRight)
            {
                animator.SetBool(TransitionParameter.Move.ToString(), false);
                return;
            }

            if (virtualInputMgr.MoveLeft)
            {
                controller.transform.rotation = Quaternion.Euler(0, -90, 0);
                controller.transform.Translate(Vector3.forward * controller.speed * Time.deltaTime);
                return;
            }

            if (virtualInputMgr.MoveRight)
            {
                controller.transform.rotation = Quaternion.Euler(0, 90, 0);
                controller.transform.Translate(Vector3.forward * controller.speed * Time.deltaTime);
                return;
            }
        }

        //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }

}
