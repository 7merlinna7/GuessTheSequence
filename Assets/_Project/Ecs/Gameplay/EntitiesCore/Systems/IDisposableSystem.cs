namespace Assets._Project.Ecs.Gameplay.EntitiesCore.Systems
{
    public interface IDisposableSystem : IEntitySystem
    {
        void OnDispose();
    }
}