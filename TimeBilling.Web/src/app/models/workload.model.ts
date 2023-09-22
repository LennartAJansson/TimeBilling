import { Customer } from "./customer.model";
import { Person } from "./person.model";

export class Workload {
  workloadId: any;
  begin?: Date;
  end?: Date;
  total: any;
  person?: Person;
  customer?: Customer;
}
