using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Utilities.Conditions;

namespace Assets._Project.Ecs.Gameplay.Features.ExplotionFeatures
{
    public class ExplotionRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class ExplotionDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class ExplodeRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class ExplodeEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class IsExplode :IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class CanExplode : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}