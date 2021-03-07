import { Component, OnInit } from '@angular/core';
import { UserService } from "../core/services/user.service";
import { Expenditure } from '../shared/models/expenditure';
import { Income } from "../shared/models/income";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  incomes!: Income[];
  expenditures!:Expenditure[];

  constructor(private userService: UserService) {}

  ngOnInit(): void {
      this.userService.getIncomes().subscribe(m => {this.incomes = m;});
      this.userService.getExpenditures().subscribe(m => {this.expenditures = m;});
  }

}
