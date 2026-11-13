using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities
{
    public class Layers 
    {
        public static readonly int Characters = LayerMask.NameToLayer("Characters");
        public static readonly LayerMask CharactersMask = 1 << Characters;

        public static readonly int Towers = LayerMask.NameToLayer("Towers");
        public static readonly LayerMask TowersMask = 1 << Towers;
    }
}