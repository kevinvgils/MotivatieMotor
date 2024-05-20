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
        Dictionary<int, int> pointSums = new();
        pointSums.Add(0, 0);
        pointSums.Add(1, 0);
        pointSums.Add(2, 0);
        pointSums.Add(3, 0);
        pointSums.Add(4, 0);


        // Populate answerEntries and calculate points
        foreach (var kvp in answers)
        {
            answerEntries.Add(new AnswerEntry { key = kvp.Key, value = kvp.Value });

            // Aggregate points by motivation type
            if (!pointSums.ContainsKey((int)kvp.Value.motType))
            {
                pointSums[(int)kvp.Value.motType] = 0;
            }
            pointSums[(int)kvp.Value.motType] += kvp.Value.coinAmount;
        }

        // Convert pointSums dictionary to pointTotal list
        List<PointEntry> pointTotal = new();
        foreach (var kvp in pointSums)
        {
            pointTotal.Add(new PointEntry { key = (MotivationType)kvp.Key, value = kvp.Value });
        }

        LevelAnswers levelData = new()
        {
            levelName = levelName,
            pointTotal =pointTotal,
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
