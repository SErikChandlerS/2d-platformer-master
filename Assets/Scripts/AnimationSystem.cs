using Leopotam.Ecs;

namespace Platformer
{

    sealed class AnimationSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<PlayerTag, PlayerComponent> playerFilter = null;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var playerComponent = ref playerFilter.Get2(i);
                ref var rb = ref playerComponent.characterController;
                ref var animator = ref playerComponent.animator;
                ref var djump = ref playerComponent.doubleJump;

                animator.SetInteger("state", rb.velocity.x != 0 ? 1 : 0);

                if (rb.velocity.y > 0.1)
                {
                    animator.SetInteger("state", djump ? 2 : 3);
                }
                if (rb.velocity.y < -0.1)
                {
                    animator.SetInteger("state", 4);
                }

            }
            
        }
    }
}