/*
    $projectname$ Copyright (C) 2014  William W. Westlake Jr.
    wwestlake@lagdaemon.com
     
    source code: https://github.com/wwestlake/Writers-Work-Bench.git
 
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

using LagDaemon.WWB.AbstractPatterns;
using System;
using System.Collections.Generic;

namespace LagDaemon.WWB.AbstractPatternsTests
{
    public class ParameterlessTestClass
    {
        public ParameterlessTestClass() { }
        public bool TestProp { get { return true; } }
    }

    public class TestClassWithParameters
    {
        public TestClassWithParameters(int i, int j)
        {
            A = i;
            B = j;
        }

        public int A { get; set; }
        public int B { get; set; }
    }


    public class SpecTest
    {
        public int TestProp { get; set; }
    }

    public class LessThanTenSpecification : ISpecification<SpecTest>
    {

        public bool IsSatisfiedBy(SpecTest entity)
        {
            return entity.TestProp < 10;
        }
    }

    public class GreaterThanTenSpecification : ISpecification<SpecTest>
    {

        public bool IsSatisfiedBy(SpecTest entity)
        {
            return entity.TestProp > 10;
        }
    }

    
    
    public class GreaterThanFiveSpecificat :  ISpecification<SpecTest>
    {

        public bool IsSatisfiedBy(SpecTest entity)
        {
            return entity.TestProp > 5;
        }
    }


    public class LessThanFiveSpecificat : ISpecification<SpecTest>
    {

        public bool IsSatisfiedBy(SpecTest entity)
        {
            return entity.TestProp < 5;
        }
    }

    public class AddStrategy : IStrategy<int>
    {

        public int Execute(params object[] args)
        {
            int sum = 0;
            foreach (object obj in args)
            {
                try
                {
                    sum += (int)obj;
                }
                catch (InvalidCastException ex)
                {
                    throw new ApplicationException("Bad arguments to Add Strategy, must all be integers or castable to integer.", ex);
                }
            }
            return sum;
        }
    }

    public class IntegerContext : Context<int>
    {
        public IntegerContext(IStrategy<int> strategy) : base(strategy) { }
    }


    public class CoR_DataClass
    {
        public CoR_DataClass() { Flag = false; }
        public int SomeValue { get; set; }
        public bool Flag { get; set; }
    }


    public class CoR_Specification_GreaterThanThree : ISpecification<CoR_DataClass>
    {

        public bool IsSatisfiedBy(CoR_DataClass entity)
        {
            return entity.SomeValue > 3;
        }
    }

    public class CoR_Specification_GreaterThanFive : ISpecification<CoR_DataClass>
    {

        public bool IsSatisfiedBy(CoR_DataClass entity)
        {
            return entity.SomeValue > 5;
        }
    }

    public class CoR_Specification_LessThanTwo : ISpecification<CoR_DataClass>
    {

        public bool IsSatisfiedBy(CoR_DataClass entity)
        {
            return entity.SomeValue < 2;
        }
    }

    public class CorTestClass_Level_1 : ChainOfResponsibility<CoR_DataClass>
    {

        public CorTestClass_Level_1() : base(new CoR_Specification_LessThanTwo(), new CorTestClass_Level_2()) { }


        protected override void PerformAction(CoR_DataClass dataItem)
        {
            dataItem.Flag = true;
        }
    }

    public class CorTestClass_Level_2 : ChainOfResponsibility<CoR_DataClass>
    {

        public CorTestClass_Level_2() : base(new CoR_Specification_GreaterThanThree(), new CorTestClass_Level_3()) { }


        protected override void PerformAction(CoR_DataClass dataItem)
        {
            dataItem.Flag = true;
        }
    }

    public class CorTestClass_Level_3 : ChainOfResponsibility<CoR_DataClass>
    {
        public CorTestClass_Level_3() : base(new CoR_Specification_GreaterThanFive(), null) { }


        protected override void PerformAction(CoR_DataClass dataItem)
        {
            dataItem.Flag = true;
        }
    }


    public interface ProducerInterface_A
    {
        int MyProperty { get; set; }
    }

    public interface ProducerInterface_B
    {
        int MyProperty { get; set; }
    }

    public interface ProducerInterface_C
    {
        int MyProperty { get; set; }
        ConcreteClass ConcreteClass { get; set; }

    }

    public class ProducerClass_A : ProducerInterface_A
    {
        public int MyProperty { get; set; }
    }

    public class ProducerClass_B : ProducerInterface_B
    {
        public int MyProperty { get; set; }
    }

    public class ConcreteClass
    {
        public ConcreteClass(int a) 
        {
            Value = a;
        }

        public int Value { get; set; }
    }

    public class ProducerClass_C : ProducerInterface_C
    {
        public ProducerClass_C(ProducerInterface_A a, ProducerInterface_B b, ConcreteClass c) 
        {
            ConcreteClass = c;
        }

        public int MyProperty { get; set; }

        public ConcreteClass ConcreteClass { get; set; }
    }


}
