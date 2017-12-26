using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Reflect
{
    class Program
    {
        class MyTestClass
        {
            MyTestClass() { };
            double d, f;

            public MyTestClass(double d, double f)
            {
                this.d = d;
                this.f = f;
            }

            [NewAttribute("Первый параметр")]
            public double D { get; set; }
            [NewAttribute("Второй параметр")]
            public double F { get; set; }

            public double Sum() { return d + f; }
            public double Mul() { return d * f; }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        public class NewAttribute : Attribute
        {
            public NewAttribute() { }
            public NewAttribute(string argument1)
            {
                Description = argument1;
            }

            public string Description { get; set; }
        }

        static void AboutClass()
        {
            Type t = typeof(MyTestClass);

            Assembly info = Assembly.GetExecutingAssembly();
            Console.WriteLine("Текущее имя сборки: " + info.FullName);
            Console.WriteLine("Исполяняемый файл: " + info.Location);

            Console.WriteLine("Пространство имен: " + t.Namespace);
            Console.WriteLine("Тип: " + t.FullName);

            Console.WriteLine("Методы:");
            foreach (var x in t.GetMethods()) { Console.WriteLine(x); }
            Console.WriteLine("Конструкторы:");
            foreach (var x in t.GetConstructors()) { Console.WriteLine(x); }
            Console.WriteLine("Методы:");
            foreach (var x in t.GetProperties()) { Console.WriteLine(x); }
        }

        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;
            
            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }
            return Result;
        }

        static void AboutAttribute()
        {
            Type t = typeof(MyTestClass);
            Console.WriteLine("\nСвойства, помеченные атрибутом:");

            foreach (var x in t.GetProperties())
            {
                object attrObj;

                if (GetPropertyAttribute(x, typeof(NewAttribute), out attrObj))
                {
                    NewAttribute attr = attrObj as NewAttribute;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
        }

        static void Main()
        {
            AboutClass();
            AboutAttribute();

            Type t = typeof(MyTestClass);

            Console.WriteLine("\nВызов метода:");
            MyTestClass tc = (MyTestClass)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });
            object[] parameters = new object[] { };
            object Result = t.InvokeMember("AboutAttribute", BindingFlags.InvokeMethod, null, tc, parameters);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}