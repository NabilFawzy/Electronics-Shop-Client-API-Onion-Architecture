import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AccountService } from './account/account.service';
import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client';

  isLogIn:boolean=false;
  username:string=''

  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
    if(this.accountService.isUserAthenticated()){
      this.isLogIn=true;
      this.username=this.accountService.getUserEmail()?.split("@")[0]||''
    }
  }

}
