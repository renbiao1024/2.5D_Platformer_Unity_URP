using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer_Game
{

    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        public bool MoveRight;
        public bool MoveFwd;
        public bool MoveBwd;
        public bool MoveLeft;
        public bool Jump;
    }
}