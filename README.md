# MySQL .NET 6 DateTime issue

# Environment:
- MySQL 8.0.29
- MySQL .NET connector 6.0.1
- .NET 6
- VS 2022

# Issue
When using MySQL .NET connector 6.0.1 in .NET 6, Performing an equality check on Datetime.Date throws an ArgumentOutOfRangeException.

Exception:

    System.ArgumentOutOfRangeException
      HResult=0x80131502
      Message=Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')
      Source=System.Private.CoreLib
      StackTrace:
       at System.ThrowHelper.ThrowArgumentOutOfRange_IndexException()
       at System.Collections.Generic.List`1.get_Item(Int32 index)
       at Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor.ProcessNullNotNull(SqlUnaryExpression sqlUnaryExpression, Boolean operandNullable)
       at Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor.RewriteNullSemantics(SqlBinaryExpression sqlBinaryExpression, SqlExpression left, SqlExpression right, Boolean leftNullable, Boolean rightNullable, Boolean optimize, Boolean& nullable)
       at Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor.VisitSqlBinary(SqlBinaryExpression sqlBinaryExpression, Boolean allowOptimizedExpansion, Boolean& nullable)
       at Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor.Visit(SqlExpression sqlExpression, Boolean allowOptimizedExpansion, Boolean preserveColumnNullabilityInformation, Boolean& nullable)
       at Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor.Visit(SqlExpression sqlExpression, Boolean allowOptimizedExpansion, Boolean& nullable)
       at Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor.Visit(SelectExpression selectExpression)
       at Microsoft.EntityFrameworkCore.Query.SqlNullabilityProcessor.Process(SelectExpression selectExpression, IReadOnlyDictionary`2 parameterValues, Boolean& canCache)
       at MySql.EntityFrameworkCore.Query.Internal.MySQLParameterBasedSqlProcessor.ProcessSqlNullability(SelectExpression selectExpression, IReadOnlyDictionary`2 parametersValues, Boolean& canCache)
       at Microsoft.EntityFrameworkCore.Query.RelationalParameterBasedSqlProcessor.Optimize(SelectExpression selectExpression, IReadOnlyDictionary`2 parametersValues, Boolean& canCache)
       at Microsoft.EntityFrameworkCore.Query.Internal.RelationalCommandCache.GetRelationalCommandTemplate(IReadOnlyDictionary`2 parameters)
       at Microsoft.EntityFrameworkCore.Internal.RelationCommandCacheExtensions.RentAndPopulateRelationalCommand(RelationalCommandCache relationalCommandCache, RelationalQueryContext queryContext)
       at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.InitializeReader(Enumerator enumerator)
       at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.<>c.<MoveNext>b__19_0(DbContext _, Enumerator enumerator)
       at MySql.EntityFrameworkCore.Storage.Internal.MySQLExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
       at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.Enumerator.MoveNext()
       at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
       at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
       at Program.<Main>$(String[] args) in D:\projects\mysql-connection-date-issue\Test\Test\Program.cs:line 11

      This exception was originally thrown at this call stack:
        [External Code]
        Program.<Main>$(string[]) in Program.cs
  
  
 # Steps to reproduce the issue
 1. Clone the code
 2. Restore the DB using the backup file `demo.sql`
 3. Update connection string in demoContext.cs
 4. Run/Debug the console app
