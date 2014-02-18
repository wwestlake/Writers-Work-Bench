using LagDaemon.WWB.AbstractPatterns;
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
using System.Threading.Tasks;

namespace LagDaemon.WWB.Model
{
    [Serializable]
    public class Project : ModelBase
    {
        public Project()
        {
            CreationDate = DateTime.Now;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Copyright { get; set; }
        public string Synopsis { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class ProjectBuilder<T, P> : BuilderBase<T, P> 
        where T: ProjectBuilder<T, P>
        where P: Project, new()
    {
        public T Name(string name)
        {
            obj.Name = name;
            return (T)this;
        }

        public T Description(string description)
        {
            obj.Description = description;
            return (T)this;
        }

        public T Text(string text)
        {
            obj.Text = text;
            return (T)this;
        }

        public T Title(string title)
        {
            obj.Title = title;
            return (T)this;
        }

        public T Author(string author)
        {
            obj.Author = author;
            return (T)this;
        }

        public T Copyright(string copyright)
        {
            obj.Copyright = copyright;
            return (T)this;
        }

        public T Synopsis(string synopsis)
        {
            obj.Synopsis = synopsis;
            return (T)this;
        }
    }

    public class ProjectBuilder : ProjectBuilder<ProjectBuilder, Project> { }

    public static class ProjectExtensions
    {
        public static Project Name(this Project project, string name)
        {
            project.Name = name;
            return project;
        }

        public static Project Description(this Project project, string description)
        {
            project.Description = description;
            return project;
        }

        public static Project Text(this Project project, string text)
        {
            project.Text = text;
            return project;
        }

        public static Project Title(this Project project, string title)
        {
            project.Title = title;
            return project;
        }

        public static Project Author(this Project project, string author)
        {
            project.Author = author;
            return project;
        }

        public static Project Copyright(this Project project, string copyright)
        {
            project.Copyright = copyright;
            return project;
        }

        public static Project Synopsis(this Project project, string synopsis)
        {
            project.Synopsis = synopsis;
            return project;
        }

    }

}
