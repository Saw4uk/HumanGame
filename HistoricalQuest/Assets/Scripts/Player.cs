using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private int hp = 3;
    private int rightAnswers;
    public bool canMove = true;
    
    private bool isWalking;
    private const float SPEED = 0.05f;
    
    
    [SerializeField]private Animator animator;
    
    public event Action hpChanged; 
    public event Action answersChanged;

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
        if (canMove && Game.Instance != null && Game.Instance.IsGameOver != true)
        {
            var deltaX = 0f;
            if (Input.GetKey(KeyCode.D))
            {
                deltaX += SPEED;
                isWalking = true;
                transform.localScale = new Vector2(1,1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                deltaX -= SPEED;
                isWalking = true;
                transform.localScale = new Vector2(-1, 1);
            }
            else isWalking = false;
            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);

            animator.SetBool("iswalking", isWalking);

        }
        else animator.SetBool("iswalking", false);

        
    }
   
}
