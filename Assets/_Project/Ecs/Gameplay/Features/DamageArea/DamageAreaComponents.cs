using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;

namespace Assets._Project.Ecs.Gameplay.Features.DamageArea
{
    public class DamageDelayInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class DamageDelayCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}