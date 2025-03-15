using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        float offSetAleatorio = Random.Range(0f, 1f);

        animator.Play("PlataformMove", 0, offSetAleatorio);
    }
}
