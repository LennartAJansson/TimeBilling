import { Component, OnInit } from '@angular/core';
import { Workload } from '../../../../models/workload.model';
//import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { TimebillingService } from '../../../../services/timebilling.service';
import { GUID, guid } from 'src/app/models/guid.model';

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
  workloadId?: GUID;

  public currentWorkload?: Workload | null;
  currentIndex = -1;

  constructor(private activatedRoute: ActivatedRoute, private service: TimebillingService) {
  }

  ngOnInit(): void {
    const idParam = this.activatedRoute.snapshot.paramMap.get('workloadId');
    this.workloadId = guid(idParam!);
    this.retrieveWorkloadsForCustomer(this.workloadId);
  }

  retrieveWorkloadsForCustomer(id: GUID): void {
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
