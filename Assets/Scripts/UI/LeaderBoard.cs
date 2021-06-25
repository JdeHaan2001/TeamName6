//Made by Jeroen de Haan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Linq;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _scoreTemplate = null;
    [SerializeField] private List<TextMeshProUGUI> _names = null;

    [SerializeField] private TextMeshProUGUI _scoreText = null;

    private QuestKeeper _questGetter = null;

    private int _score;
    private string _name;

    private List<int> line = new List<int>();
    private List<string> namesLine = new List<string>();

    private Dictionary<string, int> lines = new Dictionary<string, int>();
    private Dictionary<string, int> templines = new Dictionary<string, int>();

    private void Awake()
    {
        _questGetter = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
        _score = _questGetter.Moral;
        _name = PlayerPrefs.GetString("playerName", "Gast");
    }

    private void Start()
    {
        readFile();
        _scoreText.text = _score.ToString();
        Debug.Log(_score);
    }

    private void readFile()
    {
        StreamReader reader = new StreamReader($"{Application.dataPath}/StreamingAssets/LeaderBoard.txt");

        string scoreString = reader.ReadLine();
        int scoreText = scoreString != null ? int.Parse(scoreString) : -1;
        string nameText = reader.ReadLine();
        while (nameText != null)
        {
            lines.Add(nameText, scoreText);
            Debug.Log($"Read and added name: {nameText} and score: {scoreText} to dictionary\n Dictionary count: {lines.Count}");

            string tempScoreText = reader.ReadLine();
            scoreText = tempScoreText != null ? int.Parse(tempScoreText) : -1;

            nameText = reader.ReadLine();
        }
        reader.Close();

        StreamWriter writer = new StreamWriter($"{Application.dataPath}/LeaderBoard.txt");

        if (!lines.ContainsKey(_name))
            lines.Add(_name, _score);
        else
        {
            lines[_name] = _score;
        }

        Debug.Log($"Added name: {_name} and score: {_score} to dictionary\n Dictionary count: {lines.Count}");

        var sortedDict = from entry in lines orderby entry.Value descending select entry;

        int counter = 0;

        foreach (KeyValuePair<string, int> dict in lines.OrderByDescending(key => key.Value))
        {
            writer.WriteLine(dict.Value);
            writer.WriteLine(dict.Key);

            _scoreTemplate[counter].text = dict.Value.ToString();
            _names[counter].text = dict.Key;

            counter++;
        }

        if (lines.Count < 10)//20 because there are 10 scores and 10 names in the text file
        {
            for (int i = lines.Count; i < 10; i++)
            {
                _scoreTemplate[i].transform.parent.gameObject.SetActive(false);
            }
        }

        writer.Close();
    }
}
