using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sentence[] sentences;
    public QuestionTrigger questionForDialogue;
}