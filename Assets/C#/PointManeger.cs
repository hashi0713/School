using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManeger
{
   private static PointManeger _instance;
    public static PointManeger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PointManeger();
            }
            return _instance;
        }
    }

    public int Score
    {
        get;
        private set;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void GetScore(int i)
    {
        Score+=i;
    }

    public int Life
    {
        get;
        private set;
    }

    public void PlayerHurt()
    {
        Life--;
    }
}
