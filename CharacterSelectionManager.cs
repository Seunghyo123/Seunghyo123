using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    public QuizManager quizManager;
    public GameObject openingCanvas;
    public GameObject backgroundCanvas; // 배경 캔버스
    public GameObject characterCanvas; // 캐릭터 캔버스
    public GameObject startQuizButton; // 퀴즈 시작 버튼
    public GameObject openingBack; // Openingback 배경 오브젝트

    public Character retrieverCharacter; // Retriever 캐릭터 참조
    public Character bulldogCharacter; // Bulldog 캐릭터 참조
    public Character catCharacter; // Cat 캐릭터 참조

    void Start()
    {
        startQuizButton.SetActive(false); // 초기에는 퀴즈 시작 버튼 비활성화
        openingBack.SetActive(true); // Openingback 배경 활성화
    }

    // 각 버튼에서 호출할 메서드
    public void SelectRetriever()
    {
        SelectCharacter("Retriever");
    }

    public void SelectBulldog()
    {
        SelectCharacter("Bulldog");
    }

    public void SelectCat()
    {
        SelectCharacter("Cat");
    }

    private void SelectCharacter(string characterType)
    {
        // 기존 캐릭터를 비활성화
        if (quizManager.character != null)
        {
            quizManager.character.gameObject.SetActive(false);
        }

        switch (characterType)
        {
            case "Retriever":
                quizManager.character = retrieverCharacter;
                break;
            case "Bulldog":
                quizManager.character = bulldogCharacter;
                break;
            case "Cat":
                quizManager.character = catCharacter;
                break;
            default:
                Debug.LogError("Invalid character type selected.");
                return;
        }

        // 선택된 캐릭터와 배경을 활성화
        openingCanvas.SetActive(false);
        backgroundCanvas.SetActive(true);
        characterCanvas.SetActive(true);
        openingBack.SetActive(false); // Openingback 비활성화
        quizManager.character.gameObject.SetActive(true);
        startQuizButton.SetActive(true); // 퀴즈 시작 버튼 활성화
    }

    public void ResetGame()
    {
        openingCanvas.SetActive(true);
        backgroundCanvas.SetActive(false);
        characterCanvas.SetActive(false);
        startQuizButton.SetActive(false);

        if (quizManager.character != null)
        {
            quizManager.character.ResetCharacter();
        }
        if (quizManager.background != null)
        {
            quizManager.background.ResetBackground();
        }

        // 모든 캐릭터와 배경을 비활성화하고 Openingback을 활성화
        openingBack.SetActive(true);

        retrieverCharacter.gameObject.SetActive(false);
        bulldogCharacter.gameObject.SetActive(false);
        catCharacter.gameObject.SetActive(false);
    }
}
