using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    private List<string> givenAnswers = new();

    public TMP_Text questionText;
    public Button[] answerButtons;
    private DialogueTrigger dialogueTrigger;

    public Animator animator;

    public void StartQuestion(Question question) {
        animator.SetBool("QisOpen", true);

        questionText.text = question.question;
        dialogueTrigger = question.nextDialogue;

        int i = 0;
        foreach(Button button in answerButtons) {
            button.GetComponentInChildren<TMP_Text>().text = question.possibleAnswers[i];
            i++;
        }
    }

    public void EndQuestion(string givenAnswer) {
        givenAnswers.Add(givenAnswer);
        Debug.Log("Gegeven antwoorden:");
        foreach(string answer in givenAnswers) {
            Debug.Log(answer);
        }
        animator.SetBool("QisOpen", false);
        if(dialogueTrigger) dialogueTrigger.TriggerDialogue();
    }
}
