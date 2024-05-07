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
    private float initialTiros;

    [SerializeField] private Score score;

    void Start()
    {
        // Cargar el puntaje guardado al iniciar la escena
        ScoreManager.LoadScore();
        initialScore = ScoreManager.GetScore(); // Guarcar el puntaje inicial
        initialTiros = ScoreManager.GetTiros(); // Guardar los tiros iniciales inicial
    }

    void Update()
    {
        
        // Verificar si se ha detectado el balón
        if (ballDetected)
        {
            messageText.gameObject.SetActive(true);
            Invoke("ReloadScene", 5f);
        }
        else
        {
            Invoke("ReloadScene", 10f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el trigger fue activado
        if (other.CompareTag("Gol"))
        {
            score.AddScore(5); // Agregar puntaje al marcador
            messageAudioSource.Play();
            ballDetected = true;
        }
    }

    private void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);

        Time.timeScale = 1f;
    }
}
