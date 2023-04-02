using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int hp;
    public bool canMove = true;

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
            }
            if (Input.GetKey(KeyCode.A))
            {
                deltaX -= 0.05f;
            }
            transform.position = new Vector2(transform.position.x + deltaX, transform.position.y);
        }
    }
}
