using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private int _score;
    private int _life;

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
        }
    }

    #region UnityEventFuncs
    private void Awake()
    {
        // 싱글톤
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(this);
    }

    #endregion

    #region PrivateFuncs

    #endregion
}
