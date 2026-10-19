namespace Assets._Project.Ecs.Gameplay.EntitiesCore.Systems
{
    public interface IInitializableSystem : IEntitySystem
    {
        void OnInit(Entity entity);
    }
}