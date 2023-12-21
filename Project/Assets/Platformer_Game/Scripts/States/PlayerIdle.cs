using Platformer_Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer_Game.CharacterController;

public class PlayerIdle : CharacterStateBase
{
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var virtualInputMgr = VirtualInputManager.Instance;
        if (virtualInputMgr.MoveLeft && virtualInputMgr.MoveRight)
        {
            return;
        }

        if (!virtualInputMgr.MoveLeft && !virtualInputMgr.MoveRight)
        {
            return;
        }

        if (virtualInputMgr.MoveLeft)
        {
            animator.SetBool(TransitionParameter.Move.ToString(), true);
            return;
        }

        if (virtualInputMgr.MoveRight)
        {
            animator.SetBool(TransitionParameter.Move.ToString(), true);
            return;
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
