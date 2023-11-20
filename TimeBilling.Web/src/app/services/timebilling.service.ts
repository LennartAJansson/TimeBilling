import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Person } from '../models/person.model';
import { Observable, firstValueFrom } from 'rxjs';
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
    const url = this.peopleUrl + '/CreatePerson';
    return this.http.post<Person>(url, person);
    //awaitable
  }

  //Separat personservice
  async CreatePerson2(person: Person) : Promise<Person>{
    return await firstValueFrom(this.createPerson(person));
  }

  //ute i implementeringen, personResponse är en Person
  async a(){
    let personResponse = await this.CreatePerson2(new Person());
  }

  getPeople(): Observable<Person[]> {
    const url = this.peopleUrl + "/GetPeople";
    return this.http.get<Person[]>(url);
  }

  getPerson(personId: number): Observable<Person> {
    const url = this.peopleUrl + "/GetPerson/" + personId;
    return this.http.get<Person>(url);
  }

  updatePerson(person: Person): Observable<Person> {
    const url = this.peopleUrl + "/UpdatePerson";
    return this.http.put<Person>(url, person);
  }

  deletePerson(personId: number): Observable<Person> {
    const url = this.peopleUrl + "/DeletePerson/" + personId;
    return this.http.delete<Person>(url);
  }

  createCustomer(customer: Customer): Observable<Customer> {
    const url = this.customersUrl + '/CreateCustomer';
    return this.http.post<Customer>(url, customer);
  }

  getCustomers(): Observable<Customer[]> {
    const url = this.customersUrl + "/GetCustomers";
    return this.http.get<Customer[]>(url);
  }

  getCustomer(customerId: number): Observable<Customer> {
    const url = this.customersUrl + "/GetCustomer/" + customerId;
    return this.http.get<Customer>(url);
  }

  updateCustomer(customer: Customer): Observable<Customer> {
    const url = this.customersUrl + "/UpdateCustomer";
    return this.http.put<Customer>(url, customer);
  }

  deleteCustomer(customerId: number): Observable<Customer> {
    const url = this.customersUrl + "/DeleteCustomer/" + customerId;
    return this.http.delete<Customer>(url);
  }

  createWorkload(workload: Workload): Observable<Workload> {
    const url = this.workloadsUrl + '/CreateWorkload';
    return this.http.post<Workload>(url, workload);
  }

  getWorkloadsByCustomer(customerId:number): Observable<Workload[]> {
    const url = this.workloadsUrl + "/GetWorkloadsByCustomer/" + customerId;
    return this.http.get<Workload[]>(url);
  }

  getWorkloadsByPerson(personId: number): Observable<Workload[]> {
    const url = this.workloadsUrl + "/GetWorkloadsByPerson/" + personId;
    return this.http.get<Workload[]>(url);
  }

  getWorkloads(): Observable<Workload[]> {
    const url = this.workloadsUrl + "/GetWorkloads";
    return this.http.get<Workload[]>(url);
  }

  getWorkload(workloadId: number): Observable<Workload> {
    const url = this.workloadsUrl + "/GetWorkload/" + workloadId;
    return this.http.get<Workload>(url);
  }

  updateWorkload(workload: Workload): Observable<Workload> {
    const url = this.workloadsUrl + "/UpdateWorkload";
    return this.http.put<Workload>(url, workload);
  }

  deleteWorkload(workloadId: number): Observable<Workload> {
    const url = this.workloadsUrl + "/DeleteWorkload/" + workloadId;
    return this.http.delete<Workload>(url);
  }
}
