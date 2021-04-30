using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by: Jorrit Bos
public class BeginState : State
{
    public BeginState(AISystem system) : base(system)
    {

    }

    public override IEnumerator Start()
    {
        //Debug.Log("AI is looking what to do...");

        yield return new WaitForSeconds(1f);

        _system.SetState(new AIBehaviours(_system));

    }
}
