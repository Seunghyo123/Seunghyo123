using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public GameObject quizCanvas;

    public void ShowQuizCanvas()
    {
        quizCanvas.SetActive(true);
    }
}
