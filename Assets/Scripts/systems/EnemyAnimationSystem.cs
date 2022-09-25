using System;
using UnityEngine;
using Leopotam.Ecs;

namespace Platformer
{
    sealed class EnemyAnimationSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<EnemyTag, MovableComponent, EnemyComponent> enemyFilter = null;
        
        public void Run()
        {
            foreach (var i in enemyFilter)
            {
                ref var movableComponent = ref enemyFilter.Get2(i);
                ref var enemyComponent = ref enemyFilter.Get3(i);
                ref var rb = ref movableComponent.characterController;
                ref var animator = ref movableComponent.animator;
                ref var entity = ref enemyFilter.GetEntity(i);
                
                if (enemyComponent.dead)
                {
                    animator.SetInteger("state", 3);
                    var enemyTransform = movableComponent.characterController.transform;
                    movableComponent.boxCollider.enabled = false;
                    enemyTransform.position = Vector2.MoveTowards(
                        enemyTransform.position, 
                        new Vector2(enemyTransform.position.x, 
                            enemyTransform.position.y + 15), 
                        enemyComponent.deathSpeed * Time.deltaTime
                    );
                    entity.Destroy();
                }
                else
                {
                    animator.SetInteger("state", rb.velocity.x != 0 ? 1 : 0);
                }
            }
        }
    }
}