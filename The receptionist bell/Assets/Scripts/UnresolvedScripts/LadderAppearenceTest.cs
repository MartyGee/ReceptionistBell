using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderAppearenceTest : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            animator.SetTrigger("Ladder Appear");
    }
}

//Questo script dovrebbe far partire l'animazione della scala e del muro che si alza una volta che la campana è stata premuta tot volte.