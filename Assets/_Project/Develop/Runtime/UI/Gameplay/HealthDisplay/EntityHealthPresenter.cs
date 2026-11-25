using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Ecs.Gameplay.EntitiesCore;
using Assets._Project.Ecs.Gameplay.Features.TeamsFeature;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.HealthDisplay
{
    public class EntityHealthPresenter : IPresenter
    {
        private BarWithText _bar;
        private Entity _entity;
        private ReactiveVariable<Teams> _team;
        private ReactiveVariable<float> _health;
        private ReactiveVariable<float> _maxHealth;

        private List<IDisposable> _disposables = new();

        public EntityHealthPresenter(BarWithText bar, Entity entity)
        {
            _bar = bar;
            _entity = entity;
        }

        public BarWithText Bar => _bar;

        public void Initialize()
        {
            _health = _entity.CurrentHealth;
            _maxHealth = _entity.MaxHealth;
            _team = _entity.Team;

            _disposables.Add(_health.Subscribe(OnHealthChanged));
            _disposables.Add(_maxHealth.Subscribe(OnMaxHealthChanged));
            _disposables.Add(_team.Subscribe(OnTeamChanged));

            UpdateHealth();
            UpdateFilterColorBy(_team.Value);
        }
        public void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void UpdateFilterColorBy(Teams team)
        {
            if(team == Teams.Player)
                _bar.SetFilterColor(Color.green);
            if(team == Teams.Enemies)
                _bar.SetFilterColor(Color.red);
        }

        private void UpdateHealth()
        {
            _bar.UpdateText(_health.Value.ToString("0"));
            _bar.UpdateSlider(_health.Value/_maxHealth.Value);
        }

        private void OnTeamChanged(Teams teams1, Teams newTeam) => UpdateFilterColorBy(newTeam);

        private void OnMaxHealthChanged(float arg1, float arg2) => UpdateHealth();

        private void OnHealthChanged(float arg1, float arg2) => UpdateHealth();
    }
}