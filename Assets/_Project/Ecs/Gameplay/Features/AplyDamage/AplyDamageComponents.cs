using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Utilities.Conditions;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AplyDamage
{
    public class TakeDamageRequest : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }

    public class TakeDamageEvent : IEntityComponent
    {
        public ReactiveEvent<float> Value;
    }

    public class CanApplayDamage : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}