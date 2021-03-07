import { elementEventFullName } from '@angular/compiler/src/view_compiler/view_compiler';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Login } from 'src/app/shared/models/login';
import { Signup } from 'src/app/shared/models/signup';
import { User } from 'src/app/shared/models/user';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private user!: User;

  private currentUserSubject = new BehaviorSubject<User>({} as User);
  public currentUser = this.currentUserSubject.asObservable();

  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private apiService: ApiService) { }

  signup(userRegister: Signup):Observable<boolean> {
    console.log(userRegister);
     return this.apiService.create('/account/register',userRegister)
      .pipe(map(response => {
        if(response){
        return true;
      }
      return false;
    }));
  }

  login(userLogin: Login): Observable<boolean> {
    console.log(userLogin);
    return this.apiService.create('/account/login', userLogin)
      .pipe(map(response => {
        if (response) {
          //this.populateUserInfo();
          return true;
        }
        return false;
      }));

  }


  
}
