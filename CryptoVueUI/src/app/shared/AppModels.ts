export class DashboardDTO {
    name?: string;
    totalSupply: number;
    circulatingSupply: number;
    nonCirculatingSupply: number;
    nonCirculatingWallets: Wallet[];
}

export class Wallet {
    name?: string;
    address?: string;
    balance?: string;
}

export class VestingScheduleDTO {
    round: string;
    tokens: number;
    percentage: number;
    tGEUnlock: number;
    cliff: number;
    unlockStart: Date;
    unlockEnd: Date;
    summary: string;
}

export class UnlockScheduleDTO {
    name: number;
    date: Date;
    amount: number;
}
  
  