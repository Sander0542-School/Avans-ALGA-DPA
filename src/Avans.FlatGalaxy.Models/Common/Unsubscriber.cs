using System;
using System.Collections.Generic;

namespace Avans.FlatGalaxy.Models.Common
{
    internal class Unsubscriber<T> : IDisposable
    {
        private readonly IList<IObserver<T>> _observers;
        private readonly IObserver<T> _observer;

        internal Unsubscriber(IList<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            _observers.Remove(_observer);
        }
    }
}
