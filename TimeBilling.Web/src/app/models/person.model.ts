import { GUID } from "./guid.model";
import { Workload } from "./workload.model";

export class Person {
  personId?: GUID;
  name?: string;
  workloads?: Workload[] = [];
}
