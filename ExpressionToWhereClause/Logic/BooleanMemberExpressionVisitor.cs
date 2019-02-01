﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionToWhereClause
{
    internal class BooleanMemberExpressionVisitor : MemberExpressionVisitor
    {
        protected virtual bool GetConstant()
        {
            return true;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            base.VisitMember(node);
            string fieldName = GetResult();
            sb.Clear();

            string parameterName = ExpressionEntry.EnsureKey(fieldName);
            sb.Append($"{fieldName} = @{parameterName}");
            ExpressionEntry.Parameters.Add($"@{parameterName}", GetConstant());
            return node;
        }
    }
}
