using System;
using System.Diagnostics.CodeAnalysis;

namespace FynnBlog
{
    [SuppressMessage("ReSharper", "ArrangeAccessorOwnerBody")]
    public class MyObjectClass
    {
        public object Obj1 = new object();

        public object Obj2 => new object();

        public object Obj3 { get; } = new object();

        public object Obj4
        {
            get => new object();
        }

        public object Obj5
        {
            get { return new object(); }
        }

        public void DoSomething()
        {
            for (var i = 0; i < 11; i++)
            {
                Console.WriteLine("OBJ1: " + Obj1.GetHashCode());
                Console.WriteLine("OBJ2: " + Obj2.GetHashCode());
                Console.WriteLine("OBJ3: " + Obj3.GetHashCode());
                Console.WriteLine("OBJ4: " + Obj4.GetHashCode());
                Console.WriteLine("OBJ5: " + Obj5.GetHashCode());
            }
        }


        /*
         * All except for Obj1 are properties and Obj1 is a field
         * All properties have no setter => they are read only
         *
         * Object 2-5 are exactly the same, even Object 6 is the same, just with a backing field
         * */
    }
}