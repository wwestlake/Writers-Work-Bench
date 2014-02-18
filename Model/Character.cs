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
    public class Character : ModelBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string BodyStyle { get; set; }
        public Gender Gender { get; set; }
        public string Background { get; set; }
        public IList<string> Goals { get; set; }
        public string FacialFeatures { get; set; }
        public string General { get; set; }
        public Character Mother { get; set; }
        public Character Father { get; set; }
        public IList<Character> Children { get; set; }
        public IList<Character> Friends { get; set; }
        public IList<Character> Enemies { get; set; }
        public IList<Character> Associates { get; set; }
        public Character Spouse { get; set; }
        public IList<Character> ExSpouses { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2} Age {3}", Name, LastName, FirstName, Age);
        }
    }


    public class CharacterBuilder<T, P> : BuilderBase<T, P>
        where T : CharacterBuilder<T, P>
        where P : Character, new() 
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

        public T FirstName(string firstname) 
        {
            obj.FirstName = firstname;
            return (T)this;
        }
        public T MiddleName(string middlename) 
        {
            obj.MiddleName = middlename;
            return (T)this;
        }
        public T LastName(string lastname) 
        {
            obj.LastName = lastname;
            return (T)this;
        }
        public T Age(int age) 
        {
            obj.Age = age;
            return (T)this;
        }
        public T Nationality(string nationality) 
        {
            obj.Nationality = nationality;
            return (T)this;
        }
        public T BodyStyle(string bodystyle) 
        {
            obj.BodyStyle = bodystyle;
            return (T)this;
        }
        public T Gender(Gender gender) 
        {
            obj.Gender = gender;
            return (T)this;
        }
        public T Background(string background) 
        {
            obj.Background = background;
            return (T)this;
        }
        public T Goals(IList<string> goals) 
        {
            obj.Goals = goals;
            return (T)this;
        }
        public T FacialFeatures(string facialfeatures) 
        {
            obj.FacialFeatures = facialfeatures;
            return (T)this;
        }
        public T Mother(Character mother) 
        {
            obj.Mother = mother;
            return (T)this;
        }
        public T Father(Character father) 
        {
            obj.Father = father;
            return (T)this;
        }
        public T Children(IList<Character> children) 
        {
            obj.Children = children;
            return (T)this;
        }
        public T Friends(IList<Character> friends) 
        {
            obj.Friends = friends;
            return (T)this;
        }
        public T Enemies(IList<Character> enemies) 
        {
            obj.Enemies = enemies;
            return (T)this;
        }
        public T Associates(IList<Character> associates) 
        {
            obj.Associates = associates;
            return (T)this;
        }
        public T Spouse(Character spouse) 
        {
            obj.Spouse = spouse;
            return (T)this;
        }
        public T ExSpouses(IList<Character> exspouses) 
        {
            obj.ExSpouses = exspouses;
            return (T)this;
        }


    }

    public class CharacterBuilder : CharacterBuilder<CharacterBuilder, Character> { }


    public static class CharacterExtensions
    {
        public static Character Name(this Character character, string name)
        {
            character.Name = name;
            return character;
        }

        public static Character Description(this Character character, string description)
        {
            character.Description = description;
            return character;
        }

        public static Character Text(this Character character, string text)
        {
            character.Text = text;
            return character;
        }

        public static Character FirstName(this Character character, string firstName)
        {
            character.FirstName = firstName;
            return character;
        }

        public static Character MiddleName(this Character character, string middleName)
        {
            character.MiddleName = middleName;
            return character;
        }

        public static Character LastName(this Character character, string lastName)
        {
            character.LastName = lastName;
            return character;
        }

        public static Character Age(this Character character, int age)
        {
            character.Age = age;
            return character;
        }
        public static Character Nationality(this Character character, string nationality)
        {
            character.Nationality = nationality;
            return character;
        }
        public static Character BodyStyle(this Character character, string bodystyle)
        {
            character.BodyStyle = bodystyle;
            return character;
        }
        public static Character Gender(this Character character, Gender gender)
        {
            character.Gender = gender;
            return character;
        }
        public static Character Background(this Character character, string background)
        {
            character.Background = background;
            return character;
        }
        public static Character Goals(this Character character, IList<string> goals)
        {
            character.Goals = goals;
            return character;
        }
        public static Character FacialFeatures(this Character character, string facialfeatures)
        {
            character.FacialFeatures = facialfeatures;
            return character;
        }
        public static Character Mother(this Character character, Character mother)
        {
            character.Mother = mother;
            return character;
        }
        public static Character Father(this Character character, Character father)
        {
            character.Father = father;
            return character;
        }
        public static Character Children(this Character character, IList<Character> children)
        {
            character.Children = children;
            return character;
        }
        public static Character Friends(this Character character, IList<Character> friends)
        {
            character.Friends = friends;
            return character;
        }
        public static Character Enemies(this Character character, IList<Character> enemies)
        {
            character.Enemies = enemies;
            return character;
        }
        public static Character Associates(this Character character, IList<Character> associates)
        {
            character.Associates = associates;
            return character;
        }
        public static Character Spouse(this Character character, Character spouse)
        {
            character.Spouse = spouse;
            return character;
        }
        public static Character ExSpouses(this Character character, IList<Character> exspouses)
        {
            character.ExSpouses = exspouses;
            return character;
        }


    }
}
