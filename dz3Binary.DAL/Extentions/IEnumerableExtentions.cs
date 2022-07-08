namespace dz3Binary.DAL.Extentions
{
    public static class IEnumerableExtentions
    {
        public static ICollection<T> ToLinkedList<T>(this IEnumerable<T> ts) =>
            new LinkedList<T>(ts);
    }
}
