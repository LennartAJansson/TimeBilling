import { Component, OnInit } from '@angular/core';
import { Workload } from '../../models/workload.model';
//import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { TimebillingService } from '../../services/timebilling.service';

@Component({
  selector: 'app-workload-details',
  templateUrl: './workload-details.component.html',
  styleUrls: ['./workload-details.component.scss']
})
export class WorkloadDetailsComponent implements OnInit {
  caption = 'Workload';

  public workload: Workload = {};
  //public dataSource = new MatTableDataSource<Workload>();
  //columns: string[] = ['customerId', 'name', 'actions'];
  workloadId?: number;

  public currentWorkload?: Workload | null;
  currentIndex = -1;

  constructor(private activatedRoute: ActivatedRoute, private service: TimebillingService) {
  }

  ngOnInit(): void {
    const idParam = this.activatedRoute.snapshot.paramMap.get('workloadId');
    this.workloadId = idParam ? +idParam : 0;
    this.retrieveWorkloadsForCustomer(this.workloadId);
  }

  retrieveWorkloadsForCustomer(id: number): void {
    this.service.getWorkload(id).subscribe({
      next: (data) => {
        this.workload = data;
        //this.dataSource.data = this.workload;
        console.log(this.workload);
      },
      error: (e) => console.error(e),
    });
  }
}
