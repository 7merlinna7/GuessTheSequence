using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Ecs.Gameplay.Features.StagesFeature
{
    public interface IStage :IDisposable
    {
        IReadonlyEvent Completed {  get; }

        void Start();
        void Update(float deltaTime);
        void CleanUp();
    }
}