using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float maxRotation = 90f; // Ángulo máximo de rotación (positivo)
    public float minRotation = -90f;
    public float rotationSpeed = 90f; // Velocidad de rotación en grados por segundo
    public bool canRotate = true; // Indica si la flecha puede rotar

    private float currentRotation = -90f; // Ángulo actual de rotación
    private int rotationDirection = 1; // Dirección de rotación (1 para girar en sentido horario, -1 para antihorario)

    private Vector3 shootDirection;

    void Update()
    {
        if (canRotate)
        {
            // Calcular el nuevo ángulo de rotación
            currentRotation += rotationDirection * rotationSpeed * Time.deltaTime;

            // Limitar el ángulo de rotación entre -maxRotation y maxRotation
            currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

            // Aplicar la rotación a la flecha
            transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

            // Verificar los límites de rotación
            if (currentRotation == maxRotation || currentRotation <= minRotation)
            {
                // Cambiar la dirección de rotación al alcanzar los límites
                rotationDirection *= -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Detener la rotación y guardar la dirección de disparo
            canRotate = false;

            // Obtener la dirección de disparo al momento de presionar la tecla
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shootDirection = (mousePosition - transform.position).normalized;
        }
    }

    public float GetShootDirection()
    {
        return currentRotation;
    }
}
