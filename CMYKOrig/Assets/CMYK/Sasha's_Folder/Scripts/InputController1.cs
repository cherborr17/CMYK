using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController1 : ScriptableObject
{
    public abstract float RetrieveMoveInput();

    public abstract bool RetrieveJumpInput();

    public abstract bool RetrieveJumpHoldInput();
}
