using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine;

public class ataquePertoPlayer : MonoBehaviour
{
    private Animator animatorPlayer;
    private Rigidbody2D rbPlayer;
    public LayerMask Enemy;

    [Header("Ataque")]
    public int dano;

    [Header("Zona de ataque")]
    public Transform zonaAtaque;
    public float raioAtaque;

    [Header("Intervalo entre os ataques")]
    public float cooldown;
    private bool estaAtacando = false;

    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (Input.GetButtonDown("Fire1") && !estaAtacando && rbPlayer.linearVelocity.y == 0 && rbPlayer.linearVelocity.x == 0)
        {
            animatorPlayer.SetTrigger("Ataque");
            Atacar();
            StartCoroutine(cooldownAtaque());

        }

    }

    private IEnumerator cooldownAtaque()
    {
        estaAtacando = true;
        yield return new WaitForSecondsRealtime(cooldown);
        estaAtacando = false;
    }

    private void OnDrawGizmos()
    {
        if (zonaAtaque != null)
        {
            Gizmos.DrawWireSphere(zonaAtaque.position, raioAtaque);
        }
    }

    private void Atacar()
    {
        Collider2D colliderInimigo = Physics2D.OverlapCircle(zonaAtaque.position, raioAtaque, Enemy);
        if (colliderInimigo != null)
        {
            HealthSistem alvo = colliderInimigo.GetComponent<HealthSistem>();
             if (alvo != null)
             {
                 alvo.TakeDamage(dano);
             }
        }
    }
}
