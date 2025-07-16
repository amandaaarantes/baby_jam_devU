using System.Collections;
using UnityEngine;

public class ataquePertoEnemy : MonoBehaviour
{
    public int dano;

    [Header("Knockback")]
    public float knockbackForce; //aplicada no player
    public float knockbackDelay;

    private bool tomaKnockback = false;
    public Transform zonaDeAtaque;
    public Animator animatorEnemy;
    public float raioDeAtaque;
    public movEnemy movE;


    void Start()
    {
        if (movE == null)
        {
            Debug.Log(" movEnemy não foi atribuído");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animatorEnemy.SetTrigger("Ataque");
            HealthSistem hs = collision.GetComponentInParent<HealthSistem>();
            if (hs != null)
            {
                hs.TakeDamage(dano);
            }
            //Knockback:
            Rigidbody2D rb = collision.GetComponentInParent<Rigidbody2D>();
            if (rb != null && movE != null && !tomaKnockback)
            {
                Vector2 direcao = movE.DirecaoMovimento.normalized;
                Vector2 knockbackDir = new Vector2(direcao.x, 1f).normalized;
                StartCoroutine(delayDoKnockback(rb, knockbackDir, knockbackDelay));
            }

        }
    }
    private void OnDrawGizmos()
    {
        if (zonaDeAtaque != null)
        {
            Gizmos.DrawWireSphere(zonaDeAtaque.position, raioDeAtaque);
        }
    }

    IEnumerator delayDoKnockback(Rigidbody2D rb, Vector2 knockbackDirecao, float tempo)
    {
        
        rb.AddForce(knockbackDirecao * knockbackForce, ForceMode2D.Impulse);
        tomaKnockback = true;
        yield return new WaitForSecondsRealtime(tempo);
        tomaKnockback = false;

        /*movPlayer mov = rb.GetComponent<movPlayer>();
        if (mov != null)
        {
            mov.enabled = false;
            yield return new WaitForSecondsRealtime(tempo);
            mov.enabled = true;
        }*/
    }
}


