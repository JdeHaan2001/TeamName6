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

        //if (_system.IsInteracting == true)
        //{
        //    _system.DialogueManager.EndDialogue();
        //}

        yield break;
    }
    public override IEnumerator Follow()
    {

        //Rotates with the object which is being followed
        var lookPos = _system.Player.transform.position - _system.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        _system.transform.rotation = Quaternion.Slerp(_system.transform.rotation, rotation, Time.deltaTime * 5f);

        //Moves the NPC to the position of the player
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
        if (Input.GetKeyDown(KeyCode.E) && _system.IsInteracting == false)
        {
            _system.IsInteracting = true;
            _system.DialogueManager.StartConversation();
        }
        else if (Input.GetKeyDown(KeyCode.E) && _system.IsInteracting == true)
        {
            _system.DialogueManager.EndDialogue();
            _system.IsInteracting = false;
            
            if(_system.QuestKeeper.Quest != null)
            {
                if(_system.QuestKeeper.Quest.Goal.goalType == GoalType.Talking)
                {
                    _system.QuestKeeper.UpdateQuest();
                }
            }
        }
        yield break;
    }
}
