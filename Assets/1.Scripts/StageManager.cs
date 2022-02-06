using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    
    [SerializeField] private TMP_Text scoreText;
    
    public int Score
    {
        get => GameManager.Instance.Score;
        set
        {
            GameManager.Instance.Score = value;
            scoreText.text = $"Score: {GameManager.Instance.Score}";
            // UI 연동
        }
    }
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        scoreText.text = $"Score: {GameManager.Instance.Score}";
    }
}
