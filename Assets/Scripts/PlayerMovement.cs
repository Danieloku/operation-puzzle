using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1.0f; // Distancia de movimiento (debería ser igual al tamaño de un tile)
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Move(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Move(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(Vector3.right);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
    }

    void Move(Vector3 direction)
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, direction, out hit, moveDistance))
        {
            targetPosition += direction * moveDistance;
        }
    }
}
