import { Time } from "@angular/common";
import { Customer } from "./customer.model";
import { Person } from "./person.model";

export class Workload {
  workloadId?: number;
  begin?: Date;
  end?: Date;
  total?: Time;
  person?: Person;
  customer?: Customer;
}
