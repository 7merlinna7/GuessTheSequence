using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using Assets._Project.Ecs.Gameplay.Features.MovementFeatures;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.EntitiesCore
{
    public class EntitiesFactory 
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
        }

        public Entity CreateTestEntity(Vector3 position)
        {
           Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/TestEntity");

            entity
                .AddComponent(new MoveDirection() { Value = new ReactiveVariable<Vector3>(Vector3.forward) })
                .AddComponent(new MoveSpeed() { Value = new ReactiveVariable<float>(10) });

            entity.AddSystem(new MovementSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}