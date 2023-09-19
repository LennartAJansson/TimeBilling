﻿namespace TimeBilling.Domain.Abstract;

using TimeBilling.Model;


public interface ITimeBillingService
{
    Task<Person> CreatePerson(Person person);
    Task<Person?> ReadPerson(int personId);
    Task<IEnumerable<Person>> ReadPeople();
    Task<Person?> UpdatePerson(Person person);
    Task<Person?> DeletePerson(int personId);

    Task<Customer> CreateCustomer(Customer customer);
    Task<Customer?> ReadCustomer(int customerId);
    Task<IEnumerable<Customer>> ReadCustomers();
    Task<Customer?> UpdateCustomer(Customer customer);
    Task<Customer?> DeleteCustomer(int customerId);

    Task<Workload> BeginWorkload(Workload workload);
    Task<Workload?> ReadWorkload(int workloadId);
    Task<IEnumerable<Workload>> ReadWorkloads();
    Task<IEnumerable<Workload>> ReadWorkloadsByPerson(int personId);
    Task<IEnumerable<Workload>> ReadWorkloadsByCustomer(int customerId);
    Task<Workload?> EndWorkload(Workload workload);
    Task<Workload?> DeleteWorkload(int workloadId);

}