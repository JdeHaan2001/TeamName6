using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by: Jorrit Bos
public abstract class State
{
    protected readonly AISystem _system;
    public State(AISystem system)
    {
        _system = system;
    }
    public virtual IEnumerator Idle()
    {
        yield break;
    }
    public virtual IEnumerator Follow()
    {
        yield break;
    }
    public virtual IEnumerator Return()
    {
        yield break;
    }
    public virtual IEnumerator Interact()
    {
        yield break;
    }
}
