import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { IType } from '../shared/models/productType';
import {map} from 'rxjs/operators'
import { IAnnonymsUser } from '../shared/models/annonymsUser';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl:string=environment.baseUrl
  constructor(private http:HttpClient) { }




  getProducts(pageIndex:Number,pageSize:number,productTypeId?:number){
    let params=new HttpParams();

    if(productTypeId){
      params=params.append('ProductTypeId',productTypeId.toString())
    }
    params=params.append('pageIndex',pageIndex.toString());
    params=params.append('pageSize',pageSize.toString());
   return this.http.get<IPagination>(this.baseUrl+"Products",{observe:'response',params})
   .pipe(
    map(res=>{
      return res.body;
    })
   )
  }

  getTypes(){
    return this.http.get<IType[]>(this.baseUrl+"Products/types")
   }

   PlaceOrderReturnPriceAfterDiscount(order:IAnnonymsUser){
      return this.http.post<number>(this.baseUrl+"AnnonymsUsers/PlaceOrderReturnPriceAfterDiscount",order)
   }

   getCalculateDiscountOnProductItems(productId:string,itemsCount:number){
    let params=new HttpParams();
    params=params.append('productId',productId.toString());
    params=params.append('itemsCount',itemsCount.toString());
    return this.http.get<number>(this.baseUrl+"Products/CalculateDiscountOnProductItems",{observe:'response',params}).pipe(
      map(res=>{
        return res.body;
      })
    )

   }
}
