using UnityEngine;

public class RotateBox : MonoBehaviour
{
    public bool isHeld = false; // Si la caja está siendo sostenida
    public Transform player; // Referencia al jugador
    private Vector3[] positions; // Posiciones alrededor del jugador

    void Start()
    {
        // Inicializar las posiciones alrededor del jugador
        positions = new Vector3[4];
        positions[0] = new Vector3(-1, 0, 0); // Izquierda
        positions[1] = new Vector3(0, 0, 1); // Arriba
        positions[2] = new Vector3(1, 0, 0); // Derecha
        positions[3] = new Vector3(0, 0, -1); // Abajo
    }

    void Update()
    {
        if (isHeld)
        {
            // Rotar la caja a las cuatro posiciones alrededor del jugador
            if (Input.GetKeyDown(KeyCode.Q))
            {
                RotateAroundPlayer(-90);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                RotateAroundPlayer(90);
            }
        }
    }

    void RotateAroundPlayer(float angle)
    {
        // Rotar la caja alrededor del jugador
        transform.RotateAround(player.position, Vector3.up, angle);
    }
}
