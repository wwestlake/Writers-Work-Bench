using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LagDaemon.WWB.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Stores or updates an object
        /// </summary>
        /// <typeparam name="T">The type of the object to store</typeparam>
        /// <param name="obj">The object to store</param>
        void Store<T>(T obj);

        /// <summary>
        /// Stores or updates an enumeratrion of objects
        /// </summary>
        /// <typeparam name="T">The type of object to store</typeparam>
        /// <param name="objs">The object to store</param>
        void Store<T>(IEnumerable<T> objs);

        /// <summary>
        /// Locates objects based on the predicate
        /// </summary>
        /// <typeparam name="T">The type of object to retreive</typeparam>
        /// <param name="predicate">The condition for returning an object</param>
        /// <returns>The enumertion of objects matching the predicate</returns>
        IEnumerable<T> Query<T>(Predicate<T> predicate);

        /// <summary>
        /// Deletes an object from the repository
        /// </summary>
        /// <typeparam name="T">The type of object to delete</typeparam>
        /// <param name="obj">The objec to delete</param>
        void Delete<T>(T obj);

        /// <summary>
        /// Deletes en enumeration of objects from the repository
        /// </summary>
        /// <typeparam name="T">The type of object to delete</typeparam>
        /// <param name="objs">The objects to delete</param>
        void Delete<T>(IEnumerable<T> objs);

        /// <summary>
        /// Activates an object to the specified depth
        /// </summary>
        /// <typeparam name="T">The type of object to activate</typeparam>
        /// <param name="?">THe depth to activate to</param>
        void Activate<T>(T obj, int depth);

    }
}
