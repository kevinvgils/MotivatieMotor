using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    [TextArea(2, 10)]
    public string question;
    public Answer[] possibleAnswers;

    public DialogueTrigger nextDialogue;
}