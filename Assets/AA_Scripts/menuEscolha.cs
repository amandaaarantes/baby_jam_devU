using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuEscolha : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menuEscolhaUI;
    public coletaveis totem;

    void Update()
    {
        if (totem.foiColetado == true) {

            Pause();
        }
    }
    
    void Resume() {
        menuEscolhaUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause() {
        menuEscolhaUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}