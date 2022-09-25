using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public struct EnemyComponent
    {
        public Animator animator;
        public int health;
        public int deathSpeed;
        public Rigidbody2D rb;
        private BoxCollider2D boxCollider;
        private bool dead;
        private bool angry;
    }
}