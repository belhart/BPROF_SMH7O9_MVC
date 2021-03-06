﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Stats.Repository
{
    public interface IRepository<TReturnType, TKeyType>
    where TReturnType : class
    {
        TReturnType GetOne(TKeyType key);

        IQueryable<TReturnType> GetAll();
    }

    public interface IRepository<TReturnType, TKeyType1, TKeyType2>
        where TReturnType : class
    {
        TReturnType GetOne(TKeyType1 key1, TKeyType2 key2);

        IQueryable<TReturnType> GetAll();
    }
}
