using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class menuEscolhaUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menuEscolha;
    public Sprite opcao1Prefab;
    public Button opcao1;
    public Sprite opcao2Prefab;
    public Button opcao2;
    public coletaveis totem;

    public void Start()
    {
        menuEscolha.SetActive(false);
    }

    public void HoraDaEscolha()
    {
        opcao1.image.sprite = opcao1Prefab;
        opcao2.image.sprite = opcao2Prefab;
        menuEscolha.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        menuEscolha.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


}