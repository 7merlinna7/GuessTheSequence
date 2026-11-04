namespace Assets._Project.Ecs.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergy MaxTeleportEnergyC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergy>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxTeleportEnergy => MaxTeleportEnergyC.Value;

		public bool TryGetMaxTeleportEnergy(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergy component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetCurrentTeleportEnergy(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergy component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTeleportEnergy()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergy() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTeleportEnergy(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergy() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergyRechargeTime MaxTeleportEnergyRechargeTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergyRechargeTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxTeleportEnergyRechargeTime => MaxTeleportEnergyRechargeTimeC.Value;

		public bool TryGetMaxTeleportEnergyRechargeTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergyRechargeTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMaxTeleportEnergyRechargeTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergyRechargeTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMaxTeleportEnergyRechargeTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.MaxTeleportEnergyRechargeTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEnergyRechargeCoefficient TeleportEnergyRechargeCoefficientC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEnergyRechargeCoefficient>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> TeleportEnergyRechargeCoefficient => TeleportEnergyRechargeCoefficientC.Value;

		public bool TryGetTeleportEnergyRechargeCoefficient(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEnergyRechargeCoefficient component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportEnergyRechargeCoefficient()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEnergyRechargeCoefficient() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportEnergyRechargeCoefficient(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEnergyRechargeCoefficient() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergyRechargeTime CurrentTeleportEnergyRechargeTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergyRechargeTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentTeleportEnergyRechargeTime => CurrentTeleportEnergyRechargeTimeC.Value;

		public bool TryGetCurrentTeleportEnergyRechargeTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergyRechargeTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTeleportEnergyRechargeTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergyRechargeTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTeleportEnergyRechargeTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CurrentTeleportEnergyRechargeTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.EnergyToTeleport EnergyToTeleportC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.EnergyToTeleport>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> EnergyToTeleport => EnergyToTeleportC.Value;

		public bool TryGetEnergyToTeleport(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.EnergyToTeleport component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetTeleprtationRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleprtationRadius component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetCanTeleport(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleport component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanTeleport(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleport() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleportToTarget CanTeleportToTargetC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleportToTarget>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition CanTeleportToTarget => CanTeleportToTargetC.Value;

		public bool TryGetCanTeleportToTarget(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleportToTarget component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanTeleportToTarget(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.CanTeleportToTarget() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest TeleportRequestC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> TeleportRequest => TeleportRequestC.Value;

		public bool TryGetTeleportRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportRequest()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportRequest() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent TeleportEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent TeleportEvent => TeleportEventC.Value;

		public bool TryGetTeleportEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTeleportEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.TeleportEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.DealExplotionDamageEvent DealExplotionDamageEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.DealExplotionDamageEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent DealExplotionDamageEvent => DealExplotionDamageEventC.Value;

		public bool TryGetDealExplotionDamageEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.DealExplotionDamageEvent component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDealExplotionDamageEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.DealExplotionDamageEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDealExplotionDamageEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.DealExplotionDamageEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.RechargeEnergyTimerIsOver RechargeEnergyTimerIsOverC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.RechargeEnergyTimerIsOver>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent RechargeEnergyTimerIsOver => RechargeEnergyTimerIsOverC.Value;

		public bool TryGetRechargeEnergyTimerIsOver(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.RechargeEnergyTimerIsOver component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRechargeEnergyTimerIsOver()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.RechargeEnergyTimerIsOver() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRechargeEnergyTimerIsOver(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.RechargeEnergyTimerIsOver() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.TeleportFeature.InTeleportProcess InTeleportProcessC => GetComponent<Assets._Project.Ecs.Gameplay.Features.TeleportFeature.InTeleportProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InTeleportProcess => InTeleportProcessC.Value;

		public bool TryGetInTeleportProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.TeleportFeature.InTeleportProcess component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInTeleportProcess()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.InTeleportProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInTeleportProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.TeleportFeature.InTeleportProcess() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.BodyCollider BodyColliderC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Sensors.BodyCollider component);
			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.BodyCollider() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Sensors.ContactsDetectingMask component);
			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.ContactsDetectingMask() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.ContactCollidersBuffer ContactCollidersBufferC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.ContactCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> ContactCollidersBuffer => ContactCollidersBufferC.Value;

		public bool TryGetContactCollidersBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Sensors.ContactCollidersBuffer component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddContactCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.ContactCollidersBuffer() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.ContactEntitiesBuffer ContactEntitiesBufferC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.ContactEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> ContactEntitiesBuffer => ContactEntitiesBufferC.Value;

		public bool TryGetContactEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Sensors.ContactEntitiesBuffer component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddContactEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Buffer<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.ContactEntitiesBuffer() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.DeathMask DeathMaskC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Sensors.DeathMask component);
			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.DeathMask() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Sensors.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Sensors.IsTouchDeathMask>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Sensors.IsTouchDeathMask component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Sensors.IsTouchDeathMask() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveDirection MoveDirectionC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MoveDirection => MoveDirectionC.Value;

		public bool TryGetMoveDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveDirection component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

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

		public bool TryGetMoveSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveSpeed component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMoveSpeed()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveSpeed() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMoveSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.MoveSpeed() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.IsMoving IsMovingC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.IsMoving>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.MovementFeatures.IsMoving component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.IsMoving() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddIsMoving(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.IsMoving() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanMove CanMoveC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanMove>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanMove component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanMove(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanMove() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationDirection RotationDirectionC => GetComponent<Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationDirection component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

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

		public bool TryGetRotationSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.MovementFeatures.RotationSpeed component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetCanRotate(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanRotate component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanRotate(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.MovementFeatures.CanRotate() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.CurrentHealth CurrentHealthC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.CurrentHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.CurrentHealth component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetMaxHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.MaxHealth component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetIsDead(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.IsDead component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetMustDie(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustDie component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMustDie(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustDie() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustSelfRelease MustSelfReleaseC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustSelfRelease>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustSelfRelease component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMustSelfRelease(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.MustSelfRelease() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessInitialTime DeathProcessInitialTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DeathProcessInitialTime => DeathProcessInitialTimeC.Value;

		public bool TryGetDeathProcessInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetDeathProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.DeathProcessCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

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

		public bool TryGetInDeathProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.InDeathProcess component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

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

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.LifeCycle.DisableCollidersOnDeath component);
			if (result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = new System.Collections.Generic.List<UnityEngine.Collider>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.LifeCycle.DisableCollidersOnDeath() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionRadius ExplotionRadiusC => GetComponent<Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ExplotionRadius => ExplotionRadiusC.Value;

		public bool TryGetExplotionRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionRadius component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddExplotionRadius()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionRadius() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddExplotionRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionRadius() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionDamage ExplotionDamageC => GetComponent<Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ExplotionDamage => ExplotionDamageC.Value;

		public bool TryGetExplotionDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionDamage component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddExplotionDamage()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddExplotionDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures.ExplotionDamage() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage BodyContactDamageC => GetComponent<Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> BodyContactDamage => BodyContactDamageC.Value;

		public bool TryGetBodyContactDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddBodyContactDamage()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddBodyContactDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage.BodyContactDamage() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackRequest StartAttackRequestC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackRequest => StartAttackRequestC.Value;

		public bool TryGetStartAttackRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackRequest component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddStartAttackRequest()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackRequest() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddStartAttackRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackRequest() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackEvent StartAttackEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent StartAttackEvent => StartAttackEventC.Value;

		public bool TryGetStartAttackEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackEvent component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddStartAttackEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddStartAttackEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.StartAttackEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.EndAttackEvent EndAttackEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.EndAttackEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent EndAttackEvent => EndAttackEventC.Value;

		public bool TryGetEndAttackEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.EndAttackEvent component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddEndAttackEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.EndAttackEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddEndAttackEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.EndAttackEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.CanStartAttack CanStartAttackC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.CanStartAttack>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition CanStartAttack => CanStartAttackC.Value;

		public bool TryGetCanStartAttack(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.CanStartAttack component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanStartAttack(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.CanStartAttack() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessInitialTime AttackProcessInitialTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessInitialTime => AttackProcessInitialTimeC.Value;

		public bool TryGetAttackProcessInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackProcessInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessInitialTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessCurrentTime AttackProcessCurrentTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackProcessCurrentTime => AttackProcessCurrentTimeC.Value;

		public bool TryGetAttackProcessCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackProcessCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackProcessCurrentTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.InAttackProcess InAttackProcessC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.InAttackProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackProcess => InAttackProcessC.Value;

		public bool TryGetInAttackProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.InAttackProcess component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInAttackProcess()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.InAttackProcess() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInAttackProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.InAttackProcess() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayTime AttackDelayTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackDelayTime => AttackDelayTimeC.Value;

		public bool TryGetAttackDelayTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackDelayTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackDelayTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayEndEvent AttackDelayEndEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayEndEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackDelayEndEvent => AttackDelayEndEventC.Value;

		public bool TryGetAttackDelayEndEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayEndEvent component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackDelayEndEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackDelayEndEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.InstantAttackDamage InstantAttackDamageC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.InstantAttackDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> InstantAttackDamage => InstantAttackDamageC.Value;

		public bool TryGetInstantAttackDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.InstantAttackDamage component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInstantAttackDamage()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.InstantAttackDamage() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInstantAttackDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.InstantAttackDamage() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.ShootPoint ShootPointC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.ShootPoint component);
			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.ShootPoint() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.MustCancelAttack MustCancelAttackC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.MustCancelAttack>();

		public Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition MustCancelAttack => MustCancelAttackC.Value;

		public bool TryGetMustCancelAttack(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.MustCancelAttack component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddMustCancelAttack(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.MustCancelAttack() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.AttackCanceledEvent AttackCanceledEventC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.AttackCanceledEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent AttackCanceledEvent => AttackCanceledEventC.Value;

		public bool TryGetAttackCanceledEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.AttackCanceledEvent component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackCanceledEvent() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackCanceledEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackCanceledEvent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownInitialTime AttackCooldownInitialTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownInitialTime => AttackCooldownInitialTimeC.Value;

		public bool TryGetAttackCooldownInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownInitialTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackCooldownInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownInitialTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownCurrentTime AttackCooldownCurrentTimeC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackCooldownCurrentTime => AttackCooldownCurrentTimeC.Value;

		public bool TryGetAttackCooldownCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownCurrentTime component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddAttackCooldownCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.AttackCooldownCurrentTime() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.Attack.InAttackCooldown InAttackCooldownC => GetComponent<Assets._Project.Ecs.Gameplay.Features.Attack.InAttackCooldown>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InAttackCooldown => InAttackCooldownC.Value;

		public bool TryGetInAttackCooldown(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.Attack.InAttackCooldown component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInAttackCooldown()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.InAttackCooldown() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddInAttackCooldown(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.Attack.InAttackCooldown() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageRequest component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

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

		public bool TryGetTakeDamageEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.AplyDamage.TakeDamageEvent component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

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

		public bool TryGetCanApplayDamage(out Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.AplyDamage.CanApplayDamage component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCanApplayDamage(Assets._Project.Ecs.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AplyDamage.CanApplayDamage() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Features.AI.CurrentTarget CurrentTargetC => GetComponent<Assets._Project.Ecs.Gameplay.Features.AI.CurrentTarget>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Features.AI.CurrentTarget component);
			if (result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AI.CurrentTarget() {Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity>() });
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCurrentTarget(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Ecs.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Features.AI.CurrentTarget() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Common.RigidbodyComponent RigidbodyC => GetComponent<Assets._Project.Ecs.Gameplay.Common.RigidbodyComponent>();

		public UnityEngine.Rigidbody Rigidbody => RigidbodyC.Value;

		public bool TryGetRigidbody(out UnityEngine.Rigidbody value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Common.RigidbodyComponent component);
			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.Rigidbody);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddRigidbody(UnityEngine.Rigidbody value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Common.RigidbodyComponent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Common.CharacterControllerComponent CharacterControllerC => GetComponent<Assets._Project.Ecs.Gameplay.Common.CharacterControllerComponent>();

		public UnityEngine.CharacterController CharacterController => CharacterControllerC.Value;

		public bool TryGetCharacterController(out UnityEngine.CharacterController value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Common.CharacterControllerComponent component);
			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.CharacterController);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddCharacterController(UnityEngine.CharacterController value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Common.CharacterControllerComponent() {Value = value}); 
		}

		public Assets._Project.Ecs.Gameplay.Common.TransformComponent TransformC => GetComponent<Assets._Project.Ecs.Gameplay.Common.TransformComponent>();

		public UnityEngine.Transform Transform => TransformC.Value;

		public bool TryGetTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent (out Assets._Project.Ecs.Gameplay.Common.TransformComponent component);
			if (result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Ecs.Gameplay.EntitiesCore.Entity AddTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Ecs.Gameplay.Common.TransformComponent() {Value = value}); 
		}

	}
}
