
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IAdmin } from 'src/app/shared/models/adminlogin';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  iAdmin:IAdmin={
    username:'',
    password:''
 };
  constructor(private accountService:AccountService,private router:Router) { }

  ngOnInit(): void {
  }

  LoginNow(){
    let val: boolean=this.accountService.login(this.iAdmin);

    if(val){
       this.router.navigateByUrl('/');
    }
    else{
      this.iAdmin.password='';
      this.iAdmin.username='';
    }

  }



}
