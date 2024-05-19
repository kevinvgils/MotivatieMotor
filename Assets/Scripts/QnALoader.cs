using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QnALoader : MonoBehaviour
{
    public GameObject scrollViewContent;  // Reference to the Content object of the ScrollView
    public GameObject itemPrefab;         // Reference to the prefab that will be instantiated
    public TMP_Text levelName;

    void Start()
    {
        LevelAnswers answers = ProgressManager.LoadLevelAnswers(PlayerPrefs.GetString("levelName"));
        
        AddItemsToScrollView(answers);

        levelName.text = answers.levelName;
    }

    void AddItemsToScrollView(LevelAnswers levelAnswers)
    {
        foreach (var answer in levelAnswers.answers)
        {
            GameObject newItem = Instantiate(itemPrefab, scrollViewContent.transform);

                        // Set the RectTransform to stretch and fit the parent
            RectTransform rectTransform = newItem.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.pivot = new Vector2(0.5f, 1f);

            TMP_Text[] texts = newItem.GetComponentsInChildren<TMP_Text>();
            Debug.Log(texts.Length);
            texts[0].text = answer.key;
            texts[1].text = answer.value.answer;
        }
    }
}
