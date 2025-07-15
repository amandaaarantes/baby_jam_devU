using Unity.VisualScripting;
using UnityEngine;

public class ataquePertoPlayer : MonoBehaviour
{
    private Animator animatorPlayer;

[Header("Intervalo entre os ataques")]
    public float cooldown;
    private float proximoAtaque;


    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > proximoAtaque)
        {
            animatorPlayer.SetTrigger("Ataque");
            proximoAtaque = Time.time + cooldown;
        }
    }
}
