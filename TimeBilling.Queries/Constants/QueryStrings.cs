namespace TimeBilling.Queries.Constants;
public class QueryStrings
{
  public const string ReadAllCustomers = @"SELECT * FROM Customers AS c ";
  internal const string WhereCustomerId = @"WHERE c.Id = @CustomerId ";
  public const string ReadCustomerById = ReadAllCustomers + WhereCustomerId;

  public const string ReadAllPeople = @"SELECT * FROM People AS p ";
  internal const string WherePersonId = @"WHERE p.Id = @PersonId ";
  public const string ReadPersonById = ReadAllPeople + WherePersonId;

  public const string ReadAllWorkloads = @"SELECT * FROM Workloads AS w ";
  internal const string WhereWorkloadId = @"WHERE w.Id = @WorkloadId ";
  public const string ReadWorkloadById = ReadAllWorkloads + WhereWorkloadId;

  internal const string WhereWorkloadCustomerId = @"WHERE w.CustomerId = @CustomerId ";
  internal const string WhereWorkloadPersonId = @"WHERE w.PersonId = @PersonId ";
  internal const string WorkloadsJoinCustomer = @"JOIN Customers AS c ON c.Id = w.CustomerId ";
  internal const string WorkloadsJoinPeople = "JOIN People AS p ON p.Id = w.PersonId ";
  internal const string WorkloadsJoinCustomerAndPeople = WorkloadsJoinCustomer + WorkloadsJoinPeople;

  public const string ReadWorkloadsByCustomer = ReadAllWorkloads + WhereWorkloadCustomerId;
  public const string ReadWorkloadsByPerson = ReadAllWorkloads + WhereWorkloadPersonId;

  public const string ReadWorkloadsByCustomerWithPeople = ReadAllWorkloads + WorkloadsJoinPeople + WhereWorkloadCustomerId;
  public const string ReadWorkloadsByPersonWithCustomer = ReadAllWorkloads + WorkloadsJoinCustomer + WhereWorkloadPersonId;

  public const string ReadWorkloadsByCustomerWithCustomerAndPeople = ReadAllWorkloads + WorkloadsJoinCustomerAndPeople + WhereWorkloadCustomerId;
  public const string ReadWorkloadsByPersonWithCustomerAndPeople = ReadAllWorkloads + WorkloadsJoinCustomerAndPeople + WhereWorkloadPersonId;
}

/*
SET @CustomerId = 1;
SET @PersonId = 2;
SET @WorkloadId = 3;
SELECT * FROM Customers AS c;
SELECT * FROM Customers AS c WHERE c.Id = @CustomerId;
SELECT * FROM People AS p;
SELECT * FROM People AS p WHERE p.Id = @PersonId;
SELECT * FROM Workloads AS w;
SELECT * FROM Workloads AS w WHERE w.Id = @WorkloadId;
SELECT * FROM Workloads AS w WHERE w.CustomerId = @CustomerId;
SELECT * FROM Workloads AS w WHERE w.PersonId = @PersonId;
SELECT * FROM Workloads AS w JOIN People AS p ON p.Id = w.PersonId WHERE w.CustomerId = @CustomerId;
SELECT * FROM Workloads AS w JOIN Customers AS c ON c.Id = w.CustomerId WHERE w.PersonId = @PersonId;
SELECT * FROM Workloads AS w JOIN Customers AS c ON c.Id = w.CustomerId JOIN People AS p ON p.Id = w.PersonId WHERE w.CustomerId = @CustomerId;
SELECT * FROM Workloads AS w JOIN Customers AS c ON c.Id = w.CustomerId JOIN People AS p ON p.Id = w.PersonId WHERE w.PersonId = @PersonId;
*/