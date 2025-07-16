using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class coletaveis : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}