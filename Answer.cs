using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false; // 정답 여부 확인
    public QuizManager quizManager; // QuizManager 참조
    public void Answers()
    {
        if (isCorrect)
        {
            Debug.Log("정답입니다."); // 정답일 때 출력
            quizManager.correct(); // correct 함수 호출
        }
        else
        {
            Debug.Log("틀렸습니다."); //오답일 때 출력
        }
        quizManager.HideQuiz(); // 퀴즈 캔버스 비활성화
    }
}
