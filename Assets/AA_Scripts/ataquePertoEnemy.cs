using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class ataquePertoEnemy : MonoBehaviour
{

    public Transform zonaDeAtaque;
    public Animator animatorEnemy;
    public GameObject hurtbox;
    public float raioDeAtaque;
    public movEnemy movE;

    void Awake()
    {
        Transform hurtboxTransform = transform.parent.Find("hurtbox");

        if (hurtboxTransform != null)
        {
            hurtbox = hurtboxTransform.gameObject;
        }
        else
        {
            UnityEngine.Debug.LogError("Hurtbox not found!");
        }

    }


    void Start()
    {
        if (movE == null)
        {
            UnityEngine.Debug.Log("movEnemy não foi atribuído");
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

    IEnumerator Soco(Collider2D collision)
    {
        movE.moveSpeed = 0f;
        animatorEnemy.SetTrigger("Ataque");
        yield return new WaitForSecondsRealtime(1.5f);
            
        Rigidbody2D rb = collision.GetComponentInParent<Rigidbody2D>();
        if (rb != null)
        {
            hurtbox.SetActive(true);
            UnityEngine.Debug.Log("executei");
        }
        movE.moveSpeed = 0.5f;
        yield return new WaitForSecondsRealtime(0.2f);
        hurtbox.SetActive(false);
    }
}