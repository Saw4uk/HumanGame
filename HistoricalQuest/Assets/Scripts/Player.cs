using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public int hp;
    public bool canMove = true;
    private bool iswalking = false;
    
    [SerializeField]private Animator animator;
    public static Player Instance { get; set; }


    public int Hp
    {
        get => hp;
        set => hp = value;
    }
   
    void Update()
    {
        if (canMove)
        {
            var deltaX = 0f;
            if (Input.GetKey(KeyCode.D))
            {
                deltaX += 0.05f;
                iswalking = true;
                transform.localScale = new Vector2(1,1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                deltaX -= 0.05f;
                iswalking = true;
                transform.localScale = new Vector2(-1, 1);
            }
            else iswalking = false;
            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);

            animator.SetBool("iswalking", iswalking);

        }
        else animator.SetBool("iswalking", false);

        
    }
}
