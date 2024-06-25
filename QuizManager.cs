- 👋 Hi, I’m @Seunghyo123
- 👀 I’m interested in ...
- 🌱 I’m currently learning ...
- 💞️ I’m looking to collaborate on ...
- 📫 How to reach me ...
- 😄 Pronouns: ...
- ⚡ Fun fact: ...

<!---
Seunghyo123/Seunghyo123 is a ✨ special ✨ repository because its `README.md` (this file) appears on your GitHub profile.
You can click the Preview link to take a look at your changes.
--->
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> qna; // 문제, 정답
    public GameObject[] options; // 퀴즈 선택지 4개 배열
    public int currentQuestion; // 현재 문제
    public Text QuestionText; // 텍스트
    public Text SubtitleText; // 보조 텍스트
    public Image QuestionImage; // 이미지 
    public GameObject quizCanvas; 
    public GameObject startQuizButton; // 퀴즈 시작 버튼 참조
    public Character character; // Character 객체를 참조
    public Background background; // Background 객체를 참조

    void Start()
    {
        // 초기에는 퀴즈와 배경을 시작 x
        quizCanvas.SetActive(false); // 캔버스, 배경, 캐릭터 비활성화
        background.gameObject.SetActive(false);
        character.gameObject.SetActive(false);
    }

    void makeQuestion()
    {
        if (qna.Count > 0)
        {
            //문제 목록 랜덤 선택
            currentQuestion = Random.Range(0, qna.Count);
            QuestionText.text = qna[currentQuestion].Question;
            SubtitleText.text = qna[currentQuestion].Subtitle;

            // 이미지가 있는지 확인 후 할당
            if (qna[currentQuestion].QuestionImage != null)
            {
                QuestionImage.gameObject.SetActive(true);
                QuestionImage.sprite = qna[currentQuestion].QuestionImage;
            }
            else
            {
                QuestionImage.gameObject.SetActive(false);
            }
            setAnswer();
        }
        else
        {
            Debug.Log("문제를 다 풀었습니다.");
        }
    }

    void setAnswer()
    {
        //각 선택지에 정답 여부 부여
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false; //초기 전부 오답
            options[i].transform.GetChild(0).GetComponent<Text>().text = qna[currentQuestion].Answers[i]; // 선택지 텍스트 설정

            if (qna[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Answer>().isCorrect = true; //정답을 true 설정
            }
        }
    }

    public void StartQuiz()
    {
        startQuizButton.SetActive(false); // 퀴즈 시작 버튼 비활성화
        ShowQuiz();
    }

    public void correct()
    {
        HideQuiz(); // 퀴즈 비활성화
        if (character != null) // character가 null이 아닌지 확인
        {
            Debug.Log("Character Level Up");
            character.LevelUp(); // 정답 시 레벨업
        }
        if (background != null) // background가 null이 아닌지 확인
        {
            Debug.Log("Background Level Up");
            background.LevelUp(); // 정답 시 배경 변경
        }
        startQuizButton.SetActive(true); // 퀴즈 종료 후 버튼 다시 활성화
    }

    public void incorrect()
    {
        HideQuiz(); // 퀴즈 비활성화
        if (character != null) // character가 null이 아닌지 확인
        {
            Debug.Log("Character Level Down");
            character.LevelDown(); // 오답 시 레벨다운
        }
        if (background != null) // background가 null이 아닌지 확인
        {
            Debug.Log("Background Level Down");
            background.LevelDown(); // 오답 시 배경 변경
        }
        startQuizButton.SetActive(true); // 퀴즈 종료 후 버튼 다시 활성화
    }

    public void ShowQuiz()
    {
        quizCanvas.SetActive(true); //퀴즈 캔버스 활성화
        makeQuestion(); //문제 생성
    }

    public void HideQuiz()
    {
        quizCanvas.SetActive(false); // 퀴즈 캔버스 비활성화
    }

    public void ResetGame()
    {
        // Reset all relevant game elements
        if (character != null)
        {
            character.ResetCharacter(); //캐릭터 초기화
        }
        if (background != null)
        {
            background.ResetBackground();
        }
        startQuizButton.SetActive(false); // 배경 초기화
        HideQuiz();
    }
}
