﻿using System;
using System.Collections.Generic;
using System.Linq;
using Easy.Extend;
using Easy.Models;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Easy.Reflection;
namespace Easy.IOC
{
    public sealed class UnityRegister : AssemblyInfo
    {
        private readonly Type _dependencyType = typeof(IDependency);
        private readonly Type _entityType = typeof(IEntity);
        private readonly IUnityContainer _container;
        public UnityRegister(IUnityContainer container)
        {
            _container = container;
            PublicTypes.Each(p =>
            {
                if (p.IsClass && !p.IsAbstract && !p.IsInterface && !p.IsGenericType)
                {
                    if (_dependencyType.IsAssignableFrom(p) ||
                        _entityType.IsAssignableFrom(p))
                    {
                        if (_entityType.IsAssignableFrom(p))
                        {
                            _container.RegisterType(p);
                        }
                        else
                        {
                            foreach (var inter in p.GetInterfaces())
                            {
                                _container.RegisterType(inter, p);
                                _container.RegisterType(inter, p, inter.Name + p.FullName);
                            }
                        }
                    }

                }
            });
        }

        public void Regist()
        {
            var locator = new Unity.UnityServiceLocator(_container);
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}