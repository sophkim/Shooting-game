using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 필요 속성 : 현재(최고) 점수 UI, 현재(최고) 점수 기억

    public Text currentScoreUI;
    private int currentScore;

    public Text bestScoreUI;
    private int bestScore;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;
            currentScoreUI.text = "현재 점수 : " + currentScore;

            if (currentScore > bestScore)
            {
                bestScore++;
                bestScoreUI.text = "최고 점수 : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    // 싱글톤 객체
    public static ScoreManager Instance = null;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        // 저장된 최고 점수 불러오기
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        bestScoreUI.text = "최고 점수 : " + bestScore;
    }

}