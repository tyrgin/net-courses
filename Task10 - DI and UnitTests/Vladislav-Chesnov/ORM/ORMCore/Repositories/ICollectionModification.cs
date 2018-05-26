﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMCore.Repositories
{
    public interface ICollectionModification<T> where T: class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}
