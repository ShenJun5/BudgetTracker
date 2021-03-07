export interface Incomes{
    userId: number;
    incomes: Income[];
}

export interface Income{
    userId: number;
    amount: number;
    description: string;
    incomeDate?: any;
    remarks: string;
}