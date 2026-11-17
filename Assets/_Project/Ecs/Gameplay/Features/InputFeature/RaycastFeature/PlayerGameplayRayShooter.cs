using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature
{
    public class PlayerGameplayRayShooter 
    {
        private Plane plane = new Plane(Vector3.down, 0);

        public Vector3 Shoot()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            plane.Raycast(ray, out float distance);

            return ray.GetPoint(distance);
        }
    }
}