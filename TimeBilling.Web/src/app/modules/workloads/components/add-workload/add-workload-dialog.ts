/* eslint-disable @angular-eslint/component-class-suffix */
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Workload } from '../../../../models/workload.model';
import { AngularMaterialModule } from 'src/app/angular-material.module';

@Component({
  selector: 'app-add-workload-dialog',
  templateUrl: './add-workload-dialog.html',
  styleUrls: ['./add-workload-dialog.scss'],
  standalone: true,
  imports: [AngularMaterialModule
    // , MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule
  ],
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
