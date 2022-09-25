using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public struct EnemyComponent
    {
        public int health;
        public int deathSpeed;
        public bool dead;
        public bool angry;
        public float idleTimer;
        public float idleSpeed;
        public bool standing;
        public Transform target;
        public bool hit;
    }
}