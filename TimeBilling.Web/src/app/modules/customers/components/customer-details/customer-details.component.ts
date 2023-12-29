import { Component, OnInit } from '@angular/core';
import { Workload } from '../../../../models/workload.model';
import { MatTableDataSource } from '@angular/material/table';
import { Customer } from '../../../../models/customer.model';
import { TimebillingService } from '../../../../services/timebilling.service';
import { ActivatedRoute } from '@angular/router';
import { GUID, guid } from 'src/app/models/guid.model';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.scss']
})
export class CustomerDetailsComponent implements OnInit {
  caption = 'Customer';

  public workloads: Workload[] = [];
  public customer?: Customer;
  public dataSource = new MatTableDataSource<Workload>();
  columns: string[] = ['workloadId', 'person', 'begin', 'end', 'total', 'actions'];
  customerId?: GUID;

  public currentCustomer?: Customer | null;
  currentIndex = -1;

  constructor(private activatedRoute: ActivatedRoute, private service: TimebillingService) {
  }

  ngOnInit(): void {
    const idParam = this.activatedRoute.snapshot.paramMap.get('customerId');
    this.customerId = guid(idParam!);
    this.retrieveCustomer(this.customerId);
    this.retrieveWorkloadsForCustomer(this.customerId);
  }

  retrieveCustomer(id: GUID): void {
    this.service.getCustomer(id).subscribe({
      next: (data) => {
        this.customer = data;
      },
      error: (e) => console.error(e),
    });
  }

  retrieveWorkloadsForCustomer(id: GUID): void {
    this.service.getWorkloadsByCustomer(id).subscribe({
      next: (data) => {
        this.workloads = data;
        this.dataSource.data = this.workloads;
      },
      error: (e) => console.error(e),
    });
  }
}
