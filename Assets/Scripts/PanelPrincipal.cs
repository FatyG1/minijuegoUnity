using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelPrincipal : MonoBehaviour
{
    // Carga la escena del juego
    public void PlayGame()
    {
        SceneManager.LoadScene("Juego");
    }

    // Sale del juego
    public void QuitGame()
    {
        Debug.Log("Salimos del juego");
        Application.Quit();
    }
    public void menuPrincipal()
    {
        SceneManager.LoadScene("Menu");
    }
}
