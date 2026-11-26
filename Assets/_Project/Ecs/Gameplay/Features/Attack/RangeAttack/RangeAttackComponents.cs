using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;

namespace Assets._Project.Ecs.Gameplay.Features.Attack.RangeAttack
{
    public class AttackRange : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}