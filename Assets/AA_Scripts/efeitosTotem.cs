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
            if (mexerDps)
            { // escolhido + dano
                ataqueP.dano += ataqueP.dano * 50 / 100;
            }
            else if (!mexerDps)
            { // escolhido + distancia de ataque
                ataqueP.raioAtaque += ataqueP.raioAtaque * 30 / 100;
            }

            animP.SetTrigger("TotemForca");
        }

        else if (collision.CompareTag("TotemDefesa"))
        {
            // mecanica de escolha
            bool mexerdps = false;
            if (mexerdps)
            {
                hsP.vidaAtual = hsP.vidaMaxima;
                hsP.coracoes.AtualizarCoracoes();
            }
            else if (!mexerdps)
            {
                hsP.vidaMaxima += 2;
                hsP.vidaAtual += 2;
                //logica para add +1 coracao
            }

        }
        else if (collision.CompareTag("TotemMobilidade"))
        {
            // mecanica de escolha
            bool mexerdps = false;
            if (mexerdps)
            {
                movP.quantPulos += 1;
            }
            else if (!mexerdps)
            {
                // mecanica de dash
            }

        }

    }

}