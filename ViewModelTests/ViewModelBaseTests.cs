/*
    $programname$ Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
    
    source code: https://github.com/wwestlake/ExperimentalOS.git 
  
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagDaemon.WWB.ViewModels;

namespace LagDaemon.WWB.ViewModelTests
{
    [TestFixture]
    public class ViewModelBaseTests
    {
        public class TestViewModel : ViewModelBase 
        {
            private string name;

            public TestViewModel() : base() { }

            protected override void Initialize()
            {
                
            }

            public string Name
            {
                get { return name; }
                set 
                { 
                    SetProperty<string>(ref name, value, "Name"); 
                }
            }

        }

        TestViewModel vm;
        bool propertyChanged = false;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            vm = new TestViewModel();
            propertyChanged = false;
        }

        [Test]
        public void ViewModelBase_Sets_Property()
        {
            vm.Name = "Bill";
            Assert.AreEqual(vm.Name, "Bill");
        }

        [Test]
        public void ViewModelBase_Notifies_Property_Changed()
        {
            vm.PropertyChanged += vm_PropertyChanged;
            vm.Name = "Charles";
            Assert.True(propertyChanged);
        }

        void vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            propertyChanged = true;
        }


        [TearDown]
        public void TearDown()
        {
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }
    }
}
