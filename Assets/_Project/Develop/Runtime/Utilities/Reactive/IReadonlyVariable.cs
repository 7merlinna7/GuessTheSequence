using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.Reactive
{
    public interface IReadonlyVariable<T>
    {
        T Value { get; }
        IDisposable Subscribe(Action<T, T> action);
    }
}