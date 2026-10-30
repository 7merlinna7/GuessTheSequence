using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Attack.Shoot
{
    public class ShootPointEntityRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _shootPoint;

        public override void Register(Entity entity)
        {
            entity.AddShootPoint(_shootPoint);
        }
    }
}