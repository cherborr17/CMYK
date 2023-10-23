using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sasha 
{
    [CreateAssetMenu(fileName = "PlayerController1", menuName = "InputController/PlayerController1")]

    public class PlayerController1 : InputController1
    {
        public override bool RetrieveJumpInput()
        {
            return Input.GetButtonDown("Jump");
        }

        public override float RetrieveMoveInput()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public override bool RetrieveJumpHoldInput()
        {
            return Input.GetButtonDown("Jump");
        }
    }
}

