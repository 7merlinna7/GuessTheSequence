using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;

namespace Assets._Project.Ecs.Gameplay.Features.ContactTakeDamage
{
    public class BodyContactDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}