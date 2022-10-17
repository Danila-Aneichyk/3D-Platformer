using System.Collections.Generic;

namespace Platformer3D.Game
{
    public static class CollectionExtensions
    {
        public static T First<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                return default;

            return list[0]; 
        }
    }
}