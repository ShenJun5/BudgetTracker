import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { Signup } from 'src/app/shared/models/signup';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  signupForm!: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, private authService: AuthService) {}

  get f() { return this.signupForm.controls; }

  buildForm() {
    this.signupForm = this.fb.group({
      fullname: ['', Validators.required],
      email: [null,Validators.required],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    if (this.signupForm.invalid) {
      return;
    }
    console.log(this.signupForm);
    this.submitted = true;
    
  }

 
}
