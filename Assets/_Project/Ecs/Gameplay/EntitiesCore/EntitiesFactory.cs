using Assets._Project.Develop.Runtime.Configs.Entities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures;
using Assets._Project.Ecs.Gameplay.Features.LifeCycle;
using Assets._Project.Ecs.Gameplay.Features.MovementFeatures;
using Assets._Project.Ecs.Gameplay.Features.Sensors;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
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

        public Entity CreateExplotion(Vector3 position,Teams team)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Explotion");

            entity
                .AddIsExplode()
                .AddExplotionRadius(new ReactiveVariable<float>(3))
                .AddExplotionDamage(new ReactiveVariable<float>(50))
                .AddTeam(new ReactiveVariable<Teams>(team))
                .AddExplodeRequest()
                .AddDealExplotionDamageEvent()

                .AddContactsDetectingMask(Layers.CharactersMask | Layers.TowersMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));


            //systems
            entity
                .AddSystem(new ExplotionContactsDetectingSystem(_entitiesLifeContext))
                .AddSystem(new ExplotionContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnExplotionSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateTower(Vector3 position,float health)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Tower");

            entity
                //компоненты полей
                .AddIsTower(new ReactiveVariable<bool>(true))
                // health
                .AddMaxHealth(new ReactiveVariable<float>(health))
                .AddCurrentHealth(new ReactiveVariable<float>(health))
                //death
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(0))
                .AddDeathProcessCurrentTime()
                //takeDamage
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddTeam(new ReactiveVariable<Teams>(Teams.Player));

            //компоненты условий
            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage);

            //компоненты систем
            entity
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateWalkingGhost(Vector3 position,GhostConfig config)
        {
           Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/WalkingGhost");

            entity
                //компоненты полей
                .AddIsExplode()
                .AddExplotionDamage(new ReactiveVariable<float>(50f))
                .AddExplotionRadius(new ReactiveVariable<float>(3f))
                //move
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(config.MoveSpeed))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                //health
                .AddMaxHealth(new ReactiveVariable<float>(config.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(config.MaxHealth))
                //death
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(config.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                //takeDamage
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                ;
            ;

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

            ICompositeCondition canExplode = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage)
                .AddCanExplode(canExplode);

            //компоненты систем
            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext))
                ;

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}