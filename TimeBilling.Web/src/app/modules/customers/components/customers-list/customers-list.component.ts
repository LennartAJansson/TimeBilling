import { Component, OnInit } from '@angular/core';
import { Customer } from '../../../../models/customer.model';
import { TimebillingService } from '../../../../services/timebilling.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { AddCustomerDialog } from '../add-customer/add-customer-dialog';

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

  public newCustomer?: Customer = {};
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

  removeCustomer(id: number): void {
    this.service.deleteCustomer(id).subscribe({
      next: (res) => {
        console.log(res);
        this.refreshList();
      },
      error: (e) => console.error(e),
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddCustomerDialog, {
      data: this.newCustomer,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.newCustomer = result;
      console.log(this.newCustomer);
      //TODO: Validate input
      //TODO: Send to API
      //TODO: Add to customers
    });
  }
}
