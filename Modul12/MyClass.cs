using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul12
{
    public class MyClass : IPropertyChanged
    {
        private int myProperty;

        public int MyProperty
        {
            get => myProperty;
            set
            {
                if (myProperty != value)
                {
                    myProperty = value;
                    OnMyPropertyChanged();
                }
            }
        }

        public event PropertyEventHandler PropertyChanged;

        protected virtual void OnMyPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyEventArgs(nameof(MyProperty)));
        }
    }

}
