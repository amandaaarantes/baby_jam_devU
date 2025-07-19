using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Transform t;
    public float groundCheckRadius = 0.2f;

    [Header("Camadas necessárias:")]
    public LayerMask groundLayer; // seleciona a camada do chão
    public LayerMask thornsLayer; // camada dos espinhos
    

    void Start()
    {
        rbPlayer = GetComponentInParent<Rigidbody2D>();
        animatorPlayer = GetComponentInParent<Animator>();
        t = GetComponentInParent<Transform>();
        
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
        else if (((1 << collision.gameObject.layer) & thornsLayer) != 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reinicia a cena
        }
    }

    void Flip(float direcao)
    {
        t.localScale = new Vector3(MathF.Sign(direcao), 1f, 1f);
    
    }


}