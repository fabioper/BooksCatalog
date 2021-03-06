using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BooksCatalog.Shared;
using BooksCatalog.Shared.Specifications;

namespace BooksCatalog.Api.Services.Specifications
{
    public class MultipleIdsSpec<T> : Specification<T> where T : Entity
    {
        private readonly List<int> _entityIds;

        public MultipleIdsSpec(List<int> entityIds) => _entityIds = entityIds;

        public override Expression<Func<T, bool>> ToExpression()
        {
            return entity => _entityIds.Contains(entity.Id);
        }
    }
}