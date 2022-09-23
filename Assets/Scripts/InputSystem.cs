using Leopotam.Ecs;
using UnityEngine;

namespace Platformer
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;
        
        private float runSpeed = 10.0f;
        private float jumpHeight = 25.0f;
        private bool doubleJump = true;
        private bool facingRight = true;
        private float shootDelay;
        private float shootSpeed = 0.3f;

        public void Run()
        {
            foreach (var i in directionFilter)
            {
                ref var directionComponent = ref directionFilter.Get2(i);
                
                if (Input.GetKey("right")) {
   
                } else if (Input.GetKey("left")) {

                } else {

                }
                if (Input.GetKeyDown("space")) {

                }
                if (Input.GetButton("Fire1")) {

                }
            }
        }

        public void SetDirection()
        {
            
        }
    }
}