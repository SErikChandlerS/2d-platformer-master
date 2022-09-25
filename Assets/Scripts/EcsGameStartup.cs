using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace Platformer

{
    public sealed class EcsGameStartup : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;

        private void Start()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            systems.ConvertScene();
            
            AddInjections();
            AddOneFrames();
            AddSystems();
            
            systems.Init();
        }

        private void AddInjections()
        {
            
        }

        private void AddSystems()
        {
            systems.
                Add(new PlayerInputSystem()).
                Add(new MovementSystem()).
                Add(new AnimationSystem()).
                Add(new PlayerShootSystem()).
                Add(new EnemyIdleSystem()).
                Add(new HitSystem());
        }

        private void AddOneFrames()
        {
            
        }

        private void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            systems.Destroy();
            systems = null;
            world.Destroy();
            world = null;
        }
    }
}

