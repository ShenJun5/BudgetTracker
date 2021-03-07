import { Component, Input, OnInit,Output, EventEmitter} from '@angular/core';
import { Income } from '../../models/income';

@Component({
  selector: 'app-income',
  templateUrl: './income.component.html',
  styleUrls: ['./income.component.css']
})
export class IncomeComponent implements OnInit {

  @Input()
  income!: Income;

  constructor() { }

  ngOnInit(): void {
  }

}
