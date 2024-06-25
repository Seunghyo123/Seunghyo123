using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject[] characters = new GameObject[11];
    public int currentLevel;

    void Start()
    {
        currentLevel = 0; // 초기 레벨 설정 (lv1)
        DeactivateAllCharacters();
        UpdateCharacter();
    }

    public void LevelUp()
    {
        if (currentLevel < characters.Length - 1)
        {
            characters[currentLevel].SetActive(false); // 현재 레벨의 캐릭터 비활성화
            currentLevel++;
            UpdateCharacter();
        }
    }

    public void LevelDown()
    {
        if (currentLevel > 0)
        {
            characters[currentLevel].SetActive(false); // 현재 레벨의 캐릭터 비활성화
            currentLevel--;
            UpdateCharacter();
        }
    }

    void UpdateCharacter()
    {
        DeactivateAllCharacters(); // 모든 캐릭터 비활성화
        if (currentLevel < characters.Length)
        {
            characters[currentLevel].SetActive(true); // 현재 레벨의 캐릭터 활성화
            Debug.Log("Current Character: " + characters[currentLevel].name);
        }
    }

    void DeactivateAllCharacters()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
            {
                characters[i].SetActive(false); // 모든 캐릭터 비활성화
            }
        }
    }

    public void ResetCharacter()
    {
        currentLevel = 0; // 초기 레벨 설정
        UpdateCharacter();
    }
}
