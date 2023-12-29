import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../../models/customer.model';
import { TimebillingService } from '../../../../services/timebilling.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { AddCustomerDialog } from '../add-customer/add-customer-dialog';
import { firstValueFrom } from 'rxjs';
import { GUID } from 'src/app/models/guid.model';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.scss']
})
export class CustomersListComponent implements OnInit {
  caption = 'Customers';

  public customers: Customer[] = [];
  public dataSource = new MatTableDataSource<Customer>();
  columns: string[] = ['customerId', 'name', 'actions'];

  public newCustomer: Customer = {};
  currentIndex = -1;

  constructor(private service: TimebillingService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.retrieveCustomers();
  }

  retrieveCustomers(): void {
    this.service.getCustomers().subscribe({
      next: (data) => {
        this.customers = data;
        this.dataSource.data = this.customers;
        console.log(this.customers);
      },
      error: (e) => console.error(e),
    });
  }

  refreshList(): void {
    this.retrieveCustomers();
    this.currentIndex = -1;
  }

  setActiveCustomer(customer: Customer, index: number): void {
    this.currentIndex = index;
  }

  removeCustomer(id: GUID): void {
    this.service.deleteCustomer(id).subscribe({
      next: (res) => {
        console.log(res);
        this.refreshList();
      },
      error: (e) => console.error(e),
    });
  }

  editCustomer(customer: Customer): void {
    this.newCustomer = Object.assign(this.newCustomer, customer);
    this.openDialog();
  }

  addCustomer(): void {
    this.newCustomer = {};
    this.openDialog();
  }

  async openDialog(): Promise<void> {
    const dialogRef = this.dialog.open(AddCustomerDialog, {
      data: this.newCustomer,
    });
    // let a = await firstValueFrom(this.service.createCustomer(this.newCustomer));

    let result = await firstValueFrom(dialogRef.afterClosed());


    if (result) {
      this.newCustomer = result;
      if (this.newCustomer!.name?.length !== 0) {

        if (this.newCustomer?.customerId === undefined) {
          this.newCustomer = await firstValueFrom(this.service.createCustomer(this.newCustomer));
            //lastValueFrom
          // this.service.createCustomer(this.newCustomer!).subscribe({
          //   next: (res) => {
          //     this.refreshList();
          //   },
          //   error: (e) => console.error(e),
          // })
        }
        else {
          this.newCustomer = await firstValueFrom(this.service.updateCustomer(this.newCustomer));

          // this.service.updateCustomer(this.newCustomer!).subscribe({
          //   next: (res) => {
          //     console.log("Update", res);
          //     //this.people.push(this.newPerson!);
          //     this.refreshList();
          //   },
          //   error: (e) => console.error(e),
          // });
        }
      }
    }
    this.refreshList();
    //TODO: Validate input
  }
}
