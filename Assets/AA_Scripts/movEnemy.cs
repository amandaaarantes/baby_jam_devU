using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
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

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        animatorEnemy = GetComponent<Animator>();

    }

    void Update()
    {
        rbEnemy.linearVelocity = new Vector2(speed, rbEnemy.linearVelocity.y);
       // isColliding = Physics2D.Linecast(foot.position, front.position);

        /*if (isColliding)
        {
            speed = -speed;
        }*/
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            speed = -speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & wallLayer) != 0)
        {
            speed = -speed;
        }
    }

    /*void Flip(float direcao)
    {
        tEnemy.localScale = new Vector3(MathF.Sign(direcao), 1f, 1f);
    }*/
}
