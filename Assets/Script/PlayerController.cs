using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float kickForce = 3f; // Fuerza con la que se pateará la pelota
    public float elevationAngle = 0.1f; // Ángulo de elevación en grados

    [SerializeField] private Tiros tiros;

    void Update()
    {
        // Detectar el input del jugador para patear la pelota
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Obtener el ángulo de dirección desde la flecha
            float horizontalAngle = FindObjectOfType<Arrow>().GetShootDirection();

            // Calcular la dirección de disparo incluyendo la elevación
            Vector3 kickDirection = CalculateKickDirection(horizontalAngle, elevationAngle);

            // Patear la pelota en la dirección especificada
            KickBall(kickDirection);
        }
    }

    void KickBall(Vector3 kickDirection)
    {
        // Encontrar la pelota más cercana al jugador
        GameObject ball = FindClosestBall();

        if (ball != null)
        {
            // Aplicar fuerza a la pelota para patearla en la dirección especificada
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
        // Convertir los ángulos a radianes
        float horizontalAngleRadians = horizontalAngleDegrees * Mathf.Deg2Rad;
        float elevationAngleRadians = elevationAngleDegrees * Mathf.Deg2Rad;

        // Calcular las componentes X, Y y Z del vector de dirección
        float x = Mathf.Cos(horizontalAngleRadians) * Mathf.Cos(elevationAngleRadians);
        float y = Mathf.Sin(elevationAngleRadians);
        float z = Mathf.Sin(horizontalAngleRadians) * Mathf.Cos(elevationAngleRadians);

        // Crear y devolver el vector de dirección normalizado
        return new Vector3(z,y, x).normalized;
    }

    GameObject FindClosestBall()
    {
        // Encontrar la pelota más cercana al jugador
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
