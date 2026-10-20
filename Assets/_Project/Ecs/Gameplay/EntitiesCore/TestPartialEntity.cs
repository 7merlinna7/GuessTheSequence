using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.Features.MovementFeatures;
using System.Collections;
using UnityEngine;
using static Assets._Project.Ecs.Gameplay.Common.CommonComponents;

namespace Assets._Project.Ecs.Gameplay.EntitiesCore
{
    public partial class Entity
    {
        //public RigidbodyComponent RigidbodyC => GetComponent<RigidbodyComponent>();

        //public Rigidbody Rigidbody => RigidbodyC.Value;

        //public Entity AddRigidbody(Rigidbody value)
        //{
        //    return AddComponent(new RigidbodyComponent() { Value = value });
        //}

        //public MoveDirection MoveDirectionC => GetComponent<MoveDirection>();

        //public ReactiveVariable<Vector3> MoveDirection => MoveDirectionC.Value;

        //public Entity AddMoveDirection(ReactiveVariable<Vector3> value)
        //{
        //    return AddComponent(new MoveDirection() { Value = value });
        //}

        //public Entity AddMoveDirection()
        //{
        //    return AddComponent(new MoveDirection() { Value = new ReactiveVariable<Vector3>() });
        //}
    }
}