using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Made by: Jorrit Bos
public class AIBehaviours : State
{
    public AIBehaviours(AISystem system) : base(system)
    {

    }

    //public override IEnumerator Wander()
    //{

    //    if (_system.NeedsDestination())
    //    {
    //        _system.GetDestination();
    //    }

    //    _system.transform.rotation = _system._desiredRotation;

    //    var rayColor = _system.IsPathBlocked() ? Color.red : Color.green;
    //    Debug.DrawRay(_system.transform.position, _system._direction * _system._rayDistance, rayColor);

    //    _system.transform.Translate(Vector3.forward * Time.deltaTime * _system.wanderSpeed);

    //    while (_system.IsPathBlocked())
    //    {
    //        _system.GetDestination();
    //    }
    //    yield break;
    //}

    public override IEnumerator Idle()
    {
        //Idle is not yet doing anything

        yield break;
    }

    public override IEnumerator Follow()
    {
        //Rotating with the object its following
        _system.transform.LookAt(_system.ObjectToFollow.transform);

        //Following, but it's commented for now.
        //_system.transform.Translate(Vector3.forward * Time.deltaTime * 5f);

        yield break;
    }

    private bool _isInteracting = false;
    public override IEnumerator Interact()
    {
        _system.InteractText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E) && _isInteracting == false)
        {
            _system.DialogueManager.StartConversation();
            _isInteracting = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && _isInteracting == true)
        {
            _system.DialogueManager.EndDialogue();
            _isInteracting = false;
        }
        yield break;
    }

    public override IEnumerator Unavailable()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction is not possible at the moment");
        }
        yield break;
    }

}
