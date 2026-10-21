using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using Assets._Project.Ecs.Gameplay.Features.LifeCycle;
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

        public Entity CreateGhost(Vector3 position)
        {
           Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/RigidbodyEntity");

            entity
                //move
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(900))
                //health
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new ReactiveVariable<float>(100))
                //death
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(2))
                .AddDeathProcessCurrentTime();

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateCharacterControllerEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();
            _monoEntitiesFactory.Create(entity, position, "Entities/ControllerEntity");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(900));


            entity
                .AddSystem(new CharacterControllerMovementSystem())
                .AddSystem(new CharacterControllerRotationSystem());

            _entitiesLifeContext.Add(entity);
            return entity;
        }
        private Entity CreateEmpty() => new Entity();
    }
}