using System;
using System.Collections.Generic;

namespace KetoApp
{
    public interface IServiceLocator
    {
        T Get<T>();
        IEnumerable<T> GetAll<T>();
        object Get(Type type);
    }
}
