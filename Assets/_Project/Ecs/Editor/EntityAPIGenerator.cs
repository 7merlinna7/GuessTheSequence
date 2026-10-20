using Assets._Project.Ecs.Gameplay.EntitiesCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets._Project.Ecs.Editor
{
    public class EntityAPIGenerator 
    {
        private const string AssemblyName = "Assembly-CSharp";
        private static string OutputPath
            => Path.Combine(Application.dataPath, "_Project/Ecs/Gameplay/EntitiesCore/Generated/EntityAPI.cs");

        [MenuItem("Tools/GenerateEntityAPI")]
        private static void Generate()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"namespace {typeof(Entity).Namespace}");
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic partial class {typeof(Entity).Name}");
            sb.AppendLine("\t{");

            Assembly assembly = Assembly.Load(AssemblyName);

            IEnumerable<Type> componentTypes = GetComponentTypesFrom(assembly);

            foreach (Type componentType in componentTypes) //не работает не видит компоненты
            {
                string typeName = componentType.Name;
                string fullTypeName = componentType.FullName;

                string componentName = RemoveSuffixIsExist(typeName, "Component");
                string modifiedComponentName = componentName + "C";

                //свойство для получения компонента
                sb.AppendLine($"\t\tpublic {fullTypeName} {modifiedComponentName} => GetComponent<{fullTypeName}>();");
                sb.AppendLine();

            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");

            File.WriteAllText(OutputPath, sb.ToString());

            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
        }

        private static string RemoveSuffixIsExist(string str,string suffix)
        {
            if(str.EndsWith(suffix))
            {
                return str.Substring(0,str.Length - suffix.Length);
            }

            return str;
        }
        private static IEnumerable<Type> GetComponentTypesFrom(Assembly assembly)
        {
            return assembly
                .GetTypes()
                .Where(type => type.IsInterface == false
                    && !type.IsAbstract == false
                    && typeof(IEntityComponent).IsAssignableFrom(type));
        }
    }
}