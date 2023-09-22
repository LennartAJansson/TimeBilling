import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddWorkloadComponent } from './components/add-workload/add-workload.component';
import { WorkloadsListComponent } from './components/workloads-list/workloads-list.component';
import { WorkloadDetailsComponent } from './components/workload-details/workload-details.component';
import { HomeComponent } from './components/home/home.component';
import { PeopleListComponent } from './components/people-list/people-list.component';
import { PersonDetailsComponent } from './components/person-details/person-details.component';
import { AddPersonComponent } from './components/add-person/add-person.component';
import { CustomersListComponent } from './components/customers-list/customers-list.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
import { AddCustomerComponent } from './components/add-customer/add-customer.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  { path: 'workloads', component: WorkloadsListComponent },
  { path: 'workload/:id', component: WorkloadDetailsComponent },
  { path: 'addworkload', component: AddWorkloadComponent },

  { path: 'people', component: PeopleListComponent },
  { path: 'person/:id', component: PersonDetailsComponent },
  { path: 'addperson', component: AddPersonComponent },

  { path: 'customers', component: CustomersListComponent },
  { path: 'customer/:id', component: CustomerDetailsComponent },
  { path: 'addcustomer', component: AddCustomerComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
