import { Component, Input, OnInit } from '@angular/core';
import { tap,switchMap, map } from 'rxjs/operators';
import { IAnnonymsUser } from 'src/app/shared/models/annonymsUser';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';


@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.css']
})
export class ProductItemComponent implements OnInit {

  @Input() product:IProduct|undefined;

  showForm:boolean=false;
  isnotValid:boolean=false;


  quantity:number=0;
  email:string='';
  isSubmitted:boolean=false;
  totalPrice:number=0;
  totalPriceAfterDiscount:number=0;



  constructor(private shopService:ShopService) { }

  ngOnInit(): void {
  }
  change(){
    this.showForm=true;
    console.log(this.quantity)
  }

  sendData(){
    this.totalPrice=this.quantity*(this.product?.price||1)

    debugger;


    if (this.email == undefined ||this.email == "" || !this.email.match("^\\S+@\\S+\\.\\S+$")) {
      this.isnotValid=true;

      setTimeout( ()=>{
        this.isnotValid=false;
        }, 3000)

    }
    else{
      this.annonymsUserRequest()

    }




  }

  annonymsUserRequest(){

    let annonymsUser:IAnnonymsUser={
      Id:0,
      Email:this.email,
      productId:this.product?.id.toString()||'',
      quantity:this.quantity,
      price:this.totalPrice

    };


    this.shopService.PlaceOrderReturnPriceAfterDiscount(annonymsUser)
    .pipe(
      map(res=>{
        console.log(res)
        this.totalPriceAfterDiscount=res
      })

    )
    .subscribe(res=>{
      this.showForm=false;
      this.quantity=0;
      this.email='';
      this.isSubmitted=true;

      setTimeout( ()=>{
        this.isSubmitted=false;
        this.totalPrice=0;
        this.totalPriceAfterDiscount=0;
        }, 7000)
    })



  }




}
