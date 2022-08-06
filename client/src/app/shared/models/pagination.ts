import { IProduct } from "./product";

export interface IPagination {
  count: number;
  pageSize: number;
  pageIndex: number;
  data: IProduct[];
}
