using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[Serializable]
public class JsonNpc
{
    public string Name;

    public string[] Dialogue;

    public string[] PlayerDialogue;

    public string[] ExtraDialogue;
    public int WhenToShowNewDialogue;
    public bool ChoosingDialogue;

    public string[] ToBeReplaced;
}

public class JsonReader : MonoBehaviour
{
    //=================== Set from Unity editor =======================
    // file to read npc from
    public TextAsset jsonFile;
    public static JsonNpc NPC;


    void Awake()
    {
        //jsonFile = GameObject.FindGameObjectWithTag("NPC").GetComponent<DialogueManager>().Npc.NpcDialogue;
    }

    //=================== MonoBehavior interface =======================
    void Start()
    {
        NPC = LoadNpcFromFile();
    }

    //======================= public API =================================


    // create one instance of the TrialController for the app
    private static JsonReader jsonReader;
    public static JsonReader Instance()
    {
        if (!jsonReader)
        {
            jsonReader = FindObjectOfType(typeof(JsonReader)) as JsonReader;

            if (!jsonReader)
            {
                Debug.LogError("JsonReader inactive or missing from unity scene.");
            }
        }

        return jsonReader;
    }

    private JsonNpc LoadNpcFromFile()
    {
        Assert.IsNotNull(jsonFile);

        JsonNpc testNPCList = JsonUtility.FromJson<JsonNpc>(jsonFile.text);

        return testNPCList;
    }
}