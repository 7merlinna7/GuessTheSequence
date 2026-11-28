using System.Collections;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.AbilitiesFeature.Abilities
{
    public abstract class Ability
    {
        protected Ability(string id)
        {
            ID = id;
        }

        public string ID { get;}

        public abstract void Activate();
    }
}