import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomersListComponent } from './components/customers-list/customers-list.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
import { AngularMaterialModule } from 'src/app/modules/angular-material/angular-material.module';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'customers', component: CustomersListComponent },
  { path: 'customer/:customerId', component: CustomerDetailsComponent },
];

@NgModule({
  declarations: [
    CustomersListComponent,
    CustomerDetailsComponent
  ],
  imports: [RouterModule.forRoot(routes),
    CommonModule, AngularMaterialModule
  ]
})
export class CustomersModule { }
