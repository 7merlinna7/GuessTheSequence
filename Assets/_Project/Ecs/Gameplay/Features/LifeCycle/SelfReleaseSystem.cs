using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.EntitiesCore.Systems;

namespace Assets._Project.Ecs.Gameplay.Features.LifeCycle
{
    public class SelfReleaseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLifeContext _lifeContext;

        private Entity _entity;
        private ReactiveVariable<bool> _isDead;
        private ReactiveVariable<bool> _inDeathProcess;

        public SelfReleaseSystem(EntitiesLifeContext lifeContext)
        {
            _lifeContext = lifeContext;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _isDead = entity.IsDead;
            _inDeathProcess = entity.InDeathProcess;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value && _inDeathProcess.Value == false)
                _lifeContext.Release(_entity);
        }
    }
}