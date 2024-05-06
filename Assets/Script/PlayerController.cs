using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float kickForce = 3f; // Fuerza con la que se patear� la pelota
    public float elevationAngle = 0.1f; // �ngulo de elevaci�n en grados

    [SerializeField] private Tiros tiros;

    void Update()
    {
        // Detectar el input del jugador para patear la pelota
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Obtener el �ngulo de direcci�n desde la flecha
            float horizontalAngle = FindObjectOfType<Arrow>().GetShootDirection();

            // Calcular la direcci�n de disparo incluyendo la elevaci�n
            Vector3 kickDirection = CalculateKickDirection(horizontalAngle, elevationAngle);

            // Patear la pelota en la direcci�n especificada
            KickBall(kickDirection);
        }
    }

    void KickBall(Vector3 kickDirection)
    {
        // Encontrar la pelota m�s cercana al jugador
        GameObject ball = FindClosestBall();

        if (ball != null)
        {
            // Aplicar fuerza a la pelota para patearla en la direcci�n especificada
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                ballRigidbody.AddForce(kickDirection * kickForce, ForceMode.Impulse);
            }
            tiros.UseTiros(1);
        }
    }

    Vector3 CalculateKickDirection(float horizontalAngleDegrees, float elevationAngleDegrees)
    {
        // Convertir los �ngulos a radianes
        float horizontalAngleRadians = horizontalAngleDegrees * Mathf.Deg2Rad;
        float elevationAngleRadians = elevationAngleDegrees * Mathf.Deg2Rad;

        // Calcular las componentes X, Y y Z del vector de direcci�n
        float x = Mathf.Cos(horizontalAngleRadians) * Mathf.Cos(elevationAngleRadians);
        float y = Mathf.Sin(elevationAngleRadians);
        float z = Mathf.Sin(horizontalAngleRadians) * Mathf.Cos(elevationAngleRadians);

        // Crear y devolver el vector de direcci�n normalizado
        return new Vector3(z,y, x).normalized;
    }

    GameObject FindClosestBall()
    {
        // Encontrar la pelota m�s cercana al jugador
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        GameObject closestBall = null;
        float closestDistance = Mathf.Infinity;
        Vector3 playerPosition = transform.position;

        foreach (GameObject ball in balls)
        {
            float distance = Vector3.Distance(ball.transform.position, playerPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestBall = ball;
            }
        }

        return closestBall;
    }

}
