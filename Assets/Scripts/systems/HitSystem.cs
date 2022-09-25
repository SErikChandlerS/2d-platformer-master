using Leopotam.Ecs;
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
                        // ref var bulletHit = ref entity.Get<BulletHitComponent>();
                        // bulletHit.raycastHit = hit;
                        var enemyGO = hit.collider.gameObject;
                        enemyGO.TryGetComponent(out ConvertToEntity cte);
                        
                        if (cte.TryGetEntity().HasValue)
                        {
                            var enemyComponent = cte.TryGetEntity().Value.Get<EnemyComponent>();
                            var enemyMoveComp = cte.TryGetEntity().Value.Get<MovableComponent>();
                            
                            enemyComponent.health -= bulletComponent.damage;
                            Debug.Log(enemyComponent.health);
                            if (enemyComponent.health <= 0)
                            {
                                enemyMoveComp.animator.SetInteger("state", 4);
                                Object.Destroy(enemyGO);
                            }
                            if (!enemyComponent.angry & !enemyComponent.dead)
                            {
                                Debug.Log("angry");
                                enemyComponent.angry = true;
                            }
                        }

                    }
                }
            }
            
        }
    }
}