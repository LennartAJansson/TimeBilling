import { Component, OnInit } from '@angular/core';
import { Workload } from '../../models/workload.model';
import { TimebillingService } from '../../services/timebilling.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { AddWorkloadDialog } from '../add-workload/add-workload-dialog';

@Component({
  selector: 'app-workloads-list',
  templateUrl: './workloads-list.component.html',
  styleUrls: ['./workloads-list.component.scss']
})
export class WorkloadsListComponent implements OnInit {
  caption = 'Workloads';

  public workloads: Workload[] = [];
  public dataSource = new MatTableDataSource<Workload>();
  columns: string[] = ['workloadId', 'customer', 'person', 'begin', 'end', 'total', 'actions'];

  public newWorkload: Workload = {};

  currentIndex = -1;

  constructor(private service: TimebillingService, public dialog: MatDialog) {
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
    this.currentIndex = -1;
  }

  setActiveWorkload(workload: Workload, index: number): void {
    this.currentIndex = index;
  }

  removeWorkload(id: number): void {
    this.service.deleteWorkload(id).subscribe({
      next: (res) => {
        console.log(res);
        this.refreshList();
      },
      error: (e) => console.error(e),
    });
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(AddWorkloadDialog, {
      data: this.newWorkload,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.newWorkload = result;
      console.log(this.newWorkload);
      //TODO: Validate input
      //TODO: Send to API
      //TODO: Add to workloads
    });
  }
}
