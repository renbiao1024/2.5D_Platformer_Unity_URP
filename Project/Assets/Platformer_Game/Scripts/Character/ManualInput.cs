using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer_Game
{
    public class ManualInput : MonoBehaviour
    {
        private CharacterControl characterControl;

        private void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }
        void Update()
        {
            var virtualInputMgrInst = VirtualInputManager.Instance;
            if (virtualInputMgrInst.MoveRight)
            {
                characterControl.MoveRight = true;
            }
            else
            {
                characterControl.MoveRight = false;
            }

            if(virtualInputMgrInst.MoveLeft)
            {
                characterControl.MoveLeft = true;
            }
            else
            {
                characterControl.MoveLeft = false;
            }

            if(virtualInputMgrInst.Jump)
            {
                characterControl.Jump = true;
            }
            else
            {
                characterControl.Jump = false;
            }

            if(virtualInputMgrInst.Attack)
            {
                characterControl.Attack = true;
            }
            else
            {
                characterControl.Attack = false;
            }
        }
    }


}
