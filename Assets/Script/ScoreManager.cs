using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    private const string ScoreKey = "PlayerScore";
    private const string TirosKey = "PlayerTiros";
    private static float score = 0f;
    private static float tiros = 10f;

    public static float GetScore()
    {
        return score;
    }

    public static float GetTiros()
    {
        return tiros;
    }

    public static void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
        SaveScore();
    }

    public static void SetScore(float newScore)
    {
        score = newScore;
        SaveScore();
    }

    public static void UseTiros(float tirosToUse)
    {
        tiros -= tirosToUse;
        SaveTiros();
    }

    public static void RestoreTiros(float amount)
    {
        tiros = amount;
        SaveTiros();
    }

    public static void SaveScore()
    {
        PlayerPrefs.SetFloat(ScoreKey, score);
        PlayerPrefs.Save();
    }

    public static void SaveTiros()
    {
        PlayerPrefs.SetFloat(TirosKey, tiros);
        PlayerPrefs.Save();
    }

    public static void LoadScore()
    {
        score = PlayerPrefs.GetFloat(ScoreKey, 0f);
        tiros = PlayerPrefs.GetFloat(TirosKey, 10f);
    }
}
