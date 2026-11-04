using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Utilities.Conditions;
using System.Numerics;

namespace Assets._Project.Ecs.Gameplay.Features.TeleportFeature
{
    public class MaxTeleportEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CurrentTeleportEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MaxTeleportEnergyRechargeTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportEnergyRechargeCoefficient : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CurrentTeleportEnergyRechargeTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class EnergyToTeleport : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleprtationRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanTeleport : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class CanTeleportToTarget : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class TeleportRequest : IEntityComponent
    {
        public ReactiveEvent<UnityEngine.Vector3> Value;
    }

    public class TeleportEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class DealExplotionDamageEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class RechargeEnergyTimerIsOver : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InTeleportProcess :IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}