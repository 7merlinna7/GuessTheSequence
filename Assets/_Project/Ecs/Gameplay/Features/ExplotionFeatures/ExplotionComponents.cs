using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;

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
}