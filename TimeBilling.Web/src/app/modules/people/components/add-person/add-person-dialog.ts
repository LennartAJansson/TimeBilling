/* eslint-disable @angular-eslint/component-class-suffix */
import { Component, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { Person } from '../../../../models/person.model';
import { AngularMaterialModule } from 'src/app/angular-material.module';

@Component({
  selector: 'app-add-person-dialog',
  templateUrl: './add-person-dialog.html',
  styleUrls: ['./add-person-dialog.scss'],
  standalone: true,
  imports: [AngularMaterialModule],
})
export class AddPersonDialog {
  caption = 'Add Person';

  constructor(
    public dialogRef: MatDialogRef<AddPersonDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Person,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
