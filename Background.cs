using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] backgrounds = new GameObject[11]; // 각 레벨에 해당하는 배경 오브젝트 배열
    public int currentLevel;

    void Start()
    {
        currentLevel = 0; // 초기 레벨 설정 (lv1)
        DeactivateAllBackgrounds();
        UpdateBackground();
    }

    public void LevelUp()
    {
        if (currentLevel < backgrounds.Length - 1)
        {
            backgrounds[currentLevel].SetActive(false); // 현재 레벨의 배경 비활성화
            currentLevel++;
            UpdateBackground();
        }
    }

    public void LevelDown()
    {
        if (currentLevel > 0)
        {
            backgrounds[currentLevel].SetActive(false); // 현재 레벨의 배경 비활성화
            currentLevel--;
            UpdateBackground();
        }
    }

    void UpdateBackground()
    {
        DeactivateAllBackgrounds(); // 모든 배경 비활성화 
        if (currentLevel < backgrounds.Length)
        {
            backgrounds[currentLevel].SetActive(true); // 현재 레벨의 배경 활성화
            Debug.Log("Current Background: " + backgrounds[currentLevel].name);
        }
    }

    void DeactivateAllBackgrounds()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if (backgrounds[i] != null)
            {
                backgrounds[i].SetActive(false); // 모든 배경 비활성화
            }
        }
    }

    public void ResetBackground()
    {
        currentLevel = 0; // 초기 레벨 설정
        UpdateBackground();
    }
}
