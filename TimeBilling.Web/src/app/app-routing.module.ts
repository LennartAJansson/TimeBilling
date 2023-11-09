import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { WorkloadsListComponent } from './modules/workloads/components/workloads-list/workloads-list.component';
import { WorkloadDetailsComponent } from './modules/workloads/components/workload-details/workload-details.component';
import { PeopleListComponent } from './modules/people/components/people-list/people-list.component';
import { PersonDetailsComponent } from './modules/people/components/person-details/person-details.component';
import { CustomersListComponent } from './modules/customers/components/customers-list/customers-list.component';
import { CustomerDetailsComponent } from './modules/customers/components/customer-details/customer-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  // { path: 'workloads', component: WorkloadsListComponent },
  // { path: 'workload/:workloadId', component: WorkloadDetailsComponent },

  // { path: 'people', component: PeopleListComponent },
  // { path: 'person/:personId', component: PersonDetailsComponent },

  // { path: 'customers', component: CustomersListComponent },
  // { path: 'customer/:customerId', component: CustomerDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
