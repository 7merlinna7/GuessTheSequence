using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States.TargetSelectors
{
    public interface ITargetSelector 
    {
        Entity SelectTargetFrom( IEnumerable<Entity> targets);
    }
}