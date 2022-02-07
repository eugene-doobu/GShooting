using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected int health;
        [SerializeField] protected int score;

        protected Rigidbody2D Rigid;

        private void Awake()
        {
            Rigid = GetComponent<Rigidbody2D>();
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
