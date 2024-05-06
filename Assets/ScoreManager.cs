using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    private static float score = 0f;

    public static float GetScore()
    {
        return score;
    }

    public static void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    public static void SetScore(float newScore)
    {
        score = newScore;
    }

    public static void SaveScore()
    {
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.Save();
    }

    public static void LoadScore()
    {
        score = PlayerPrefs.GetFloat("Score", 10f);
    }
}
