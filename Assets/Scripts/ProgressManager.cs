using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
        // Method to save user answers for a level
    public static void SaveLevelAnswers(string levelName, Answer[] answers)
    {
        LevelAnswers levelData = new()
        {
            levelName = levelName,
            answers = answers
        };

        string jsonData = JsonUtility.ToJson(levelData);
        string filePath = Application.persistentDataPath + "/" + levelName + ".json";
        Debug.Log(filePath);
        File.WriteAllText(filePath, jsonData);
    }

    // Method to load user answers for a level
    public static Answer[] LoadLevelAnswers(string levelName)
    {
        string filePath = Application.persistentDataPath + "/" + levelName + ".json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            LevelAnswers levelData = JsonUtility.FromJson<LevelAnswers>(jsonData);
            return levelData.answers;
        }
        else
        {
            Debug.LogWarning("No saved answers found for level: " + levelName);
            return null;
        }
    }
}
