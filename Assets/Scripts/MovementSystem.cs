using Leopotam.Ecs;

namespace Platformer
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<MovableComponent> movableFilter = null;

        public void Run()
        {
            
        }
    }
}