using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private int hp = 5;
    private int rightAnswers = 0;
    public bool canMove = true;
    
    private bool iswalking = false;
    [SerializeField] private const float SPEED = 0.05f;
    
    
    [SerializeField]private Animator animator;
    public static Player Instance { get; set; }
    public event Action hpChanged; 
    public event Action answersChanged;

    private void Awake()
    {
        
    }

    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            hpChanged.Invoke();
        }
    }

    public int RightAnswers
    {
        get => rightAnswers;
        set  {
            rightAnswers = value;
            answersChanged.Invoke();
        }
    }

    void Update()
    {
        if (canMove)
        {
            var deltaX = 0f;
            if (Input.GetKey(KeyCode.D))
            {
                deltaX += SPEED;
                iswalking = true;
                transform.localScale = new Vector2(1,1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                deltaX -= SPEED;
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
