import { Component } from '@angular/core';
import { Person } from '../../models/person.model';
import { TimebillingService } from '../../services/timebilling.service';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.component.html',
  styleUrls: ['./people-list.component.scss']
})
export class PeopleListComponent {
  caption = 'People';

  public people: Person[] = [];
  public dataSource = new MatTableDataSource<Person>();
  columns: string[] = ['personId', 'name', 'actions'];

  public currentPerson?: Person | null;
  currentIndex = -1;
  constructor(private service: TimebillingService) {
  }

  ngOnInit(): void {
    this.retrievePeople();
  }

  retrievePeople(): void {
    this.service.getPeople().subscribe({
      next: (data) => {
        this.people = data;
        this.dataSource.data = this.people;
      },
      error: (e) => console.error(e),
    });
  }

  refreshList(): void {
    this.retrievePeople();
    this.currentPerson = null;
    this.currentIndex = -1;
  }

  setActivePerson(person: Person, index: number): void {
    console.log("Current selected:");
    console.log(person);
    this.currentPerson = person;
    this.currentIndex = index;
  }

  removePerson(id: number): void {
    console.log("Current deleted:");
    console.log(id);
  //  this.service.deletePerson(id).subscribe({
  //    next: (res) => {
  //      this.refreshList();
  //    },
  //    error: (e) => console.error(e),
  //  });
  }
}
