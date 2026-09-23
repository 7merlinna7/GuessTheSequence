using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilites.CoroutinesManagment
{
    public interface ICoroutinesPerformer
    {
        public Coroutine StartPerform(IEnumerator coroutineFunction);
        public void StopPerform(Coroutine coroutine);
    }
}