using Assets._Project.Develop.Runtime.Configs.Entities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.AI;
using System;
using UnityEngine;

namespace Assets._Project.Ecs.Gameplay.Features.Enemies
{
    public class EnemiesFactory 
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly EntitiesLifeContext _lifeContext;

        public EnemiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _lifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public Entity Create(Vector3 position,EntityConfig config)
        {
            Entity entity;

            switch (config)
            {
                case GhostConfig ghostConfig:
                    entity = _entitiesFactory.CreateWalkingGhost(position,ghostConfig);
                    _brainsFactory.CreateWalkingGhostBrain(entity);
                    break;

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config");
            }

            _lifeContext.Add(entity);
            return entity;
        }
    }
}