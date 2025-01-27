﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics.Logic.InterfaceServicesFolder.SharedInterfaces
{
    public interface IRepoWriter<T>
    {
        void Add(T item);
        void Edit(T item);
    }
}
