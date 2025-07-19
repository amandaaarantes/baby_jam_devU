using UnityEngine;

public class DarDano : MonoBehaviour
{
    public int dano;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthSistem hs = collision.GetComponentInParent<HealthSistem>();
            if (hs != null)
            {
                hs.TakeDamage(dano);
            }

        }
    }
}
