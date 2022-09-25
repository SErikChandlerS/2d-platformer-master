
using System;
using Leopotam.Ecs;

using UnityEngine;
using Object = UnityEngine.Object;


namespace Platformer
{
    sealed class PlayerShootSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerComponent, SpawnBullet> playerFilter = null;
        
        public void Run()
        {
            foreach (var i in playerFilter)
            {
                Debug.Log("shoot");
                ref var player = ref playerFilter.Get1(i);
                ref var bulletPrefab = ref player.bulletPrefab;
                ref var firePoint = ref player.firePoint;
                try
                {
                    var bulletGO = Object.Instantiate(player.bulletPrefab, firePoint.position, firePoint.rotation);
                    var bulletEntity = _world.NewEntity();
                    ref var bullet = ref bulletEntity.Get<BulletComponent>();

                    bullet.rb = bulletGO.GetComponent<Rigidbody2D>();
                    bullet.damage = player.damage;
                    bullet.firePoint = player.firePoint;
                    bullet.bulletSpeed = player.bulletSpeed;
                    bullet.bulletPrefab = bulletPrefab;
                    bullet.bulletCollisionLayer = player.bulletCollisionLayer;

                    bullet.rb.velocity = bullet.rb.transform.right * bullet.bulletSpeed;

                    ref var entity = ref playerFilter.GetEntity(i);
                    entity.Del<SpawnBullet>();
                    
                }
                catch (NullReferenceException)
                {
                    Debug.Log("dsfsdf");
                }

            }    
        }
    }
}