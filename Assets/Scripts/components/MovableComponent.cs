using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public struct MovableComponent
    {
        public float runSpeed;
        public float jumpHeight;
        public bool doubleJump;
        public bool facingRight;
        public bool changeRotation;
        public Rigidbody2D characterController;
        public BoxCollider2D boxCollider;
        public Animator animator;
        public LayerMask groundCollisionLayer;
    }
}