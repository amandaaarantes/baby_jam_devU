using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ataquePertoEnemy : MonoBehaviour
{

    [Header("Knockback")]
    public float knockbackForce; //aplicada no player
    public float knockbackDelay;

    private bool tomaKnockback = false;
    public Transform zonaDeAtaque;
    public Animator animatorEnemy;
    public GameObject hurtbox;
    public float raioDeAtaque;
    public movEnemy movE;


    void Start()
    {
        Transform hurtboxTransform = transform.parent.Find("hurtbox");

        if (hurtboxTransform != null)
        {
            GameObject hurtbox = hurtboxTransform.gameObject;
        }
            if (movE == null)
        {
            UnityEngine.Debug.Log(" movEnemy não foi atribuído");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            StartCoroutine(Soco(collision));

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

        movPlayer mov = rb.GetComponent<movPlayer>();
        if (mov != null)
        {
            mov.enabled = false;
            yield return new WaitForSecondsRealtime(tempo);
            mov.enabled = true;
        }
    }

    IEnumerator Soco(Collider2D collision)
    {
        movE.moveSpeed = 0f;
        animatorEnemy.SetTrigger("Ataque");
        yield return new WaitForSecondsRealtime(1.5f);
            
        Rigidbody2D rb = collision.GetComponentInParent<Rigidbody2D>();
        if (rb != null && !tomaKnockback)
        {
            hurtbox.SetActive(true);
            Vector2 direcao = movE.DirecaoMovimento.normalized;
            Vector2 knockbackDir = new Vector2(direcao.x, 1f).normalized;
            StartCoroutine(delayDoKnockback(rb, knockbackDir, knockbackDelay));
            UnityEngine.Debug.Log("executei");
        }
        hurtbox.SetActive(false);
        movE.moveSpeed = 0.5f;
    }
}