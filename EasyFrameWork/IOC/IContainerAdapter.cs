﻿using System;

namespace Easy.IOC
{
    public interface IContainerAdapter
    {
        IContainerAdapter RegisterType(Type itype, Type type);
        IContainerAdapter RegisterType(Type itype, Type type, DependencyLifeTime lifeTime);
        IContainerAdapter RegisterType<TIt, T>() where T : TIt;
        IContainerAdapter RegisterType<TIt, T>(DependencyLifeTime lifeTime) where T : TIt;
    }
}