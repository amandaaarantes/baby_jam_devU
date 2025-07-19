using UnityEngine;

public class DarDano : MonoBehaviour
{
    public int dano;
    public float knockbackForce;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSistem hs = collision.GetComponentInParent<HealthSistem>();
            if (hs != null)
            {
                hs.TakeDamage(dano);
            }

            Rigidbody2D playerRb = collision.GetComponentInParent<Rigidbody2D>();
            if (playerRb != null)
            {
     
                Vector2 direction = (playerRb.transform.position - transform.position).normalized;


                playerRb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            }

        }
    }
}
