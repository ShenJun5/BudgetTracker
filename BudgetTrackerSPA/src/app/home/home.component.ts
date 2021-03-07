import { Component, OnInit } from '@angular/core';
import { UserService } from "../core/services/user.service";
import { Income } from "../shared/models/income";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  incomes!: Income[];
  constructor(
    private userService: UserService
  ) {}

  ngOnInit(): void {
      this.userService.getIncomes().subscribe(m => {
      this.incomes = m;
    });
  }

}
