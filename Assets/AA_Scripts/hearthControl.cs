using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class hearthControl : MonoBehaviour
{
    [Header("Sprites dos corações")]
    public GameObject hearthEmpty;
    public GameObject hearthMiddle;
    public GameObject hearthFull;

    public Transform heartParent;

    public HealthSistem hs;
    private List<GameObject> coracoes = new List<GameObject>();

    void Start()
    {
        AtualizarCoracoes();
    }


    public void AtualizarCoracoes()
    {
        int vMax = hs.vidaMaxima;
        int vAtual = hs.vidaAtual;
        Debug.Log("chegou aq");
        foreach (GameObject coracao in coracoes)
        {
            Destroy(coracao);
        }
        coracoes.Clear();
        // para inicializar corretamente


        for (int i = 0; i < 3; i++)
        {
            GameObject prefab = (i < vAtual && i%2 != 0) ? hearthFull : (i < vAtual && i%2 == 0) ? hearthMiddle : hearthEmpty;
                GameObject coracao = Instantiate(prefab, heartParent);
                coracoes.Add(coracao);   
        }
    }
}
