using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float maxRotation = 90f; // �ngulo m�ximo de rotaci�n (positivo)
    public float minRotation = -90f;
    public float rotationSpeed = 90f; // Velocidad de rotaci�n en grados por segundo
    public bool canRotate = true; // Indica si la flecha puede rotar

    private float currentRotation = -90f; // �ngulo actual de rotaci�n
    private int rotationDirection = 1; // Direcci�n de rotaci�n (1 para girar en sentido horario, -1 para antihorario)

    private Vector3 shootDirection;

    void Update()
    {
        if (canRotate)
        {
            // Calcular el nuevo �ngulo de rotaci�n
            currentRotation += rotationDirection * rotationSpeed * Time.deltaTime;

            // Limitar el �ngulo de rotaci�n entre -maxRotation y maxRotation
            currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

            // Aplicar la rotaci�n a la flecha
            transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

            // Verificar los l�mites de rotaci�n
            if (currentRotation == maxRotation || currentRotation <= minRotation)
            {
                // Cambiar la direcci�n de rotaci�n al alcanzar los l�mites
                rotationDirection *= -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Detener la rotaci�n y guardar la direcci�n de disparo
            canRotate = false;

            // Obtener la direcci�n de disparo al momento de presionar la tecla
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shootDirection = (mousePosition - transform.position).normalized;
        }
    }

    public float GetShootDirection()
    {
        return currentRotation;
    }
}
