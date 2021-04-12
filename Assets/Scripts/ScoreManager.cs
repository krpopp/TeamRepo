using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float score;

  

    public void SetScore(float newScore) 
    {
        score = newScore;
    }

    public float GetScore() 
    {
        return score;
    }

}
