using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.TowerFeature
{
    public class IsTower :IEntityComponent
    {
        ReactiveVariable<bool> Value = new ReactiveVariable<bool>(true);
    }
}