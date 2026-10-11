using System;

namespace Assets._Project.Develop.Runtime.Infrastructure.DI
{
    public class Registration : IRegistrationOptions
    {
        private Func<DIContainer, object> _creator;
        private object _cashedInstance;

        public bool IsNonLazy { get; private set; }

        public Registration(Func<DIContainer, object> creator) => _creator = creator;

        public object CreateInstanceFrom(DIContainer container)
        {
            if (_cashedInstance!= null)
                return _cashedInstance;

            if (_creator == null)
                throw new InvalidOperationException("Not have instance or creator");

            _cashedInstance = _creator.Invoke(container);

            return _cashedInstance;
        }

        public void OnInitialize()
        {
            if (_cashedInstance!= null)
                if(_cashedInstance is IInitializable initializable)
                    initializable.Initialize();
        }

        public void OnDispose()
        {
            if (_cashedInstance != null)
                if (_cashedInstance is IDisposable disposable)
                    disposable.Dispose();
        }

        public void NonLazy() => IsNonLazy = true;
    }
}