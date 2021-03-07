import { Component, Input, OnInit,Output, EventEmitter} from '@angular/core';
import { Expenditure } from '../../models/expenditure';

@Component({
  selector: 'app-expenditure',
  templateUrl: './expenditure.component.html',
  styleUrls: ['./expenditure.component.css']
})
export class ExpenditureComponent implements OnInit {

  @Input()
  expenditure!:Expenditure

  constructor() { }

  ngOnInit(): void {
  }

}
