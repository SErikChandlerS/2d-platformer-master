using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer
{
    [Serializable]
    public struct MovableComponent
    {
        public Rigidbody2D characterController;
        public BoxCollider2D boxCollider;
        public Animator animator;
        public SpriteRenderer spriteRenderer;
        public LayerMask groundCollisionLayer;

        public float runSpeed;
        public float jumpHeight;
        public bool doubleJump;
        public bool facingRight;
        public float shootDelay;
        public float shootSpeed;
        public bool changeRotation;
    }
}