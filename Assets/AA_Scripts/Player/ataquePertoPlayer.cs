using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine;

public class ataquePertoPlayer : MonoBehaviour
{
    private Animator animatorPlayer;
    private Rigidbody2D rbPlayer;

    [Header("Intervalo entre os ataques")]
    public float cooldown;
    private float proximoAtaque;

    private bool estaAtacando = false;

    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && !estaAtacando && rbPlayer.linearVelocity.y == 0 && rbPlayer.linearVelocity.x == 0)
        {
            animatorPlayer.SetTrigger("Ataque");
            StartCoroutine(cooldownAtaque());

        }
    }


    private IEnumerator cooldownAtaque()
    {
        estaAtacando = true;
        yield return new WaitForSecondsRealtime(cooldown);
        estaAtacando = false;
    }
}
