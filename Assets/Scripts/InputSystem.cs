using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Platformer
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTag, directionComponent, PlayerComponent> inputFilter = null;

        public void Run()
        {
            foreach (var i in inputFilter)
            {
                ref var directionComponent = ref inputFilter.Get2(i);
                ref var movableComponent = ref inputFilter.Get3(i);
                ref var direction = ref directionComponent.Direction;
                ref var facingRight = ref movableComponent.facingRight;
                ref var runSpeed = ref movableComponent.runSpeed;
                ref var changeRotation = ref movableComponent.changeRotation;
                ref var jumpHeight = ref movableComponent.jumpHeight;
                ref var shootDelay = ref movableComponent.shootDelay;
                ref var shootSpeed = ref movableComponent.shootSpeed;

                if (Input.GetKey("right"))
                {
                    direction.x = runSpeed;
                    direction.y = 0;
                    changeRotation = !facingRight;
                    facingRight = true;
                }
                else if (Input.GetKey("left"))
                {
                    direction.x = -runSpeed;
                    direction.y = 0;
                    changeRotation = facingRight;
                    facingRight = false;
                }
                else
                {
                    direction.x = 0;
                    direction.y = 0;
                }

                if (Input.GetKeyDown("space"))
                {
                    direction.y = jumpHeight;
                }
                
                shootDelay -= Time.deltaTime;
                if (Input.GetKey(KeyCode.A))
                {
                    if (shootDelay < 0)
                    {
                        Debug.Log("shosdf");
                        ref var entity = ref inputFilter.GetEntity(i);
                        ref var spawnBullet = ref entity.Get<SpawnBullet>();
                        shootDelay = shootSpeed;
                    }
                }
            }
        }
    }
}