using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{

    public static GameValues instance = null;

    private int score, maxScore;
    private ObjectPool objectPool = new ObjectPool(3, 3);

    
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    public int MaxScore
    {
        get
        {
            return maxScore;
        }
        set
        {
            maxScore = value;
        }
    }
    public ObjectPool ObjectPool
    {
        get
        {
            return objectPool;
        }
        set
        {
            objectPool = value;
        }
    }

    public void IncreaseScore()
    {
        score++;
        if (score>maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("maxScore", maxScore);
        }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        maxScore = PlayerPrefs.GetInt("maxScore", 0);

    }

}
