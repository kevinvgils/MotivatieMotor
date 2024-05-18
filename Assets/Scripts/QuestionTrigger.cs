using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionTrigger : MonoBehaviour
{
    public Question question;
    public int nextStudent;

    public void TriggerQuestion() {
        FindObjectOfType<QuestionManager>().StartQuestion(question, nextStudent);
    }
}
