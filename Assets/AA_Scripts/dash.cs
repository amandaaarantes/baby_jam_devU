using UnityEngine;
using System;
using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;

// SE QUISER USAR TRAIL RENDERER TA NO TUTORIAL TBM
public class dash : MonoBehaviour
{

    [Header("Dashing")]
    public float dashSpeed;
    public float timeDashing;
    private Vector2 dashDirection; // guarda a direcao do dash
    private bool isDashing;
    private bool canDash = true; // se o player pode ou n dar dash

    public movPlayer mov;


    public void Update()
    {
        if (Input.GetButtonDown("Dash") && canDash) // o botao é o SHIFT
        {
            dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // pega o input do teclado 
            if (dashDirection == Vector2.zero) // se n tiver input
            {
                dashDirection = new Vector2(mov.transform.localScale.x, y: 0); // ??

            }
            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            mov.rbPlayer.linearVelocity = dashDirection.normalized * dashSpeed;
            return;
        }
    }

    public IEnumerator StopDashing()
    {
        canDash = false;
        yield return new WaitForSeconds(timeDashing);
        canDash = true;
    }
}