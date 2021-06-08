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

    public string NewDialogueFile;
    public int WhenToShowNewDialogue;
    public bool ChoosingDialogue;

    public string[] ToBeReplaced;
}

public class JsonReader : MonoBehaviour
{
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

    public static JsonNpc LoadNpcFromFile(TextAsset jsonFile)
    {
        Assert.IsNotNull(jsonFile);

        JsonNpc testNPCList = JsonUtility.FromJson<JsonNpc>(jsonFile.text);

        return testNPCList;
    }
}