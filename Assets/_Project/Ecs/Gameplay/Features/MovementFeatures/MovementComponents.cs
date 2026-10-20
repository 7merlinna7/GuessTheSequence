using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.MovementFeatures
{
    public class MoveDirection: IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveSpeed: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}