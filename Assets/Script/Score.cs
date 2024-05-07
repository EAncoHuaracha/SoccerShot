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
        LoadScore(); // Cargar el puntaje guardado al iniciar la escena
    }

    public void AddScore(float scoreEntry)
    {
        // Agregar puntaje y actualizar el texto
        ScoreManager.AddScore(scoreEntry);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = ScoreManager.GetScore().ToString("0");
    }

    private void LoadScore()
    {
        // Cargar el puntaje guardado al iniciar la escena
        ScoreManager.LoadScore();
        UpdateScoreText(); // Actualizar el texto del puntaje
    }

    private void OnDestroy()
    {
        ScoreManager.SaveScore(); // Guardar el puntaje al destruir el objeto
    }
}