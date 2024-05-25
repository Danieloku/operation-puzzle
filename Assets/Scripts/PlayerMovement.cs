using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDistance = 1.0f; // Distancia de movimiento (debería ser igual al tamaño de un tile)
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (!isMoving)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector3.back; // Invertido
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Vector3.forward; // Invertido
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Vector3.right; // Invertido
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Vector3.left; // Invertido
            }

            if (direction != Vector3.zero)
            {
                Vector3 newPosition = targetPosition + direction * moveDistance;
                if (CanMoveTo(newPosition))
                {
                    StartCoroutine(MoveTo(newPosition));
                }
            }
        }
    }

    private bool CanMoveTo(Vector3 position)
    {
        // Verifica si el jugador puede moverse a la nueva posición (por ejemplo, no hay obstáculos)
        Collider[] hitColliders = Physics.OverlapBox(position, new Vector3(0.45f, 0.45f, 0.45f));
        foreach (Collider collider in hitColliders)
        {
            if (!collider.CompareTag("Player") && !collider.CompareTag("Ground"))
            {
                return false;
            }
        }
        return true;
    }

    private System.Collections.IEnumerator MoveTo(Vector3 position)
    {
        isMoving = true;
        float elapsedTime = 0;
        float duration = 0.1f; // Tiempo para completar el movimiento
        Vector3 startPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, position, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = position;
        targetPosition = position;
        isMoving = false;
    }
}