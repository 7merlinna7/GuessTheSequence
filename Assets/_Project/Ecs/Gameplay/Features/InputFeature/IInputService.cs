using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.InputFeature
{
    public interface IInputService 
    {
        bool IsEnabled { get; set; }

        Vector3 Direction { get;}
    }
}