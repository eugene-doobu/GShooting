using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerShot : MonoBehaviour
    {
        [Header("Bullets Parameters")]
        [SerializeField] private float bulletSpeed = 7f;
        [SerializeField] private float shotMargin = 0.5f;
        [SerializeField] private float maxShotDelay = 0.1f;
        [SerializeField] private float bulletPower = 1f;
        
        [Header("Bullets Obj")] 
        [SerializeField] private GameObject bulletObj_A;
        [SerializeField] private GameObject bulletObj_B;

        [Header("Shot Offset")] 
        [SerializeField] private float shotOffset2 = 0.3f;
        [SerializeField] private float shotOffset3 = 0.5f;
        
        private float _currShotDelay;
        private Transform _tr;

        private void Awake()
        {
            _tr = GetComponent<Transform>();
        }

        public void Fire()
        {
            // TODO: Instance pool, 2Type Shot
            if (!Input.GetButton("Fire1")) return;
            if (_currShotDelay < maxShotDelay) return;

            switch (bulletPower)
            {
                case 1:
                    ShotBullet(Vector3.zero);
                    break;
                case 2:
                    ShotBullet(Vector3.up * shotOffset2);
                    ShotBullet(-Vector3.up * shotOffset2);
                    break;
                case 3:
                    ShotBullet(Vector3.up * shotOffset3);
                    ShotBullet(Vector3.zero, true);
                    ShotBullet(-Vector3.up * shotOffset3);
                    break;
            }
            _currShotDelay = 0;
        }

        public void ShotBullet(Vector3 offset, bool isBigShot = false)
        {
            GameObject bullet;
            if (isBigShot)
            {
                bullet = Instantiate(
                    bulletObj_B,
                    _tr.position + Vector3.right * shotMargin,
                    _tr.rotation
                );
            }
            else
            {
                bullet = Instantiate(
                    bulletObj_A,
                    _tr.position + Vector3.right * shotMargin + offset,
                    _tr.rotation
                );
            }
            var bulletRigid = bullet.GetComponent<Rigidbody2D>();
            bulletRigid.AddForce(Vector2.right * bulletSpeed, ForceMode2D.Impulse); 
        }

        public void Reload()
        {
            _currShotDelay += Time.deltaTime;
        }
    
    }
}
