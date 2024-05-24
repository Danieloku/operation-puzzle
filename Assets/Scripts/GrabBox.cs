using UnityEngine;

public class GrabBox : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    private GameObject currentBox = null; // Referencia a la caja actual
    private Transform combinedParent; // Objeto padre combinado

    void Start()
    {
        // Asignar la referencia del jugador automáticamente si no se ha asignado en el Inspector
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (currentBox != null)
        {
            // Pegar la caja al jugador
            Debug.Log("Caja pegada al jugador");
            Rigidbody rb = currentBox.GetComponent<Rigidbody>();
            if (rb != null)
            {
            }

            // Crear o actualizar el objeto padre combinado
            if (combinedParent == null)
            {
                combinedParent = new GameObject("CombinedParent").transform;
                combinedParent.position = player.position;
                player.SetParent(combinedParent);
                currentBox.transform.SetParent(combinedParent);
            }
            else
            {
                combinedParent.position = player.position;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Colisión detectada con la caja");
            currentBox = collision.gameObject;
            RotateBox rotateScript = currentBox.GetComponent<RotateBox>();
            if (rotateScript != null)
            {
                rotateScript.isHeld = true;
                rotateScript.player = player;
            }
        }
    }
}
