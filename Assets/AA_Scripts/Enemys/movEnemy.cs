using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
public class movEnemy : MonoBehaviour
{
    public float speed = 1f;

    [Header("Verificacao do chão e da parede")]
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public Transform foot;
    public Transform front;

    // private bool isColliding;

    public Transform tEnemy;

    private Rigidbody2D rbEnemy;
    private Animator animatorEnemy;

    private Vector2 direcaoDoMovimento = Vector2.right;
    private bool isFoot;
    private bool isFront;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        animatorEnemy = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        rbEnemy.linearVelocity = new Vector2(direcaoDoMovimento.x, rbEnemy.linearVelocity.y);

        isFoot = !Physics2D.OverlapCircle(foot.position, 0.5f, groundLayer);
        isFront = Physics2D.OverlapCircle(front.position, 0.5f, wallLayer);


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Entrou no trigger exit ");
        if (((1 << collision.gameObject.layer) & groundLayer) != 0 && !isFoot)
        {
            Flip();
            Debug.Log("Entrou no trigger exit if " + speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrou no trigger enter "+ isFront);
        if (((1 << collision.gameObject.layer) & wallLayer) != 0 &&isFront)
        {
            Flip();
            Debug.Log("Entrou no trigger enter if " + speed);
        }
    }

    void Flip()
    {
        direcaoDoMovimento = -direcaoDoMovimento;

        Vector3 scale = tEnemy.localScale;
        scale.x *= -1;
        tEnemy.localScale = scale;
    }

}