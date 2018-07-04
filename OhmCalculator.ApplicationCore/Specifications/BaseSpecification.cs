using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OhmCalculator.ApplicationCore.specifications
{
    public abstract class BaseSpecification<T>

    {
        public abstract Func<T, bool> ToExpression();
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> predicate = ToExpression();
            return predicate(entity);

        }

    }
}
