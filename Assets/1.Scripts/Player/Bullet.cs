using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damege;

    public int Damege => damege;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("BORDER"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
