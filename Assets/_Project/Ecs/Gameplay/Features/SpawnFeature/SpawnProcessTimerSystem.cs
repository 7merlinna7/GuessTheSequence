using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.SpawnFeature
{
    public class SpawnProcessTimerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<float> _currentTime;

        private ReactiveVariable<bool> _inSpawnProcess;

        public void OnInit(Entity entity)
        {
            _initialTime = entity.SpawnInitialTime;
            _currentTime = entity.SpawnCurrentTime;
            _inSpawnProcess = entity.InSpawnProcess;

            _currentTime.Value = 0;
            _inSpawnProcess.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_inSpawnProcess.Value == false)
                return;

            _currentTime.Value += deltaTime;

            if (_currentTime.Value >= _initialTime.Value)
                _inSpawnProcess.Value = false;
        }
    }
}