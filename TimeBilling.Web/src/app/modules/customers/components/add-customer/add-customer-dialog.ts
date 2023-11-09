/* eslint-disable @angular-eslint/component-class-suffix */
import { Component, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import { Customer } from "../../../../models/customer.model";
import { AngularMaterialModule } from "src/app/angular-material.module";

@Component({
  selector: 'app-add-customer-dialog',
  templateUrl: './add-customer-dialog.html',
  styleUrls: ['./add-customer-dialog.scss'],
  standalone: true,
  imports: [AngularMaterialModule],
})
export class AddCustomerDialog {
  caption = 'Add Customer';

  constructor(
    public dialogRef: MatDialogRef<AddCustomerDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Customer,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
