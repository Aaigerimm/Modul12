using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul12
{
    public delegate void PropertyEventHandler(object sender, PropertyEventArgs e);

    public class PropertyEventArgs : EventArgs
    {
        public string PropertyName { get; }

        public PropertyEventArgs(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
    public interface IPropertyChanged
    {
        event PropertyEventHandler PropertyChanged;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myObject = new MyClass();
            myObject.PropertyChanged += MyObject_PropertyChanged;

            Console.WriteLine("Setting MyProperty to 42");
            myObject.MyProperty = 42;

            Console.WriteLine("\nSetting MyProperty to 42 again (no change event should be fired)");
            myObject.MyProperty = 42;

            Console.ReadLine();
        }
        private static void MyObject_PropertyChanged(object sender, PropertyEventArgs e)
        {
            Console.WriteLine($"Property '{e.PropertyName}' changed in the object {sender}");
        }
    }
}
