using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WinFactor.Services
{
    public static class Refs
    {
        static readonly List<WeakReference> _refs = new List<WeakReference>();

        public static readonly BindableProperty IsWatchedProperty = BindableProperty.CreateAttached("IsWatched", typeof(bool), typeof(Refs), false, propertyChanged: OnIsWatchedChanged);

        public static bool GetIsWatched(BindableObject obj)
        {
            return (bool)obj.GetValue(IsWatchedProperty);
        }

        public static void SetIsWatched(BindableObject obj, bool value)
        {
            obj.SetValue(IsWatchedProperty, value);
        }

        static void OnIsWatchedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            AddRef(bindable);
        }

        public async static void AddRef(object p)
        {
            GC.Collect();
            await Task.Delay(100);
            GC.Collect();

            _refs.Add(new WeakReference(p));
            foreach (var @ref in _refs)
            {
                if (@ref.IsAlive)
                {
                    var obj = @ref.Target;
                    Debug.WriteLine("IsAlive: " + obj.GetType().Name);
                }
                else
                {
                    Debug.WriteLine("IsAlive: False");
                }
            }
            Debug.WriteLine("---------------");
        }
    }
}