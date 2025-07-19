using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class menuInGame : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menuEscolha;
    
    public void Start()
    {
        menuEscolha.SetActive(false);
    }

    public void AbrirMenu()
    {
        menuEscolha.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }
    public void Resume()
    {
        menuEscolha.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


}