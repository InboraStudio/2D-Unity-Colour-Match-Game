namespace Ilumisoft.Connect.Core.Extensions
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Extension classes for the List<T> class
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns a random item from the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T GetRandom<T>(this List<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}