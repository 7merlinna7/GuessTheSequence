using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage;
using Assets._Project.Ecs.Gameplay.Features.LifeCycle;
using Assets._Project.Ecs.Gameplay.Features.MovementFeatures;
using Assets._Project.Ecs.Gameplay.Features.Sensors;
using Assets._Project.Ecs.Utilities.Conditions;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.EntitiesCore
{
    public class EntitiesFactory 
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly CollidersRegistryService _collidersRegistryService;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateGhost(Vector3 position)
        {
           Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/RigidbodyEntity");

            entity
                //компоненты полей
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
                .AddDeathProcessCurrentTime()
                //takeDamage
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(50));

            //компоненты условий
            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage);

            //компоненты систем
            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new ApplyDamageSystem())
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