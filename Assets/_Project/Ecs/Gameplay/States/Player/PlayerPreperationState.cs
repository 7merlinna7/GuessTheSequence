using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.InputFeature;
using Assets._Project.Ecs.Gameplay.Features.InputFeature.RaycastFeature;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.States.Player
{
    public class PlayerPreperationState : PlayerGameplayState
    {
        public PlayerPreperationState(EntitiesFactory entitiesFactory, PlayerGameplayRayShooter rayShooter, PlayerInput playerInput) : base(entitiesFactory, rayShooter, playerInput)
        {
        }
        protected override void OnMouseButtonClicked()
        {
            
        }
    }
}