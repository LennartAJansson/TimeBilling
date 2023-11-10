import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddPersonDialog } from './components/add-person/add-person-dialog';
import { PeopleListComponent } from './components/people-list/people-list.component';
import { PersonDetailsComponent } from './components/person-details/person-details.component';
import { AngularMaterialModule } from 'src/app/modules/angular-material/angular-material.module';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'people', component: PeopleListComponent },
  { path: 'person/:personId', component: PersonDetailsComponent },
];

@NgModule({
  declarations: [
    // AddPersonDialog,
    PeopleListComponent,
    PersonDetailsComponent
  ],
  imports: [RouterModule.forRoot(routes),
    CommonModule, AngularMaterialModule
  ]
})
export class PeopleModule { }
