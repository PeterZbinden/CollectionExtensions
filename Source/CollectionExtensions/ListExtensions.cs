using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollectionExtensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Moves the specified item one position up in the List
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool IncreaseIndexByOne<TItem>(this IList<TItem> list, TItem item)
        {
            if (list.Count <= 0)
            {
                return false;
            }

            var index = list.IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            if (list.Count == 1)
            {
                return true;
            }

            return MoveIndex(list, index, index + 1);
        }

        /// <summary>
        /// Moves the specified item one position up in the List
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool ReduceIndexByOne<TItem>(this IList<TItem> list, TItem item)
        {
            if (list.Count <= 0)
            {
                return false;
            }

            var index = list.IndexOf(item);
            if (index < 0)
            {
                return false;
            }

            if (list.Count == 1)
            {
                return true;
            }

            return MoveIndex(list, index, index - 1);
        }

        /// <summary>
        /// Moves the specified item to the beginning of the list (index 0)
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool MoveToStart<TItem>(this IList<TItem> list, TItem item)
        {
            if (list.Count <= 0)
            {
                return false;
            }

            var sourceIndex = list.IndexOf(item);
            if (sourceIndex < 0)
            {
                return false;
            }

            if (list.Count == 1)
            {
                return true;
            }

            var destinationIndex = 0;

            if (destinationIndex >= sourceIndex)
            {
                return false;
            }

            return MoveIndex(list, sourceIndex, destinationIndex);
        }

        /// <summary>
        /// Moves the specified item to the end of the list (index n -1)
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool MoveToEnd<TItem>(this IList<TItem> list, TItem item)
        {
            if (list.Count <= 0)
            {
                return false;
            }

            var sourceIndex = list.IndexOf(item);
            if (sourceIndex < 0)
            {
                return false;
            }

            if (list.Count == 1)
            {
                return true;
            }

            var destinationIndex = list.Count - 1;

            if (destinationIndex <= sourceIndex)
            {
                return false;
            }

            return MoveIndex(list, sourceIndex, destinationIndex);
        }

        /// <summary>
        /// Moves a defined item within the list to another position while ensuring all other items are repositioned
        /// Does NOT throw Exceptions if index-bounds are violated, instead will return 'false'
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list">The data the operation should be performed on</param>
        /// <param name="item">Which item should be moved</param>
        /// <param name="targetIndex">Where should it be moved</param>
        /// <returns>true if all worked, false if an invalid operation was performed</returns>
        public static bool MoveItem<TItem>(this IList<TItem> list, TItem item, int targetIndex)
        {
            var sourceIndex = list.IndexOf(item);
            if (sourceIndex < 0)
            {
                return false;
            }

            return MoveIndex(list, sourceIndex, targetIndex);
        }

        /// <summary>
        /// Moves a defined item within the list to another position while ensuring all other items are repositioned
        /// Does NOT throw Exceptions if index-bounds are violated, instead will return 'false'
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list">The data the operation should be performed on</param>
        /// <param name="sourceIndex">Defines the index of the item that should be moved</param>
        /// <param name="targetIndex">Where should it be moved</param>
        /// <returns>true if all worked, false if an invalid operation was performed</returns>
        public static bool MoveIndex<TItem>(this IList<TItem> list, int sourceIndex, int targetIndex)
        {
            if (sourceIndex < 0
                || targetIndex < 0)
            {
                return false;
            }

            if (sourceIndex >= list.Count
                || targetIndex >= list.Count)
            {
                return false;
            }

            if (sourceIndex == targetIndex)
            {
                return true;
            }

            MoveUnsafe(list, sourceIndex, targetIndex);
            return true;
        }

        /// <summary>
        /// Moves a defined item within the list to another position while ensuring all other items are repositioned
        /// No bounds-checks are performed, will throw Exceptions if index-bounds are violated
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list">The data the operation should be performed on</param>
        /// <param name="sourceIndex">Which item should be moved</param>
        /// <param name="targetIndex">Where should it be moved</param>
        /// <returns>true if all worked, false if an invalid operation was performed</returns>
        private static void MoveUnsafe<TItem>(this IList<TItem> list, int sourceIndex, int targetIndex)
        {
            var temp = list[sourceIndex];
            if (sourceIndex < targetIndex)
            {
                for (int i = sourceIndex; i < targetIndex; i++)
                {
                    var source = i + 1;
                    var destination = i;
                    list[destination] = list[source];
                }
            }
            else
            {
                for (int i = sourceIndex; i > targetIndex; i--)
                {
                    var source = i - 1;
                    var destination = i;
                    list[destination] = list[source];
                }
            }

            list[targetIndex] = temp;
        }

        public static async Task ForEachAsync<TItem>(this IEnumerable<TItem> list, Func<TItem, Task> action)
        {
            foreach (var item in list)
            {
                await action(item);
            }
        }

        public static void ForEach<TItem>(this IEnumerable<TItem> list, Action<TItem> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static async Task ForEachAsync<TItem>(this IList<TItem> list, Func<TItem, Task> action)
        {
            foreach (var item in list)
            {
                await action(item);
            }
        }

        public static void ForEach<TItem>(this IList<TItem> list, Action<TItem> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }
}
