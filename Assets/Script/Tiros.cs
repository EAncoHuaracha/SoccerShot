using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiros : MonoBehaviour
{
    private const float MaxTiros = 10f;
    private Text tirosText;
    [SerializeField] private GameOver menuGameOver;

    void Start()
    {
        tirosText = GetComponent<Text>();
        LoadTiros(); // Cargar tiros al iniciar
    }

    void Update()
    {
        // Mostrar tiros restantes
        tirosText.text = ScoreManager.GetTiros().ToString();
    }

    public void UseTiros(float amount)
    {
        ScoreManager.UseTiros(amount); // Usar tiros
        if (ScoreManager.GetTiros() < 0)
        {
            menuGameOver.ActivateGameOver();
            ScoreManager.SetScore(0f); // Reiniciar la puntuación
            ScoreManager.RestoreTiros(MaxTiros); // Restaurar los tiros
        }
    }

    private void LoadTiros()
    {
        ScoreManager.LoadScore(); // Cargar los valores guardados (puntuación y tiros)
    }
}
