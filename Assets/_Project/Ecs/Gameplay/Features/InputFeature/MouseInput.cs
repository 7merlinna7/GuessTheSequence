using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.InputFeature
{
    public class MouseInput 
    {
        public bool IsMouseButtonClicked => IsEnabled && Input.GetKeyDown(KeyCode.Mouse0);
        public bool IsEnabled { get; set; } = true;

    }
}