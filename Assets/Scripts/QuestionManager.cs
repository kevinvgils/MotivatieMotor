using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    private List<Answer> givenAnswers = new();

    public ScoreManager scoreManager;
    public TMP_Text questionText;
    public Button[] answerButtons;
    private DialogueTrigger dialogueTrigger;
    private Question currentQuestion;

    public Animator animator;

    public void StartQuestion(Question question) {
        animator.SetBool("QisOpen", true);

        questionText.text = question.question;
        dialogueTrigger = question.nextDialogue;

        currentQuestion = question;
        int i = 0;
        foreach(Button button in answerButtons) {
            button.GetComponentInChildren<TMP_Text>().text = question.possibleAnswers[i].answer;
            i++;
        }
    }

    public void EndQuestion(int index) {
        animator.SetBool("QisOpen", false);
        Answer givenAnswer = currentQuestion.possibleAnswers[index];
        givenAnswers.Add(givenAnswer);
        scoreManager.AddToScore(givenAnswer);
        if(dialogueTrigger) { 
            dialogueTrigger.TriggerDialogue();
        } else {
            ProgressManager.SaveLevelAnswers(SceneManager.GetActiveScene().name, givenAnswers.ToArray());
            SceneManager.LoadScene("MainMenu");
        };
    }
}
