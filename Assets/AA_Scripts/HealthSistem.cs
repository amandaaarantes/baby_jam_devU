using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HealthSistem : MonoBehaviour
{

    public int vidaAtual;
    public int vidaMaxima = 6;
    public float invencibilidade; // tempo q o gameObject n pode levar dano
    public bool estaInvencivel = false;
    // public Animator an;

    public hearthControl coracoes;
    public Animator anim;
    void Start()
    {
        vidaAtual = vidaMaxima;
        anim.SetBool("Morreu", false);
    }

    public void TakeDamage(int quant)
    {
        if (!estaInvencivel)
        {
            vidaAtual -= quant;
            Debug.Log("Tomou dano! Vida restante: " + vidaAtual);

            if (CompareTag("Player") && coracoes != null)
            {
                coracoes.AtualizarCoracoes();
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
                anim.SetBool("Morreu", true);
                calma();
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

    public IEnumerator cooldownInvencibilidade()
    {
        estaInvencivel = true;
        yield return new WaitForSecondsRealtime(invencibilidade);
        estaInvencivel = false;
        
    }
    IEnumerator calma()
    {
         yield return new WaitForSecondsRealtime(3);
    }
}
