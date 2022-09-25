using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer
{
    public struct BulletComponent
    {
        public float bulletSpeed;
        public Rigidbody2D rb;
        public int damage;
        public GameObject bulletPrefab;
        public Transform firePoint;
    }
}