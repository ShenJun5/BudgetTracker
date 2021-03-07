import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Expenditure } from 'src/app/shared/models/expenditure';
import { Expenditures } from 'src/app/shared/models/expenditures';
import { Income } from 'src/app/shared/models/income';
import { Incomes } from 'src/app/shared/models/incomes';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService:ApiService) { }

  //GetUserDetails

  createIncome(income: Income){
    return this.apiService.create('/user/income',income);
  }

  createExpenditure(expenditure: Expenditure){
    return this.apiService.create('/user/expenditure',expenditure);
  }

  deleteIncome(income: Income){
    return this.apiService.create('/user/delincome',income);
  }

  deleteExpenditure(expenditure: Expenditure){
    return this.apiService.create('/user/delexpenditure',expenditure);
  }

  getUserExpenditures(id: number): Observable<Expenditures> {
    return this.apiService.getOne(`${'/user/'}${id}${'/expenditures'}`);
  }

  getUserIncomes(id: number): Observable<Incomes> {
    return this.apiService.getOne(`${'/user/'}${id}${'/incomes'}`);
  }

  getExpenditures(): Observable<any[]> {
    return this.apiService.getAll('/user/expenditures');
  }

  getIncomes(): Observable<any[]> {
    return this.apiService.getAll('/user/incomes');
  }
 // updateExpenditure

 // updateIncome
}
