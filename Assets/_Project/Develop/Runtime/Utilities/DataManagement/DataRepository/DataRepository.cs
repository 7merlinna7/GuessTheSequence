using System;
using System.Collections;
using System.IO;

namespace Assets._Project.Develop.Runtime.Utilities.DataManagement.DataRepository
{
    public class DataRepository : IDataRepository
    {
        private readonly string _folderPath;
        private readonly string _saveFileExtention;

        public DataRepository(string folderPath, string saveFileExtention)
        {
            _folderPath = folderPath;
            _saveFileExtention = saveFileExtention;
        }

        IEnumerator IDataRepository.Exist(string key, Action<bool> onExistResult)
        {
           bool exists = File.Exists(FullPathFor(key));

            onExistResult?.Invoke(exists);

            yield break;
        }


        IEnumerator IDataRepository.Read(string key, Action<string> onRead)
        {
            string text = File.ReadAllText(FullPathFor(key));

            onRead?.Invoke(text);

            yield break;
        }

        IEnumerator IDataRepository.Remove(string key)
        {
            File.Delete(FullPathFor(key));

            yield break;
        }

        IEnumerator IDataRepository.Write(string key,string serializedData)
        {
            File.WriteAllText(FullPathFor(key), serializedData);

            yield break;
        }

        private string FullPathFor(string key)
        => Path.Combine(_folderPath,key)+"."+_saveFileExtention;
    }
}