namespace TimeBilling.Api.Persistance.Constants;
public sealed class QueryStrings
{
  public const string ReadAllCustomers = @"SELECT * FROM Customers AS c ";
  public const string ReadCustomerById = ReadAllCustomers + WhereCustomerId;
  public const string ReadCustomersWithWorkloadsAndPerson = ReadAllCustomers + CustomerJoinWorkloads + WorkloadsJoinPerson;
  public const string ReadCustomerWithWorkloadsAndPersonByCustomer = ReadAllCustomers + CustomerJoinWorkloads + WorkloadsJoinPerson + WhereCustomerId;

  public const string ReadAllPeople = @"SELECT * FROM People AS p ";
  public const string ReadPersonById = ReadAllPeople + WherePersonId;
  public const string ReadPeopleWithWorkloadsAndCustomer = ReadAllPeople + PersonJoinWorkloads + WorkloadsJoinCustomer;
  public const string ReadPersonWithWorkloadsAndCustomerByPerson = ReadAllPeople + PersonJoinWorkloads + WorkloadsJoinCustomer + WherePersonId;

  public const string ReadAllWorkloads = @"SELECT * FROM Workloads AS w ";
  public const string ReadWorkloadById = ReadAllWorkloads + WhereWorkloadId;
  public const string ReadWorkloadsByCustomer = ReadAllWorkloads + WhereWorkloadCustomerId;
  public const string ReadWorkloadsByPerson = ReadAllWorkloads + WhereWorkloadPersonId;

  public const string ReadWorkloadsWithPeopleByCustomer = ReadAllWorkloads + WorkloadsJoinPerson + WhereWorkloadCustomerId;
  public const string ReadWorkloadsWithCustomerByPerson = ReadAllWorkloads + WorkloadsJoinCustomer + WhereWorkloadPersonId;

  public const string ReadWorkloadsWithCustomerAndPeople = ReadAllWorkloads + WorkloadsJoinCustomerAndPeople;
  public const string ReadWorkloadWithCustomerAndPeopleById = ReadAllWorkloads + WorkloadsJoinCustomerAndPeople + WhereWorkloadId;
  public const string ReadWorkloadsWithCustomerAndPeopleByCustomer = ReadAllWorkloads + WorkloadsJoinCustomerAndPeople + WhereWorkloadCustomerId;
  public const string ReadWorkloadsWithCustomerAndPeopleByPerson = ReadAllWorkloads + WorkloadsJoinCustomerAndPeople + WhereWorkloadPersonId;

  //Internal substrings:
  internal const string WhereCustomerId = @"WHERE c.Id = @CustomerId ";
  internal const string CustomerJoinWorkloads = @"LEFT JOIN Workloads AS w ON c.Id = w.CustomerId ";
  internal const string WherePersonId = @"WHERE p.Id = @PersonId ";
  internal const string PersonJoinWorkloads = @"LEFT JOIN Workloads AS w ON p.Id = w.PersonId ";
  internal const string WhereWorkloadId = @"WHERE w.Id = @WorkloadId ";
  internal const string WhereWorkloadCustomerId = @"WHERE w.CustomerId = @CustomerId ";
  internal const string WhereWorkloadPersonId = @"WHERE w.PersonId = @PersonId ";
  internal const string WorkloadsJoinCustomer = @"LEFT JOIN Customers AS c ON c.Id = w.CustomerId ";
  internal const string WorkloadsJoinPerson = "LEFT JOIN People AS p ON p.Id = w.PersonId ";
  internal const string WorkloadsJoinCustomerAndPeople = WorkloadsJoinCustomer + WorkloadsJoinPerson;
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
SELECT * FROM Workloads AS w INNER JOIN People AS p ON p.Id = w.PersonId WHERE w.CustomerId = @CustomerId;
SELECT * FROM Workloads AS w INNER JOIN Customers AS c ON c.Id = w.CustomerId WHERE w.PersonId = @PersonId;
SELECT * FROM Workloads AS w INNER JOIN Customers AS c ON c.Id = w.CustomerId INNER JOIN People AS p ON p.Id = w.PersonId WHERE w.CustomerId = @CustomerId;
SELECT * FROM Workloads AS w INNER JOIN Customers AS c ON c.Id = w.CustomerId INNER JOIN People AS p ON p.Id = w.PersonId WHERE w.PersonId = @PersonId;
SELECT * FROM Customers AS c INNER JOIN Workloads AS w ON c.Id = w.CustomerId INNER JOIN People AS p ON p.Id = w.PersonId
SELECT * FROM People AS p INNER JOIN Workloads AS w ON p.Id = w.PersonId INNER JOIN Customers AS c ON c.Id = w.CustomerId
*/