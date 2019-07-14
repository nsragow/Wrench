using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Data : MonoBehaviour
{

    Player player;

    [SerializeField]
    bool p2;
    

    private void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("Collided");

        if (col.gameObject.CompareTag("Bolt") && col.gameObject != player.c_bolt)
        {
            player.c_bolt = col.gameObject;
            player.target = col.gameObject.GetComponent<Transform>();
            player.Attach_Bolt(transform, p2, col.transform);
        }
    }
}
