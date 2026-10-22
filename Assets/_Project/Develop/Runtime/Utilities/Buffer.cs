namespace Assets._Project.Develop.Runtime.Utilities
{
    public class Buffer<T>
    {
        public T[] Items;
        public int Count;

        public Buffer( int initialsize)
        {
            Items = new T[initialsize];
            Count = 0;
        }
    }
}