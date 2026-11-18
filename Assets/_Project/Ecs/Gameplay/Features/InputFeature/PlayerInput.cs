using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.InputFeature
{
    public class PlayerInput 
    {
        public bool IsMouseButtonClicked => IsEnabled && Input.GetKeyDown(KeyCode.Mouse0);
        public bool IsEnabled { get; set; } = true;

        public void Update(float deltaTime)
        {

        }
    }
}