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
    public override IEnumerator Idle()
    {
        //Idle state is the same as doing nothing. Which in some cases is also considered to something you can do.

        yield break;
    }
    public override IEnumerator Follow()
    {
        //Rotating with the object its following.
        _system.transform.LookAt(_system.Player.transform);

        //Following the position of the player.
        _system.transform.Translate(Vector3.forward * Time.deltaTime * 5f);

        yield break;
    }
    public override IEnumerator Return()
    {
        //Rotating to the starting position.
        _system.transform.LookAt(_system.StartPos);

        //Walking back to the starting position.
        _system.transform.Translate(Vector3.forward * Time.deltaTime * 5f);
        _system.transform.rotation = _system.StartAngle;

        yield break;
    }
    public override IEnumerator Interact()
    {
        if (_system.InteractionPossible == true)
        {
            _system.InteractText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && _system.IsInteracting == false)
            {
                _system.IsInteracting = true;
                _system.DialogueManager.StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && _system.IsInteracting == true)
            {
                _system.DialogueManager.EndDialogue();
                _system.IsInteracting = false;
            }
        }
        else
        {
            _system.DialogueManager.EndDialogue();
            _system.IsInteracting = false;
            _system.InteractText.SetActive(true);
        }
        yield break;
    }
    public override IEnumerator Unavailable()
    {
        _system.DialogueManager.EndDialogue();
        _system.IsInteracting = false;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interaction is not possible at the moment");
        }
        yield break;
    }

}
