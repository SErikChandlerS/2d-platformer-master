using Leopotam.Ecs;
using UnityEngine;

namespace Platformer
{
    sealed class EnemyIdleSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<MovableComponent, EnemyComponent, directionComponent> enemyFilter = null;
        
        public void Run()
        {
            foreach (var i in enemyFilter)
            {
                ref var movableComponent = ref enemyFilter.Get1(i);
                ref var enemy = ref enemyFilter.Get2(i);
                ref var direction = ref enemyFilter.Get3(i).Direction;
                ref var idleTimer = ref enemy.idleTimer;
                ref var idleSpeed = ref enemy.idleSpeed;
                ref var rb = ref movableComponent.characterController;
                ref var standing = ref enemy.standing;
                ref var facingRight = ref movableComponent.facingRight;
                ref var speed = ref movableComponent.runSpeed;
                ref var changeRotation = ref movableComponent.changeRotation;

                idleTimer -= Time.deltaTime;
                if (!enemy.angry)
                {
                    if (idleTimer < 0)
                    {
                        if (standing)
                        {
                            if (facingRight)
                            {
                                changeRotation = true;
                                direction.x = -speed;
                                direction.y = 0;
                                facingRight = false;
                            }
                            else
                            {
                                changeRotation = true;
                                direction.x = speed;
                                direction.y = 0;
                                facingRight = true;
                            }

                            standing = false;
                        }
                        else
                        {
                            changeRotation = false;
                            direction.x = 0;
                            direction.y = 0;
                            standing = true;
                        }

                        idleTimer = idleSpeed;
                    }
                }

                if (enemy.angry)
                {
                    if (enemy.target.position.x < rb.position.x)
                    {
                        direction.x = -speed;
                        direction.y = 0;
                        if (facingRight)
                        {
                            changeRotation = true;
                            facingRight = false;
                        }
                    }
                    else
                    {
                        direction.x = speed;
                        direction.y = 0;
                        if (!facingRight)
                        {
                            changeRotation = true;
                            facingRight = true;
                        }
                    }
                }
               
            }
            
        }
    }
}