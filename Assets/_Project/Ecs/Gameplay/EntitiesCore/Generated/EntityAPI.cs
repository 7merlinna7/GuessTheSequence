namespace Assets._Project.Ecs.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergy MaxTeleportEnergyC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergy>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxTeleportEnergy => MaxTeleportEnergyC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMaxTeleportEnergy()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergy() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMaxTeleportEnergy(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergy() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergy CurrentTeleportEnergyC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergy>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentTeleportEnergy => CurrentTeleportEnergyC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTeleportEnergy()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergy() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTeleportEnergy(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergy() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.EnergyToTeleport EnergyToTeleportC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.EnergyToTeleport>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyToTeleport => EnergyToTeleportC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddEnergyToTeleport()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.EnergyToTeleport() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddEnergyToTeleport(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.EnergyToTeleport() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleprtationRadius TeleprtationRadiusC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleprtationRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleprtationRadius => TeleprtationRadiusC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleprtationRadius()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleprtationRadius() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleprtationRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleprtationRadius() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleport CanTeleportC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleport>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition CanTeleport => CanTeleportC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanTeleport(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleport() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest TeleportRequestC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportRequest => TeleportRequestC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportRequest()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent TeleportEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportEvent => TeleportEventC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.IsTeleporting IsTeleportingC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.IsTeleporting>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTeleporting => IsTeleportingC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsTeleporting()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.IsTeleporting() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsTeleporting(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.IsTeleporting() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveDirection MoveDirectionC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMoveDirection()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveDirection() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMoveDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveDirection() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveSpeed MoveSpeedC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MoveSpeed => MoveSpeedC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMoveSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveSpeed() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanMove CanMoveC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanMove>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanMove(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanMove() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationDirection RotationDirectionC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationDirection() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRotationDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationDirection() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationSpeed RotationSpeedC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRotationSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationSpeed() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanRotate CanRotateC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanRotate>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanRotate(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanRotate() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.CurrentHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.CurrentHealth() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.CurrentHealth() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.MaxHealth MaxHealthC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.MaxHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.MaxHealth() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMaxHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.MaxHealth() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.IsDead IsDeadC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.IsDead>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.IsDead() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsDead(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.IsDead() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustDie MustDieC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustDie>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMustDie(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustDie() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMustSelfRelease(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDeathProcessInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessInitialTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessCurrentTime DeathProcessCurrentTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessCurrentTime => DeathProcessCurrentTimeC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDeathProcessCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessCurrentTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.InDeathProcess InDeathProcessC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.InDeathProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.InDeathProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInDeathProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.InDeathProcess() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = new System.Collections.Generic.List<UnityEngine.Collider>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddBodyContactDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageRequest() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.AplyDamage.CanApplayDamage CanApplayDamageC => GetComponent<Assets._Project.Ecs.Gameplay.Features.AplyDamage.CanApplayDamage>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition CanApplayDamage => CanApplayDamageC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanApplayDamage(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AplyDamage.CanApplayDamage() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Project.Ecs.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<Assets._Project.Ecs.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Common.CharacterControllerComponent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Common.TransformComponent TransformC => GetComponent<Assets._Project.Ecs.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Common.TransformComponent() {Value = value}); 
		}

	}
}
