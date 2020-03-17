using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignCalendar.Extensions
{
    public static class ListExtensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        static public IEnumerable<T> SelfAndTraverse<T>(this T source, Func<T, T> TraverseBy)
        {
            if (source == null)
                yield break;

            yield return source;

            var children = TraverseBy(source);
            if (children == null)
                yield break;

            foreach (var child in children.SelfAndTraverse(TraverseBy))
            {
                yield return child;
            }
        }

        static public IEnumerable<T> Traverse<T>(this T source, Func<T, T> TraverseBy)
        {
            if (source == null)
                yield break;

            var children = TraverseBy(source);
            if (children == null)
                yield break;

            foreach (var child in children.SelfAndTraverse(TraverseBy))
            {
                yield return child;
            }
        }
    }
}
