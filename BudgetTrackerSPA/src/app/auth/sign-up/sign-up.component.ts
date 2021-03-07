import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  signupForm!: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder) {}

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
    console.log(this.signupForm);
    this.submitted = true;
    if (this.signupForm.invalid) {
      return;
    }
  }
  
}
