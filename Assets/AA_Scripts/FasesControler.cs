using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class FasesControler : MonoBehaviour
{
    /*[Header("Objetos da fase")]
    public List<GameObject> inimigos;
    public List<GameObject> totens;*/

    [Header("Saída da fase")]
    public GameObject saida;
    public ChangeScenes cs;

    public GameObject botaoPrxFase;

    void Start()
    {
        botaoPrxFase = GetComponentInParent<GameObject>();
        botaoPrxFase.SetActive(false);
        /*inimigos = new List<GameObject>(GameObject.FindGameObjectsWithTag("Inimigo"));
        totens = new List<GameObject>(GameObject.FindGameObjectsWithTag("Totem"));*/

        saida.SetActive(false);
    }

   /* public void AtualizarInimigos(GameObject inimigo)
    {
        if (inimigos.Contains(inimigo))
        {
            inimigos.Remove(inimigo);
            AtivaPortal();
        }
    }

    public void AtualizarTotens(GameObject totem)
    {
        if (totens.Contains(totem))
        {
            totens.Remove(totem);
            AtivaPortal();
        }
    }*/

    /*public void AtivaPortal()
    {
        if (inimigos.Count == 0 && totens.Count == 0)
        {
            Debug.Log("Tudo certo p ir pra proxima fase");
            saida.SetActive(true);
        }
    }*/

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Saida"))
        {
            botaoPrxFase.SetActive(true);
        }
    }
}