using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    [TextArea(2, 10)]
    public string question;
    [TextArea(3, 10)]
    public string[] possibleAnswers;

    public DialogueTrigger nextDialogue;
}