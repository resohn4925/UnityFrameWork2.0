using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void OnEnter(Player_Fox playerFox);

    public abstract void OnUpdate(Player_Fox playerFox);

    public abstract void OnExit(Player_Fox playerFox);
}
