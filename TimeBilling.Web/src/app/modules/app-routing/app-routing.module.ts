import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../app/components/home/home.component';
import { WorkloadsListComponent } from '../workloads/components/workloads-list/workloads-list.component';
import { WorkloadDetailsComponent } from '../workloads/components/workload-details/workload-details.component';
import { PeopleListComponent } from '../people/components/people-list/people-list.component';
import { PersonDetailsComponent } from '../people/components/person-details/person-details.component';
import { CustomersListComponent } from '../customers/components/customers-list/customers-list.component';
import { CustomerDetailsComponent } from '../customers/components/customer-details/customer-details.component';

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
