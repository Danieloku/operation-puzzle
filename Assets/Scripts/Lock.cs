using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public int correctSum; // aquí va la suma correcta para abrir el candado

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CheckBoxesAndUnlock();
        }
    }

    private void CheckBoxesAndUnlock()
    {
        // Obtener las cajas pegadads al jugador
        Collider[] hitColliders = Physics.OverlapBox(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        List<NumberedBox> adjacentBoxes = new List<NumberedBox>();

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Box"))
            {
                NumberedBox numberedBox = collider.GetComponent<NumberedBox>();
                if (numberedBox != null)
                {
                    adjacentBoxes.Add(numberedBox);
                }
            }
        }

        // Verificar si hay exactamente dos cajas al lado
        if (adjacentBoxes.Count == 2)
        {
            int sum = adjacentBoxes[0].number + adjacentBoxes[1].number;

            if (sum == correctSum)
            {
                Unlock();
            }
        }
    }

    private void Unlock()
    {
        Debug.Log("¡Candado abierto!");
        // Aquí puedes agregar la lógica para abrir el candado, por ejemplo, desactivar el objeto candado
        gameObject.SetActive(false);
    }
}
