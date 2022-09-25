using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer
{
    [Serializable]
    public struct PlayerComponent
    {
        public Rigidbody2D characterController;
        public BoxCollider2D boxCollider;
        public Animator animator;
        public LayerMask groundCollisionLayer;
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float bulletSpeed;
        public int damage;

        public float runSpeed;
        public float jumpHeight;
        public bool doubleJump;
        public bool facingRight;
        public float shootDelay;
        public float shootSpeed;
        public bool changeRotation;
    }
}