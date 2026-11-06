using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.InputFeature
{
    public class MouseInputForHorizontalRotation : IInputService
    {
        private const string mouseXName = "Mouse X";

        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                float mouseInput = Input.GetAxisRaw(mouseXName);
                return new Vector3(0, mouseInput, 0);
            }
        }
    }
}