export interface Expenditures {
    userId: number;
    expenditures: Expenditure[];
  }

  export interface Expenditure{
    userId: number;
    amount: number;
    description: string;
    expDate?: any;
    remarks: string;
}