﻿using System;
using System.Linq.Expressions;

namespace BooksCatalog.Shared.Specifications
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}