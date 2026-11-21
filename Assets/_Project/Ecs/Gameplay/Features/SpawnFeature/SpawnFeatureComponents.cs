using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.SpawnFeature
{
    public class SpawnInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class SpawnCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class InSpawnProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}