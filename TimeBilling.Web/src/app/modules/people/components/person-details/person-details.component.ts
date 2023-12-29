import { Component, OnInit } from '@angular/core';
import { Workload } from '../../../../models/workload.model';
import { MatTableDataSource } from '@angular/material/table';
import { Person } from '../../../../models/person.model';
import { ActivatedRoute } from '@angular/router';
import { TimebillingService } from '../../../../services/timebilling.service';
import { GUID, guid } from 'src/app/models/guid.model';

@Component({
  selector: 'app-person-details',
  templateUrl: './person-details.component.html',
  styleUrls: ['./person-details.component.scss']
})
export class PersonDetailsComponent implements OnInit {
  caption = 'Person';

  public workloads: Workload[] = [];
  public person?: Person;
  public dataSource = new MatTableDataSource<Workload>();
  columns: string[] = ['workloadId', 'customer', 'begin', 'end', 'total', 'actions'];

  personId?: GUID;
  constructor(private activatedRoute: ActivatedRoute, private service: TimebillingService) {
  }

  ngOnInit(): void {
    const idParam = this.activatedRoute.snapshot.paramMap.get('personId');
    this.personId = guid(idParam!);
    this.retrievePerson(this.personId);
    this.retrieveWorkloadsForPerson(this.personId);
  }

  retrievePerson(id: GUID): void {
    this.service.getPerson(id).subscribe({
      next: (data) => {
        this.person = data;
        console.log(this.person);
      },
      error: (e) => console.error(e),
    });
  }

  retrieveWorkloadsForPerson(id: GUID): void {
    this.service.getWorkloadsByPerson(id).subscribe({
      next: (data) => {
        this.workloads = data;
        this.dataSource.data = this.workloads;
        console.log(this.workloads);
        console.log(this.dataSource.data);
      },
      error: (e) => console.error(e),
    });
  }
}
