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
    public menuEscolhaUI menu;

    private dash d;

   
    public void Mobilidade1()
    {
        movP.quantPulos += 1;
    }

    public void Mobilidade2()
    {
        d = GetComponent<dash>(); //?????????????????

    }

    public void Forca1()
    {
        // escolhido + dano
        ataqueP.dano += ataqueP.dano * 50 / 100;
    }

    public void Forca2()
    {
        // escolhido + distancia de ataque
        ataqueP.raioAtaque += ataqueP.raioAtaque * 30 / 100;
    }

    public void Defesa1() {

        hsP.vidaMaxima += 1;
        hsP.vidaAtual = hsP.vidaMaxima;
        hsP.coracoes.AtualizarCoracoes();

    }

    public void Defesa2() {
        
        // thorns // reflete 20% do dano recebido
    }
}
