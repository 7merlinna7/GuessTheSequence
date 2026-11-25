using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.TowerFeature;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.HealthDisplay
{
    public class EntitiesHealthDisplayPresenter : IPresenter
    {
        private readonly EntitiesLifeContext _lifeContext;
        private readonly EntitiesHealthDisplay _view;

        private readonly GameplayPresentersFactory _presentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private Dictionary<Entity, EntityHealthBarInfo> _entityToHealthbarInfo = new();

        public EntitiesHealthDisplayPresenter(
            EntitiesLifeContext lifeContext,
            EntitiesHealthDisplay view,
            GameplayPresentersFactory presentersFactory,
            ViewsFactory viewsFactory)
        {
            _lifeContext = lifeContext;
            _view = view;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
        }

        public void Initialize()
        {
            _lifeContext.Added += OnEntityAdded;
            _lifeContext.Released += OnEntityRealesed;

            foreach (Entity entity in _lifeContext.Entities)
                OnEntityAdded(entity);
        }

        public void Dispose()
        {
            _lifeContext.Added -= OnEntityAdded;
            _lifeContext.Released -= OnEntityRealesed;

            foreach (EntityHealthBarInfo info in _entityToHealthbarInfo.Values)
                DisposeFor(info);

            _entityToHealthbarInfo.Clear();
        }

        public void LateUpdate()
        {
            foreach (KeyValuePair<Entity,EntityHealthBarInfo> info in _entityToHealthbarInfo)
                _view.UpdatePositionFor(info.Value.HealthPresenter.Bar,info.Value.HealthBarPoint.position);
        }

        private void OnEntityRealesed(Entity entity)
        {
            if(_entityToHealthbarInfo.ContainsKey(entity))
                RemoveHealthBarFor(entity);
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.TryGetHealthBarPoint(out Transform healthBarPoint))
            {
                BarWithText healthBarView = null;

                if (entity.HasComponent<IsTower>())
                    healthBarView = _viewsFactory.Create<BarWithText>(ViewIDs.TowerHealthBar);
                else
                    healthBarView = _viewsFactory.Create<BarWithText>(ViewIDs.SimpleHealthBar);

                _view.Add(healthBarView);

                EntityHealthPresenter entityHealthPresenter = _presentersFactory.CreateEntityHealthPresenter(entity, healthBarView);
                entityHealthPresenter.Initialize();

                IDisposable removeReason = entity.IsDead.Subscribe((oldValue, isDead) =>
                {
                    if (isDead)
                        RemoveHealthBarFor(entity);
                });

                _entityToHealthbarInfo.Add(entity, new EntityHealthBarInfo(healthBarPoint,removeReason,entityHealthPresenter));
            }
        }

        private void RemoveHealthBarFor(Entity entity)
        {
            EntityHealthBarInfo info = _entityToHealthbarInfo[entity];
            DisposeFor(info);
            _entityToHealthbarInfo.Remove(entity);
        }

        private void DisposeFor(EntityHealthBarInfo info)
        {
            info.RemoveReason.Dispose();

            _view.Remove(info.HealthPresenter.Bar);
            _viewsFactory.Release(info.HealthPresenter.Bar);

            info.HealthPresenter.Dispose();
        }

        private class EntityHealthBarInfo
        {
            public EntityHealthBarInfo(
                Transform healthBarPoint,
                IDisposable removeReason,
                EntityHealthPresenter healthPresenter)
            {
                HealthBarPoint = healthBarPoint;
                RemoveReason = removeReason;
                HealthPresenter = healthPresenter;
            }

            public Transform HealthBarPoint {  get; }
            public IDisposable RemoveReason { get; }
            public EntityHealthPresenter HealthPresenter { get; }
        }
    }
}