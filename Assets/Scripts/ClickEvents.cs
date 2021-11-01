using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvents : MonoBehaviour
{
    public GameObject[] allQuestionsPanels;
    private int currentQuestionsPanelIndex;
    public GameObject go_nextButton;

    public void MoveToNextQuestions()
    {
        currentQuestionsPanelIndex++;
        if (currentQuestionsPanelIndex == allQuestionsPanels.Length - 1)
        {
            go_nextButton.SetActive(false);
        }
        //if (currentQuestionsPanelIndex >= allQuestionsPanels.Length)
        //{
        //    return;
        //}
        for (int i = 0; i < allQuestionsPanels.Length; i++)
        {
            allQuestionsPanels[i].SetActive(i == currentQuestionsPanelIndex);
        }
    }
}
