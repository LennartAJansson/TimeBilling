/* eslint-disable @angular-eslint/component-class-suffix */
import { Component, Inject } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { Customer } from "../../models/customer.model";

@Component({
  selector: 'app-add-customer-dialog',
  templateUrl: './add-customer-dialog.html',
  styleUrls: ['./add-customer-dialog.scss'],
  standalone: true,
  imports: [MatDialogModule, MatFormFieldModule, MatInputModule, FormsModule, MatButtonModule],
})
export class AddCustomerDialog {
  constructor(
    public dialogRef: MatDialogRef<AddCustomerDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Customer,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
