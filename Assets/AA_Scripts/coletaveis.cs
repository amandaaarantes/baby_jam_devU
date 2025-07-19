using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class coletaveis : MonoBehaviour
{
    public bool foiColetado = false;

    public menuEscolhaUI menu;
    // public FasesControler faseC;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foiColetado = true;
          //  faseC.AtualizarTotens(gameObject);
            Destroy(gameObject);
            menu.HoraDaEscolha();


        }
    }
}

