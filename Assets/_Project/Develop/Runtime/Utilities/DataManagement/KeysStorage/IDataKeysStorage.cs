using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagement.KeysStorage
{
    public interface IDataKeysStorage 
    {
        string GetKeyFor<TData>() where TData : ISaveData;

    }
}