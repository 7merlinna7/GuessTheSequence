using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagement
{
    public interface IDataSerializer 
    {
        string Serialize<TData>(TData data);
        
        TData Deserialize<TData>(string serializedData);
    }
}