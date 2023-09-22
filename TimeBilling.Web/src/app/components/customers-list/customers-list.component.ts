import { Component } from '@angular/core';
import { Customer } from '../../models/customer.model';
import { TimebillingService } from '../../services/timebilling.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-customers-list',
  templateUrl: './customers-list.component.html',
  styleUrls: ['./customers-list.component.scss']
})
export class CustomersListComponent {
  caption = 'Customers';

  public customers: Customer[] = [];
  public dataSource = new MatTableDataSource<Customer>();
  columns: string[] = ['customerId', 'name', 'actions'];

  public currentCustomer?: Customer | null;
  currentIndex = -1;

  constructor(private service: TimebillingService) {
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
    this.currentCustomer = null;
    this.currentIndex = -1;
  }

  setActiveCustomer(customer: Customer, index: number): void {
    console.log("Current selected:");
    console.log(customer);
    this.currentCustomer = customer;
    this.currentIndex = index;
  }

  removeCustomer(id: number): void {
    console.log("Current deleted:");
    console.log(id);
  //  this.service.deleteCustomer(id).subscribe({
  //    next: (res) => {
  //      this.refreshList();
  //    },
  //    error: (e) => console.error(e),
  //  });
  }
}
