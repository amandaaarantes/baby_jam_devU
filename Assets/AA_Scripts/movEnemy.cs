using UnityEngine;

public class movEnemy : MonoBehaviour
{
    public Rigidbody2D enemyRb;
    public float moveSpeed = 2f;

    public BoxCollider2D pe;
    public BoxCollider2D frente;  
    private Vector2 moveDirection = Vector2.right;

    public Vector2 DirecaoMovimento => moveDirection;


    public void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        enemyRb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, enemyRb.linearVelocity.y);
    }

    public void Flip()
    {
        moveDirection *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}