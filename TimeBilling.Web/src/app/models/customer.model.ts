import { GUID } from "./guid.model";
import { Workload } from "./workload.model";

export class Customer {
  customerId?: GUID;
  name?: string;
  workloads?: Workload[] = [];
}
