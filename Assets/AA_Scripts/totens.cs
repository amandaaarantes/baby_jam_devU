using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class totens : MonoBehaviour
{
    public movPlayer movP;
    public ataquePertoPlayer ataqueP;
    public HealthSistem hsP;
    public Animator animP;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TotemForca"))
        {

            // mecanica de escolha
            bool mexerDps = false;
            if (mexerDps) { // escolhido + dano
                ataqueP.dano += ataqueP.dano * 50 / 100;
            }
            else if (!mexerDps) { // escolhido + distancia de ataque
                ataqueP.raioAtaque += ataqueP.raioAtaque * 30 / 100;
            }

            animP.SetTrigger("TotemForca");
        }

        else if (collision.CompareTag("TotemDefesa"))
        {
            // mecanica de escolha


            hsP.vidaAtual = hsP.vidaMaxima;
            hsP.coracoes.AtualizarCoracoes();

            //logica para add +1 coracao 

        }
        else if (collision.CompareTag("TotemMobilidade"))
        {
            movP.quantPulos += 1;
        }
    }

}