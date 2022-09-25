using Leopotam.Ecs;
using UnityEditor;
using UnityEngine;
using Voody.UniLeo;
using Object = UnityEngine.Object;

namespace Platformer
{
    sealed class HitSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<BulletComponent> bulletFilter = null;
        
        public void Run()
        {
            foreach (var i in bulletFilter)
            {
                ref var bulletComponent = ref bulletFilter.Get1(i);
                ref var rb = ref bulletComponent.rb;
                var transform = rb.transform;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, 
                    transform.up, 0,
                    bulletComponent.bulletCollisionLayer
                    );
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("PigMob"))
                    {
                        var entity = bulletFilter.GetEntity(i);

                        var enemyGO = hit.collider.gameObject;
                        enemyGO.TryGetComponent(out ConvertToEntity cte);
                        
                        if (cte.TryGetEntity().HasValue)
                        {
                            var enemyEntity = cte.TryGetEntity().Value;
                            ref var enemyComponent = ref cte.TryGetEntity().Value.Get<EnemyComponent>();
                            ref var enemyMoveComp = ref cte.TryGetEntity().Value.Get<MovableComponent>();
                            
                            enemyComponent.health -= bulletComponent.damage;
                            Debug.Log(enemyComponent.health);
                            if (enemyComponent.health <= 0)
                            {
                                enemyComponent.dead = true;

                            }
                            if (!enemyComponent.angry & !enemyComponent.dead)
                            {
                                enemyComponent.angry = true;
                            }
                            enemyComponent.hit = true;
                        }
                        
                        Object.Destroy(bulletComponent.bulletPrefab);
                        entity.Destroy();
                    }

                }
            }
            
        }
    }
}