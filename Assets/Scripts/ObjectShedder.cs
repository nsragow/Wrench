﻿using UnityEngine;

public class ObjectShedder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
    }
}
