using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace Assets._Project.Ecs.Gameplay.Features.AI.States
{
    public interface ITargetSelector 
    {
        Entity SelectTargetFrom( IEnumerable<Entity> targets);
    }
}