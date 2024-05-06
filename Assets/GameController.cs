using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public RectTransform messageText;
    public AudioSource messageAudioSource;

    private bool ballDetected = false; // Bandera para indicar si se ha detectado el balón

    private float initialScore;

    [SerializeField] private Score score;

    void Start()
    {
        initialScore = ScoreManager.GetScore(); // Guardar el puntaje inicial al iniciar la escena
    }

    void Update()
    {
        // Verificar si se ha detectado el balón
        if (ballDetected)
        {
            messageText.gameObject.SetActive(true);
            Invoke("ReloadScene", 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el trigger fue activado por un objeto que tiene la etiqueta "Gol"
        if (other.CompareTag("Gol"))
        {
            score.AddScore(10);
            messageAudioSource.Play();
            ballDetected = true;
        }
    }

    private void ReloadScene()
    {
        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Cargar la misma escena nuevamente
        SceneManager.LoadScene(currentSceneIndex);

        // Restaurar el puntaje inicial guardado al reiniciar la escena
        ScoreManager.SetScore(initialScore);

        // Restaurar la escala de tiempo a 1 (por si acaso se ha cambiado)
        Time.timeScale = 1f;
    }
}
