using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Common
{
    public class TransformEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddTransform(GetComponent<Transform>());
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(GetComponent<Transform>().position, 3f);
        }
    }
}