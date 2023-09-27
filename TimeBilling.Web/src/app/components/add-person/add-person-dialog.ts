/* eslint-disable @angular-eslint/component-class-suffix */
import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Person } from '../../models/person.model';

@Component({
  selector: 'app-add-person-dialog',
  templateUrl: './add-person-dialog.html',
  styleUrls: ['./add-person-dialog.scss'],
  standalone: true,
  imports: [MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
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
