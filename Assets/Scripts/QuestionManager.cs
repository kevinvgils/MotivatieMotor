using System;
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
    private readonly Dictionary<string, Answer> givenAnswers = new();

    public ScoreManager scoreManager;
    public TMP_Text questionText;
    public TMP_Text timerText;
    public TMP_Text pointText;
    public Image coinImage;
    public Sprite[] coinImages;
    public Slider timerSlider; // Reference to the Slider component for the timer bar
    public Gradient timerGradient;
    public Image timerImage;
    public Button[] answerButtons;
    private Question currentQuestion;
    public float timeLimit = 30f;  // Set your desired time limit here
    private Coroutine timerCoroutine;
    private int nextStudent;
    public Animator animator;
    public void Start() {
        timerSlider.onValueChanged.AddListener(OnSliderValueChanged);
        OnSliderValueChanged(timerSlider.value);
    }

    private void OnSliderValueChanged(float value)
    {
        timerImage.color = timerGradient.Evaluate(value / timerSlider.maxValue);
    }

    public void StartQuestion(Question question, int nextStudentI) {
        nextStudent = nextStudentI;
        animator.SetBool("QisOpen", true);

        questionText.text = question.question;

        currentQuestion = question;
        int i = 0;
        foreach(Button button in answerButtons) {
            button.GetComponentInChildren<TMP_Text>().text = question.possibleAnswers[i].answer;
            i++;
        }

        if (timerCoroutine != null) {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(QuestionTimer());
    }

    public void EndQuestion(int index)
    {
        // Start the coroutine to handle the delay
        StartCoroutine(EndQuestionWithDelay(index));
    }

    private IEnumerator EndQuestionWithDelay(int index)
    {
        Answer givenAnswer = currentQuestion.possibleAnswers[index];
        givenAnswers.Add(currentQuestion.question, givenAnswer);
        scoreManager.AddToScore(givenAnswer);

        pointText.text = givenAnswer.coinAmount.ToString();
        Debug.Log(givenAnswer.motType);
        coinImage.sprite = coinImages[(int)givenAnswer.motType];
        animator.SetBool("ShowPoints", true);
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        // Wait for 4 seconds
        yield return new WaitForSeconds(4);

        animator.SetBool("QisOpen", false);

        yield return new WaitForSeconds(2);

        animator.SetBool("ShowPoints", false);
        if (nextStudent != -1)
        {
            FindObjectOfType<StudentHandRaiseHandler>().RaiseHand(nextStudent);
        }
        else
        {
            ProgressManager.SaveLevelAnswers(SceneManager.GetActiveScene().name, givenAnswers);
            SceneManager.LoadScene("MainMenu");
        }
    }

    private IEnumerator QuestionTimer() {
        float timeRemaining = timeLimit;

        // Initialize the timer slider
        timerSlider.maxValue = timeLimit;
        timerSlider.value = timeRemaining;

        while (timeRemaining > 0) {
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;

            // Update the timer text if needed
            timerText.text = "Tijd om te antwoorden: " + timeRemaining.ToString("F0");

            // Update the slider value
            timerSlider.value = timeRemaining;
        }

        // Time's up! Handle the timeout scenario
        StartCoroutine(HandleTimeout());
    }

    private IEnumerator HandleTimeout() {
        pointText.text = "0";
        coinImage.sprite = coinImages[5];
        // For example, you can end the question with a default answer or just trigger the dialogue

        // Assuming you want to end the question with no answer selected
        animator.SetBool("ShowPoints", true);

        yield return new WaitForSeconds(4);

        animator.SetBool("ShowPoints", false);

        yield return new WaitForSeconds(2);

        animator.SetBool("QisOpen", false);

        // Optionally, add a default answer if needed
        // givenAnswers.Add(new Answer { answer = "No answer", isCorrect = false });

        // Or just proceed to the next dialogue or scene
        if (nextStudent != -1)
        {
            FindObjectOfType<StudentHandRaiseHandler>().RaiseHand(nextStudent);
        } else {
            ProgressManager.SaveLevelAnswers(SceneManager.GetActiveScene().name, givenAnswers);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
