using Assets._Project.Develop.Runtime.Configs.Entities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using Assets._Project.Ecs.Gameplay.Features.AplyDamage;
using Assets._Project.Ecs.Gameplay.Features.Attack;
using Assets._Project.Ecs.Gameplay.Features.Attack.RangeAttack.Shoot;
using Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage;
using Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures;
using Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.BombFeature;
using Assets._Project.Ecs.Gameplay.Features.LifeCycle;
using Assets._Project.Ecs.Gameplay.Features.MovementFeatures;
using Assets._Project.Ecs.Gameplay.Features.Sensors;
using Assets._Project.Ecs.Gameplay.Features.SpawnFeature;
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

        public Entity CreateDamageArea(Vector3 position,float damage, Teams team)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/DamageArea");

            entity
                .AddTeam(new ReactiveVariable<Teams>(team))
                .AddIsDead()
                .AddContactsDetectingMask((Layers.TowersMask | Layers.CharactersMask))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(damage))
                .AddDamageDelayInitialTime(new ReactiveVariable<float>(0.5f))
                .AddDamageDelayCurrentTime();

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddMustSelfRelease(mustSelfRealese);

            DealDamageOnContactSystem dealDamageOnContactSystem = new DealDamageOnContactSystem();

            entity
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(dealDamageOnContactSystem) //сделать сброс списка через ивент
                .AddSystem(new BodyContactsResetTimerSystem(dealDamageOnContactSystem))
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateProjectile(Vector3 position, Vector3 direction, float damage,Teams team)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Projectile");

            entity
                //компоненты полей
                .AddTeam(new ReactiveVariable<Teams>(team))
                //move
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(80))
                .AddIsMoving()
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVariable<float>(9999))
                //death
                .AddIsDead()
                //Damage
                .AddContactsDetectingMask((Layers.TowersMask | Layers.CharactersMask))
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(damage))
                .AddDeathMask((Layers.EnvironmentMask))
                .AddIsTouchDeathMask()
                .AddIsTouchAnotherTeam()
                ;

            //компоненты условий
            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value == true))
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value == true));

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));


            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese);

            //компоненты систем
            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }


        public Entity CreateBomb(Vector3 position, Teams team,float explotionRadius, float explotionDamage)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Bomb");

            entity
                .AddIsDead()

                .AddIsExplode()
                .AddExplodeEvent()
                .AddExploded()
                .AddTeam(new ReactiveVariable<Teams>(team))
                .AddExplotionRadius(new ReactiveVariable<float>(explotionRadius))
                .AddExplotionDamage(new ReactiveVariable<float>(explotionDamage))

                .AddContactsDetectingMask(Layers.CharactersMask | Layers.TowersMask)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddMustSelfRelease(mustSelfRealese);

            entity
                .AddSystem(new BombTriggerSystem(_collidersRegistryService))
                .AddSystem(new ExplodeCreatorSystem(this))
                .AddSystem(new OnExplodeDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext))
                ;

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateExplotion(Vector3 position,Teams team, float explotionRadius, float explotionDamage)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Explotion");

            entity
                .AddIsExplode()
                .AddExplotionRadius(new ReactiveVariable<float>(explotionRadius))
                .AddExplotionDamage(new ReactiveVariable<float>(explotionDamage))
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

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddMustDie(mustDie)
                .AddCanApplayDamage(canApplyDamage);

            //компоненты систем
            entity
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateRangeStayEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/RangeStayingEntity");

            entity
                //компоненты полей
                //spawn
                .AddSpawnInitialTime(new ReactiveVariable<float>(0))
                .AddSpawnCurrentTime()
                .AddInSpawnProcess()
                //rotation
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(600))
                //health
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new ReactiveVariable<float>(100))
                //death
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(0))
                .AddDeathProcessCurrentTime()
                //takeDamage
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                //target
                .AddTeam(new ReactiveVariable<Teams>(Teams.Player))
                .AddCurrentTarget()
                //--------------------------------------------------------------------------------------
                //attack
                //stats
                .AddInstantAttackDamage(new ReactiveVariable<float>(20))       //урон атаки
                .AddAttackDelayTime(new ReactiveVariable<float>(0.2f))         //задержка перед атакой
                //events
                .AddStartAttackRequest()
                .AddAttackDelayEndEvent()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                //bool
                .AddInAttackProcess()
                .AddInAttackCooldown()
                //timers
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(1)) //длительность атаки
                .AddAttackProcessCurrentTime()

                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(1)) //перезарядка атаки
                .AddAttackCooldownCurrentTime()
                ;

            //компоненты условий

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));

            entity
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage)
                .AddCanStartAttack(canStartAttack);

            entity
                .AddSystem(new SpawnProcessTimerSystem())

                .AddSystem(new RigidbodyRotationSystem())

                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(this))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTymerSystem())

                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateRangeWalkingEntity(Vector3 position,RangeEnemyConfig config)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, config.PrefabPath);

            entity
                //компоненты полей
                //spawn
                .AddSpawnInitialTime(new ReactiveVariable<float>(config.SpawnProcessTime))
                .AddSpawnCurrentTime()
                .AddInSpawnProcess()
                //move
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(config.MoveSpeed))
                .AddIsMoving()
                //rotation
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
                //target
                .AddTeam(new ReactiveVariable<Teams>(Teams.Enemies))
                .AddCurrentTarget()
                //--------------------------------------------------------------------------------------
                //attack
                //stats
                .AddInstantAttackDamage(new ReactiveVariable<float>(config.InstantAttackDamage)) //урон атаки
                .AddAttackRange(new ReactiveVariable<float>(config.AttackRange))                 //дальность атаки
                .AddAttackDelayTime(new ReactiveVariable<float>(config.AttackDelayTime))         //задержка перед атакой
                //events
                .AddStartAttackRequest()
                .AddAttackDelayEndEvent()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                //bool
                .AddInAttackProcess()
                .AddInAttackCooldown()
                //timers
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(config.AttackProcessInitialTime)) //длительность атаки
                .AddAttackProcessCurrentTime()

                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(config.AttackCooldownInitialTime)) //перезарядка атаки
                .AddAttackCooldownCurrentTime()
                ;

            //компоненты условий
            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage)
                .AddCanStartAttack(canStartAttack);

            entity
                .AddSystem(new SpawnProcessTimerSystem())

                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())

                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(this))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTymerSystem())

                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateWalkingExplotionEntity(Vector3 position,GhostConfig config)
        {
           Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position,config.PrefabPath);

            entity
                //компоненты полей
                .AddIsExplode()
                .AddExplodeEvent()
                .AddExploded()
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

                .AddTeam(new ReactiveVariable<Teams>(Teams.Enemies))
                .AddCurrentTarget()
                //spawn
                .AddSpawnInitialTime(new ReactiveVariable<float>(config.SpawnProcessTime))
                .AddSpawnCurrentTime()
                .AddInSpawnProcess()
                ;
            ;

            //компоненты условий
            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRealese = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canExplode = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRealese)
                .AddCanApplayDamage(canApplyDamage)
                .AddCanExplode(canExplode);

            //компоненты систем
            entity
                .AddSystem(new SpawnProcessTimerSystem())
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())

                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext))


                .AddSystem(new ExplodeCreatorSystem(this))
                .AddSystem(new OnExplodeDeathSystem());

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}