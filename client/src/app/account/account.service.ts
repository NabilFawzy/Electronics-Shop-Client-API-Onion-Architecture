import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl:string=environment.baseUrl

  user:IUser|undefined;
  private currentUserSource=new BehaviorSubject<IUser | null>(null);
  currentUser$=this.currentUserSource.asObservable();

  constructor(private http:HttpClient,private router:Router) { }


  isUserAthenticated(){
      const token:string|null =localStorage.getItem("jwt");

      if(token){
         return true;
      }
      return false;
  }
  getUserEmail(){
    const token:string|null =localStorage.getItem("email");

    return token;
}

  login(values:any){

      this.http.post(this.baseUrl+"account/login",values).pipe(
      map((user:any)=>{
        console.log(user)
        localStorage.setItem('token',user.token);
        localStorage.setItem('email',user.email);
        this.currentUserSource.next(user)
      })
     );

     if(this.isUserAthenticated())
         return true;
     return false;
  }


  logout(){
    localStorage.removeItem('token');
    localStorage.removeItem('email');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }


}
