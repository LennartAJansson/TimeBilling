/* eslint-disable @angular-eslint/component-class-suffix */
import { Component, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Workload } from '../../models/workload.model';

@Component({
  selector: 'app-add-workload-dialog',
  templateUrl: './add-workload-dialog.html',
  styleUrls: ['./add-workload-dialog.scss'],
  standalone: true,
  imports: [MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
})
export class AddWorkloadDialog {
  caption = 'Add Workload';

  constructor(
    public dialogRef: MatDialogRef<AddWorkloadDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Workload,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
  //TODO: Should be used from add workload in Person and Customer views
  //TODO: Should be used from add workload in Workloads view
  //TODO: Add DatePickers for Start and End Date
  //TODO: Add Combo Boxes for Person and Customer
  //TODO: If the incoming workload contains a Start and / or End Date then preselect them in the DatePickers
  //TODO: If the incoming workload contains a Person and / or Customer then preselect them in the comboboxes
}
