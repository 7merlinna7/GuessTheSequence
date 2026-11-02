using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features
{
    public class GismosGrawer : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        private void Update()
        {
            
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_transform.position, 3f);
        }
    }
}