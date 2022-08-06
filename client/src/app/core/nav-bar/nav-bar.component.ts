import { Component, Input, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  @Input()
  isLogIn:boolean=false;

  @Input()
  username:string=''
  constructor(private accountService:AccountService) { }

  ngOnInit(): void {
    debugger;

  }

  logoutNow(){
    debugger;
    this.accountService.logout()
    this.isLogIn=false;
  }

}
