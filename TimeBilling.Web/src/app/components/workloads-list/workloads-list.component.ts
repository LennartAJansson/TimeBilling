import { Component } from '@angular/core';
import { Workload } from '../../models/workload.model';
import { TimebillingService } from '../../services/timebilling.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-workloads-list',
  templateUrl: './workloads-list.component.html',
  styleUrls: ['./workloads-list.component.scss']
})
export class WorkloadsListComponent {
  caption = 'Workloads';

  public workloads: Workload[] = [];
  public dataSource = new MatTableDataSource<Workload>();
  columns: string[] = ['workloadId', 'customer', 'person', 'begin', 'end', 'total', 'actions'];

  public currentWorkload?: Workload | null;
  currentIndex = -1;

  constructor(private service: TimebillingService)
  {
  }

  ngOnInit(): void {
    this.retrieveWorkloads();
  }

  retrieveWorkloads(): void {
    this.service.getWorkloads().subscribe({
      next: (data) => {
        this.workloads = data;
        this.dataSource.data = this.workloads;
      },
      error: (e) => console.error(e),
    });
  }

  refreshList(): void {
    this.retrieveWorkloads();
    this.currentWorkload = null;
    this.currentIndex = -1;
  }

  setActiveWorkload(workload: Workload, index: number): void {
    console.log("Current selected:");
    console.log(workload);
    this.currentWorkload = workload;
    this.currentIndex = index;
  }

  removeWorkload(id: number): void {
    console.log("Current deleted:");
    console.log(id);
  //  this.service.deleteWorkload(id).subscribe({
  //    next: (res) => {
  //      this.refreshList();
  //    },
  //    error: (e) => console.error(e),
  //  });
  }
}
