using UnityEngine;
using UnityEngine.UI;

public class EndTile : MonoBehaviour
{
    private LevelManager levelManager;
    private bool playerOnEndTile = false;
    public GameObject messagePanel; // Panel que contiene el mensaje de continuar
    public Text messageText; // Texto que muestra el mensaje

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        messagePanel.SetActive(false); // Asegúrate de que el panel del mensaje esté oculto al inicio
    }

    private void Update()
    {
        if (playerOnEndTile && Input.anyKeyDown)
        {
            levelManager.LoadNextLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Nivel completado!");
            playerOnEndTile = true;
            ShowMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnEndTile = false;
            HideMessage();
        }
    }

    private void ShowMessage()
    {
        messagePanel.SetActive(true);
        messageText.text = "¡Nivel completado! Presiona cualquier tecla para continuar.";
    }

    private void HideMessage()
    {
        messagePanel.SetActive(false);
    }
}
