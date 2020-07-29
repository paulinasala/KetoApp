using System;
using System.Collections.Generic;
using System.Diagnostics;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;

namespace KetoApp
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly ContainerBuilder _builder;
        private readonly IContainer _containter;

        public ServiceLocator(Action<ContainerBuilder> builder)
        {
            _builder = new ContainerBuilder();
            builder(_builder);
            _containter = _builder.Build();
        }

        /// <exception cref="ComponentNotRegisteredException"/>
        /// <exception cref="DependencyResolutionException"/>
        public T Get<T>()
        {
            try
            {
                return _containter.Resolve<T>();
            }
            catch (ComponentNotRegisteredException e)
            {
                Debug.WriteLine("Component not registered! \n" + e.Message);
                throw;
            }
            catch (DependencyResolutionException e)
            {
                Debug.WriteLine("Dependency error! \n" + e.Message);
                throw;
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            try
            {
                return _containter.Resolve<IEnumerable<T>>();
            }
            catch (ComponentNotRegisteredException e)
            {
                Debug.WriteLine("Component not registered! \n" + e.Message);
                throw;
            }
            catch (DependencyResolutionException e)
            {
                Debug.WriteLine("Dependency error! \n" + e.Message);
                throw;
            }
        }

        /// <exception cref="ComponentNotRegisteredException"/>
        /// <exception cref="DependencyResolutionException"/>
        public object Get(Type type)
        {
            try
            {
                return _containter.Resolve(type);
            }
            catch (ComponentNotRegisteredException e)
            {              
                Debug.WriteLine("Component not registered! \n" + e.Message);
                throw;
            }
            catch (DependencyResolutionException e)
            {
                Debug.WriteLine("Dependency error! \n" + e.Message);
                throw;
            }
        }
    }
}
