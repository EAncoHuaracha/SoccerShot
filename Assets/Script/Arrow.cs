using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float maxRotation = 90f;
    public float minRotation = -90f;
    public float rotationSpeed = 90f;
    public bool canRotate = true;

    private float currentRotation = -90f;
    private int rotationDirection = 1;

    private Vector3 shootDirection;

    [SerializeField] private GameObject player;

    void Update()
    {
        if (canRotate)
        {
            // Calcular el nuevo ángulo de rotación
            currentRotation += rotationDirection * rotationSpeed * Time.deltaTime;

            currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

            // Aplicar la rotación a la flecha
            transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

            if (currentRotation == maxRotation || currentRotation <= minRotation)
            {
                rotationDirection *= -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Detener la rotación
            canRotate = false;
            player.SetActive(true);
        }
    }

    public float GetShootDirection()
    {
        return currentRotation;
    }
}
