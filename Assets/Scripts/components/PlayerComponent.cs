using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer
{
    [Serializable]
    public struct PlayerComponent
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float bulletSpeed;
        public int damage;
        public float shootDelay;
        public float shootSpeed;
        public LayerMask bulletCollisionLayer;

    }
}