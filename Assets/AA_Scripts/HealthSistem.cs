using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthSistem : MonoBehaviour
{

    public int vidaAtual;
    public int vidaMaxima = 6;
    public float invencibilidade; // tempo q o gameObject n pode levar dano
    private bool estaInvencivel = false;

    public hearthControl coracoes;
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void TakeDamage(int quant)
    {
        if (!estaInvencivel)
        {
            vidaAtual -= quant;
            Debug.Log("Tomou dano! Vida restante: " + vidaAtual);

            if (CompareTag("Player") && coracoes != null)
            {
                coracoes.atualizarCoracoes();
            }

            if (vidaAtual <= 0)
            {
                Debug.Log("Morreu!!!");
                if (CompareTag("Player"))
                {
                    Debug.Log("Logica de morte do jogador");
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("Ser foi destruído!");
                }
            }
            else
            {
                StartCoroutine(cooldownInvencibilidade());
            }
            // tira o dano da vidaAtual, verifica se é player para atualizar os coracoes e inserir logica de morte, destroi os demais gameobjects
        }

    }

    private IEnumerator cooldownInvencibilidade()
    {
        estaInvencivel = true;
        yield return new WaitForSecondsRealtime(invencibilidade);
        estaInvencivel = false;
        
    }
}
