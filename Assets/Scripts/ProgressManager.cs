using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    // Method to save user answers for a level
    public static void SaveLevelAnswers(string levelName, Dictionary<string, Answer> answers)
    {
        List<AnswerEntry> answerEntries = new();
        foreach (var kvp in answers)
        {
            answerEntries.Add(new AnswerEntry { key = kvp.Key, value = kvp.Value });
        }

        LevelAnswers levelData = new()
        {
            levelName = levelName,
            answers = answerEntries
        };

        string jsonData = JsonUtility.ToJson(levelData);
        string filePath = Application.persistentDataPath + "/" + levelName + ".json";
        Debug.Log(filePath);
        Debug.Log(jsonData);
        File.WriteAllText(filePath, jsonData);
    }

    // Method to load user answers for a level
    public static LevelAnswers LoadLevelAnswers(string levelName)
    {
        string filePath = Application.persistentDataPath + "/" + levelName + ".json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            LevelAnswers levelData = JsonUtility.FromJson<LevelAnswers>(jsonData);
            Debug.Log(levelData.levelName);
            Debug.Log(levelData.answers);
                        Debug.Log(levelData.answers.Count);

            return levelData;
        }
        else
        {
            Debug.LogWarning("No saved answers found for level: " + levelName);
            return null;
        }
    }

    public static bool IsLevelCompleted(string levelName)
    {
        LevelAnswers levelAnswers = LoadLevelAnswers(levelName);
        return levelAnswers != null && levelAnswers.answers != null && levelAnswers.answers.Count > 0;
    }
}
