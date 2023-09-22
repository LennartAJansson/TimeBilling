import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Person } from '../models/person.model';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer.model';
import { Workload } from '../models/workload.model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TimebillingService {
  private http: HttpClient;
  private peopleUrl: string = environment.baseUrl + "/People";
  private customersUrl: string = environment.baseUrl + "/Customers";
  private workloadsUrl: string = environment.baseUrl + "/Workloads";

  constructor(@Inject(HttpClient) http: HttpClient) {
    this.http = http;
  }

  createPerson(person: Person): Observable<Person> {
    var url = this.peopleUrl + '/CreatePerson';
    return this.http.post<Person>(url, person);
  }

  getPeople(): Observable<Person[]> {
    var url = this.peopleUrl + "/GetPeople";
    return this.http.get<Person[]>(url);
  }

  getPerson(personId: number): Observable<Person> {
    var url = this.peopleUrl + "/GetPerson?personId=" + personId;
    return this.http.get<Person>(url);
  }

  updatePerson(person: Person): Observable<Person> {
    var url = this.peopleUrl + "/UpdatePerson";
    return this.http.put<Person>(url, person);
  }

  deletePerson(personId: number): Observable<Person> {
    var url = this.peopleUrl + "/DeletePerson?personId=" + personId;
    return this.http.delete<Person>(url);
  }

  createCustomer(customer: Customer): Observable<Customer> {
    var url = this.customersUrl + '/CreateCustomer';
    return this.http.post<Customer>(url, customer);
  }

  getCustomers(): Observable<Customer[]> {
    var url = this.customersUrl + "/GetCustomers";
    return this.http.get<Customer[]>(url);
  }

  getCustomer(customerId: number): Observable<Customer> {
    var url = this.customersUrl + "/GetCustomer?customerId=" + customerId;
    return this.http.get<Customer>(url);
  }

  updateCustomer(customer: Customer): Observable<Customer> {
    var url = this.customersUrl + "/UpdateCustomer";
    return this.http.put<Customer>(url, customer);
  }

  deleteCustomer(customerId: number): Observable<Customer> {
    var url = this.customersUrl + "/DeleteCustomer?customerId=" + customerId;
    return this.http.delete<Customer>(url);
  }

  createWorkload(workload: Workload): Observable<Workload> {
    var url = this.workloadsUrl + '/CreateWorkload';
    return this.http.post<Workload>(url, workload);
  }

  getWorkloads(): Observable<Workload[]> {
    var url = this.workloadsUrl + "/GetWorkloads";
    return this.http.get<Workload[]>(url);
  }

  getWorkload(workloadId: number): Observable<Workload> {
    var url = this.workloadsUrl + "/GetWorkload?workloadId=" + workloadId;
    return this.http.get<Workload>(url);
  }

  updateWorkload(workload: Workload): Observable<Workload> {
    var url = this.workloadsUrl + "/UpdateWorkload";
    return this.http.put<Workload>(url, workload);
  }

  deleteWorkload(workloadId: number): Observable<Workload> {
    var url = this.workloadsUrl + "/DeleteWorkload?workloadId=" + workloadId;
    return this.http.delete<Workload>(url);
  }
}
