using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sasha 
{
    [CreateAssetMenu(fileName = "AIController1", menuName = "InputController/AIController1")]

    public class AIController : InputController1
    {
        public override bool RetrieveJumpInput()
        {
            return true;
        }

        public override float RetrieveMoveInput()
        {
            return 1f;
        }

        public override bool RetrieveJumpHoldInput()
        {
            return false;
        }

    }
}

