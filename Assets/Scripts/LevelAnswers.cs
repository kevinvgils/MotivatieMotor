using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelAnswers
{
    public string levelName;
    public List<PointEntry> pointTotal;

    public List<AnswerEntry> answers;
}