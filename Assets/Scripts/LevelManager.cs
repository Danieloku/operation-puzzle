using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string[] levelNames; // Lista de nombres de las escenas de niveles
    private List<string> selectedLevels = new List<string>(); // Lista de niveles seleccionados aleatoriamente
    private int currentLevelIndex = 0;

    void Start()
    {
        SelectRandomLevels();
        LoadNextLevel();
    }

    // Selecciona aleatoriamente 3 niveles de la lista de niveles disponibles
    void SelectRandomLevels()
    {
        List<string> levels = new List<string>(levelNames);
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, levels.Count);
            selectedLevels.Add(levels[randomIndex]);
            levels.RemoveAt(randomIndex);
        }
    }

    // Carga el siguiente nivel en la secuencia
    public void LoadNextLevel()
    {
        if (currentLevelIndex < selectedLevels.Count)
        {
            SceneManager.LoadScene(selectedLevels[currentLevelIndex]);
            currentLevelIndex++;
        }
        else
        {
            Debug.Log("¡Todos los niveles completados!");
        }
    }

    // Método para reiniciar el juego o cargar una nueva secuencia de niveles
    public void RestartGame()
    {
        currentLevelIndex = 0;
        selectedLevels.Clear();
        SelectRandomLevels();
        LoadNextLevel();
    }
}
