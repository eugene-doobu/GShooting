using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private int health;
        [SerializeField] private int score;

        private Rigidbody2D _rigid;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("PLAYERBULLET"))
            {
                var bullet = col.gameObject.GetComponent<Bullet>();
                OnHit(bullet.Damege);
                Destroy(bullet.gameObject);
            }
        }

        protected void OnHit(int dmg)
        {
            health -= dmg;
            if (health <= 0)
            {
                Destroy(gameObject);
                StageManager.Instance.Score += score;
            }
        }
    }
}
