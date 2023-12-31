import { Component, OnInit, inject } from '@angular/core';
import { Person } from '../../../../models/person.model';
import { TimebillingService } from '../../../../services/timebilling.service';
import { MatTableDataSource} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { AddPersonDialog } from '../add-person/add-person-dialog';
import { GUID } from 'src/app/models/guid.model';

@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.component.html',
  styleUrls: ['./people-list.component.scss']
})
export class PeopleListComponent implements OnInit{
  caption = 'People';

  public people: Person[] = [];
  public dataSource = new MatTableDataSource<Person>();
  columns: string[] = ['personId', 'name', 'actions'];

  service2 = inject(TimebillingService);

  public newPerson?: Person = {}
;
  currentIndex = -1;
  constructor(private service: TimebillingService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.retrievePeople();
  }

  retrievePeople(): void {
    this.service.getPeople().subscribe({
      next: (data) => {
        this.people = data;
        this.dataSource.data = this.people;
        console.log(this.people);
      },
      error: (e) => console.error(e),
    });
  }

  refreshList(): void {
    this.retrievePeople();
    this.currentIndex = -1;
  }

  setActivePerson(person: Person, index: number): void {
    this.currentIndex = index;
  }

  removePerson(id: GUID): void {
    this.service.deletePerson(id).subscribe({
      next: (res) => {
        console.log(res);
        this.refreshList();
      },
      error: (e) => console.error(e),
    });
  }

  openDialog(): void {
    this.newPerson = {};
    const dialogRef = this.dialog.open(AddPersonDialog, {
      data: this.newPerson,
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if(result!== undefined){
        this.newPerson = result;
        console.log(this.newPerson);
        if(this.newPerson!.name?.length !== 0){
          this.service.createPerson(this.newPerson!).subscribe({
            next: (res) => {
              console.log(res);
              //this.people.push(this.newPerson!);
              this.refreshList();
            },
            error: (e) => console.error(e),
          });
        }
      }
      //TODO: Validate input
    });
  }
}
