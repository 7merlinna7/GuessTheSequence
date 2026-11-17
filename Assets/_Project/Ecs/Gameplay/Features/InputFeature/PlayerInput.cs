using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.InputFeature
{
    public class PlayerInput 
    {
        private bool _isMouseButtonClicked;
        public bool IsMouseButtonClicked => _isMouseButtonClicked;
        public bool IsEnabled { get; set; } = true;

        public void Update(float deltaTime)
        {
            if (IsEnabled == false)
            {
                _isMouseButtonClicked = false;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
                _isMouseButtonClicked = true;
            else 
                _isMouseButtonClicked = false;
        }
    }
}