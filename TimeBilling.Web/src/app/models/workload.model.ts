import { Time } from "@angular/common";
import { Customer } from "./customer.model";
import { Person } from "./person.model";
import { GUID } from "./guid.model";

export class Workload {
  workloadId?: GUID;
  begin?: Date;
  end?: Date;
  total?: Time;
  person?: Person;
  customer?: Customer;
}
