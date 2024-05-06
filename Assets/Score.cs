using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        // Cargar el puntaje guardado al iniciar la escena
        LoadScore();
    }

    public void AddScore(float scoreEntry)
    {
        // Agregar puntaje y actualizar el texto
        ScoreManager.AddScore(scoreEntry);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        // Obtener el puntaje actual del ScoreManager y actualizar el texto
        scoreText.text = ScoreManager.GetScore().ToString("0");
    }

    private void LoadScore()
    {
        // Cargar el puntaje guardado al iniciar la escena
        ScoreManager.LoadScore();
        UpdateScoreText(); // Actualizar el texto del puntaje
    }
}