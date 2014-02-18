using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.WWB.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelBase()
        {
            Initialize();
        }

        protected abstract void Initialize();

        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = PropertyChanged;
            if (null != eventHandler) eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;
            storage = value;
            if (null != propertyName) OnPropertyChanged(propertyName);
            return true;
        }

        protected void InvokePropertyChanged(string propertyName, object sender)
        {
            if (null == sender) sender = this;
            if (null != PropertyChanged) PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));

            var method = GetType().GetMethod(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (null != method) method.Invoke(this, null);
        }


    }
}
