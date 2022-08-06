import { Component, OnInit } from '@angular/core';
import { AccountService } from '../account/account.service';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  products:IProduct[]=[]
  productTypes:IType[]=[]

  typeIdSelected:number|undefined=0 ;
  pageSize:number=5;
  pageNumber:number=1;
  totalCount:number|undefined;
  isAuth:boolean=false;

  constructor(private shopService:ShopService) { }

  ngOnInit(): void {



   this.getProducts();
   this.getTypes();

  }

  getProducts(){
    this.shopService.getProducts(this.pageNumber,this.pageSize,this.typeIdSelected).subscribe(res=>{
      this.products=res!.data
      this.pageNumber=res!.pageIndex
      this.pageSize=res!.pageSize
      this.totalCount=res!.count

      console.log(this.products)
    })
  }
  getTypes(){
    this.shopService.getTypes().subscribe(res=>{
      this.productTypes=[{id:0,name:'All'},...res]
      console.log(this.productTypes)
    })
  }

  onTypeSelected(typeId:number){
     this.typeIdSelected=typeId;

     this.getProducts();
  }
  onPageChange(event:any){
    this.pageNumber=event.page;
    this.getProducts();
  }

}
