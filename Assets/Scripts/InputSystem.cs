using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;

namespace Platformer
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, directionComponent, MovableComponent> inputFilter = null;

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
                

            }
        }
        
    }
}