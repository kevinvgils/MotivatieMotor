using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MenuProgress : MonoBehaviour
{
    public List<string> levelNames;
    public List<GameObject> levels;
    void Start()
    {
        LoadLevelProgress();
    }

    void LoadLevelProgress()
    {
        int i = 0;
        foreach (string levelName in levelNames)
        {
            bool isCompleted = ProgressManager.IsLevelCompleted(levelName);
            if(isCompleted) {
                GameObject objectL = levels[i];
                Image image = objectL.GetComponentInChildren<Image>(true);
                Debug.Log(image.name);
                image.gameObject.SetActive(true);
            }
            i++;
        }
    }
}
