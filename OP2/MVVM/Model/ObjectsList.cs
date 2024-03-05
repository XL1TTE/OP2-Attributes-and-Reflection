using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP2.MVVM.Model
{
    class NotComparableAttribute : Attribute
    {
    }
    class UnreadableAttribute : Attribute
    {
    }
    class Person
    {
        int Age { get; set; }
        string name;
        public Person()
        {
            name = "name";
            Age = 200;
        }
    }
    [Unreadable]
    class UnReadablePerson
    {
        int Age { get; set; }
        string name;
    }
    [NotComparable]
    class NotComparablePerson
    {
        int Age { get; set; }
        string name;
    }
    class Car
    {
        int Age { get; set; }
        
        public string mark;
        public int speed;
        public string Engine { get; set; }
        void Drive()
        {

        }
        public void Like()
        {

        }
    }
    [Unreadable]
    class UnReadableCar
    {
        int Age { get; set; }
        string mark;
        string Engine;
        void Drive()
        {

        }
        public void Like()
        {

        }
    }
    static public class ObjectsList
    {
        static public List<Object> _ToTest = new List<Object>()
        {
            new Car{Engine = "Gorila", mark = "BMW", speed = 10000},
            new UnReadablePerson(),
            new Car(),
            new Person(),
            new Car{Engine = "Godzila",  mark = "BMW", speed = 10000},
            new NotComparablePerson(),
            new Person()
        };
        static public List<Object> _ControlTest = new List<Object>()
        {
            new Car{Engine = "Godzila",  mark = "Mersedes", speed = 10000},
            new UnReadablePerson(),
            new Car(),
            new Person(),
            new Car{Engine = "Godzila",  mark = "Mersedes"},
            new NotComparablePerson(),
            new Person()
        };

    }
}
