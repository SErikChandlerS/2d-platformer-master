using Leopotam.Ecs;
using UnityEngine;

namespace Platformer
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ModelComponent, MovableComponent, directionComponent> movableFilter = null;

        public void Run()
        {
            foreach (var i in movableFilter)
            {
                ref var modelComponent = ref movableFilter.Get1(i);
                ref var movableComponent = ref movableFilter.Get2(i);
                ref var directionComponent = ref movableFilter.Get3(i);

                ref var direction = ref directionComponent.Direction;
                ref var transform = ref modelComponent.modelTransform;

                ref var characterController = ref movableComponent.characterController;
                ref var changeRotation = ref movableComponent.changeRotation;
                ref var boxCollider = ref movableComponent.boxCollider;
                ref var groundCollisionLayer = ref movableComponent.groundCollisionLayer;
                ref var doubleJump = ref movableComponent.doubleJump;
                
                if (changeRotation)
                {
                    transform.Rotate(0, 180, 0);
                    changeRotation = false;
                }
                
                characterController.velocity = new Vector2(direction.x, characterController.velocity.y);
                if (direction.y != 0)
                {
                    if (grounded(boxCollider, groundCollisionLayer))
                    {
                        doubleJump = true;
                        characterController.velocity = new Vector2(characterController.velocity.x, direction.y);
                    }
                    else if (doubleJump)
                    {
                        doubleJump = false;
                        characterController.velocity = new Vector2(characterController.velocity.x, direction.y);
                    }
                }

            }
            
        }
        private bool grounded(BoxCollider2D boxCollider, LayerMask groundCollisionLayer) {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundCollisionLayer);
            return hit.collider != null;
        }
    }
}