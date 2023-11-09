import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddWorkloadDialog } from './components/add-workload/add-workload-dialog';
import { WorkloadsListComponent } from './components/workloads-list/workloads-list.component';
import { WorkloadDetailsComponent } from './components/workload-details/workload-details.component';
import { AngularMaterialModule } from 'src/app/angular-material.module';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'workloads', component: WorkloadsListComponent },
  { path: 'workload/:workloadId', component: WorkloadDetailsComponent },
];

@NgModule({
  declarations: [
    // AddWorkloadDialog,
    WorkloadsListComponent,
    WorkloadDetailsComponent
  ],
  imports: [RouterModule.forRoot(routes),
    CommonModule, AngularMaterialModule
  ]
})
export class WorkloadsModule { }
