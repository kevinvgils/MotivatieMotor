using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<Sentence> sentences;
    private QuestionTrigger questionTrigger;
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public Animator animator;
    private bool IsCoroutineRunning;
    private Sentence currentSentence;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue(Dialogue dialogue) {
        animator.SetBool("IsOpen", true);

        Debug.Log(dialogue.questionForDialogue);
        questionTrigger = dialogue.questionForDialogue;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(Sentence sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(IsCoroutineRunning) {
            StopAllCoroutines();
            IsCoroutineRunning = false;
            dialogueText.text = currentSentence.sentence;
            return;
        }
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        currentSentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(Sentence sentence) {
        IsCoroutineRunning = true;
        dialogueText.text = "";
        nameText.text = sentence.name;
        foreach(char letter in sentence.sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        IsCoroutineRunning = false;
    }

    void EndDialogue() {
        animator.SetBool("IsOpen", false);
        if(questionTrigger) {
            questionTrigger.TriggerQuestion();
        }
    }
}
