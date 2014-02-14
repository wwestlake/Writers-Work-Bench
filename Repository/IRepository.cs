/*
 *   Writers Work Bench Copyright (C) 2014  William W. Westlake Jr.
 *   wwestlake@lagdaemon.com
 *   
 *   source code: https://github.com/wwestlake/Writers-Work-Bench.git
 * 
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *    (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 * 
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
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
