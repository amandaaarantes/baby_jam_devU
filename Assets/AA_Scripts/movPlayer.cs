using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class movPlayer : MonoBehaviour
{
    [Header("Movimentação")]
    public float speed = 1f;
    public float jumpForce = 5f;
    public int quantPulos = 1;
    private int pulosRestantes;
    private float moveInput; // movimentação horizontal

    public Rigidbody2D rbPlayer;
    private Animator animatorPlayer;

    [Header("Verificação do chão")]
    public Transform groundCheck; // "pé" do jogador
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; // seleciona a camada do chão

    

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
        pulosRestantes = quantPulos;
    }

    void Update()
    {

        //movimentacao horizontal
        moveInput = Input.GetAxisRaw("Horizontal");
        rbPlayer.linearVelocity = new Vector2(moveInput * speed, rbPlayer.linearVelocity.y);

        if (moveInput != 0)
        {
            Flip(moveInput); // flipa o personagem
            animatorPlayer.SetBool("Run", true);
        }
        else
        {
            animatorPlayer.SetBool("Run", false);
        }


        /* isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

         if (isGrounded)
         {
             pulosRestantes = quantPulos; // reseta os pulos
             Debug.Log("Esta no chao agr!");

         }*/

        //movimentacao vertical
        if (Input.GetButtonDown("Jump") && pulosRestantes > 0)
        {
            rbPlayer.linearVelocity = new Vector2(rbPlayer.linearVelocity.x, jumpForce);
            pulosRestantes--;
            animatorPlayer.SetTrigger("Jump");
        }

        if (pulosRestantes == quantPulos)
        {
            animatorPlayer.SetBool("NoChao", true);
        }
        else
        {
            animatorPlayer.SetBool("NoChao", false);
        }
        
        animatorPlayer.SetFloat("V", MathF.Abs(moveInput));
        animatorPlayer.SetFloat("Vy", rbPlayer.linearVelocity.y);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            pulosRestantes = quantPulos;
        }
    }
    void Flip(float direcao)
    {
        transform.localScale = new Vector3(MathF.Sign(direcao), 1f, 1f);
    }


}
