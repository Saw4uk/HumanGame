using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Player player;

    void Update()
    {
        if (player.transform.position.x < transform.position.x - 5)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
        else if (player.transform.position.x > transform.position.x + 5)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10);
        }
    }
}
