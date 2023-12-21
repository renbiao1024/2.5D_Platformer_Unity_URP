using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer_Game
{
    public class KeyboardInput : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            var virtualMgrInst = VirtualInputManager.Instance;
            if (Input.GetKey(KeyCode.W))
            {
                virtualMgrInst.MoveFwd = true;
            }
            else
            {
                virtualMgrInst.MoveFwd = false;
            }

            if (Input.GetKey(KeyCode.S))
            {
                virtualMgrInst.MoveBwd = true;
            }
            else
            {
                virtualMgrInst.MoveBwd = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                virtualMgrInst.MoveLeft = true;
            }
            else
            {
                virtualMgrInst.MoveLeft = false;
            }

            if (Input.GetKey(KeyCode.D))
            {
                virtualMgrInst.MoveRight = true;
            }
            else
            {
                virtualMgrInst.MoveRight = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                virtualMgrInst.Jump = true;
            }
            else
            {
                virtualMgrInst.Jump = false;
            }
        }
    }
}

