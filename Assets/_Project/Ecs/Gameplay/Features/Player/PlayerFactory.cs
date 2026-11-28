using Assets._Project.Ecs.Gameplay.EntitiesCore;

namespace Assets._Project.Ecs.Gameplay.Features.Player
{
    public class PlayerFactory
    {
        public Entity Player { get; private set; }

        public Entity CreateBasePlayer()
        { 
            Entity entity = new Entity();

           
                

            Player = entity;

            return  entity;
        }


    }
}