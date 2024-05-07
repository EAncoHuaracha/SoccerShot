using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float kickForce = 3f; // Fuerza con la que se pateará la pelota
    public float elevationAngle = 0.1f; // Ángulo de elevación en grados

    [SerializeField] private Tiros tiros;


    private bool hasKicked = false;
    private Vector3 kickDirection;

    void Update()
    {
        if (!hasKicked)
        {
            float horizontalAngle = FindObjectOfType<Arrow>().GetShootDirection();
            kickDirection = CalculateKickDirection(horizontalAngle, elevationAngle);
            
            hasKicked = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el trigger fue activado por un objeto que tiene la etiqueta "Gol"
        if (other.CompareTag("Ball"))
        {
            KickBall();
        }
    }

    void KickBall()
    {
        GameObject ball = FindClosestBall();

        if (ball != null)
        {
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                ballRigidbody.AddForce(kickDirection * kickForce, ForceMode.Impulse);
            }
            tiros.UseTiros(0.5f); // Usar un tiro al patear la pelota
        }
    }

    Vector3 CalculateKickDirection(float horizontalAngleDegrees, float elevationAngleDegrees)
    {
        float horizontalAngleRadians = horizontalAngleDegrees * Mathf.Deg2Rad;
        float elevationAngleRadians = elevationAngleDegrees * Mathf.Deg2Rad;
        float x = Mathf.Cos(horizontalAngleRadians) * Mathf.Cos(elevationAngleRadians);
        float y = Mathf.Sin(elevationAngleRadians);
        float z = Mathf.Sin(horizontalAngleRadians) * Mathf.Cos(elevationAngleRadians);
        return new Vector3(z, y, x).normalized;
    }

    GameObject FindClosestBall()
    {
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
