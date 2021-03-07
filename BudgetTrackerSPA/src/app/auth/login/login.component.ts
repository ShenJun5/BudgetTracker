import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/shared/models/login';
import { User } from 'src/app/shared/models/user';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  invalidLogin!: boolean;
  returnUrl!: string;
  user!: User;
  userLogin: Login = {
    email: '', 
    password: ''
  }

  constructor(private authService: AuthService, private router: Router, private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.route.queryParams
    .subscribe(params => this.returnUrl = params.returnUrl || '/');
  }
  login() {
    console.log('login');
    this.authService.login(this.userLogin)
      .subscribe((response) => {
        if (response) {
          // console.log(' this is returnURL: ' + this.returnUrl);
          this.router.navigate([this.returnUrl]);
        } else {
          this.invalidLogin = true;
        }
      },
        (err: any) => { this.invalidLogin = true, console.log(err); });

  }
  
}
