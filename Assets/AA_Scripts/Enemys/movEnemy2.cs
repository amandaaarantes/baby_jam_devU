using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.EventSystems;
public class movEnemy2 : MonoBehaviour
{
    public float speed = 1f;

    [Header("Verificacao do chão/parede")]
    public LayerMask detectorLayer;
    public Transform detector;

    public bool isFront;
    public bool isFoot;
    

    // private bool isColliding;

    public Transform tEnemy;

    public Rigidbody2D rbEnemy;
    // private Animator animatorEnemy;

    private Vector2 direcaoDoMovimento = Vector2.right;

    void Start()
    {
    }

    void FixedUpdate()
    {
        rbEnemy.linearVelocity = new Vector2(direcaoDoMovimento.x, rbEnemy.linearVelocity.y);


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Entrou no trigger exit ");
        if (((1 << collision.gameObject.layer) & detectorLayer) != 0 &&isFoot)
        {
            Flip();
            Debug.Log("Entrou no trigger exit if " + speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entrou no trigger enter "+ isFront);
        if (((1 << collision.gameObject.layer) & detectorLayer) != 0 &&isFront)
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