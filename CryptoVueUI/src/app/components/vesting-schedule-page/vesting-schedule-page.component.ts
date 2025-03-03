import { Component, OnInit } from '@angular/core';
import { NgChartsModule  } from 'ng2-charts';
import { ChartOptions, ChartData, ChartType, ChartConfiguration } from 'chart.js';
import { DashboardDTO, UnlockScheduleDTO, VestingScheduleDTO } from '../../shared/AppModels';
import { TokenService } from '../../services/token.service';
import { CommonModule } from '@angular/common';
import { NumberFormatPipe } from '../../pipes/number-format.pipe';

@Component({
  selector: 'app-vesting-schedule-page',
  standalone: true,
  imports: [ NgChartsModule, CommonModule, NumberFormatPipe ],
  templateUrl: './vesting-schedule-page.component.html',
  styleUrl: './vesting-schedule-page.component.css'
})
export class VestingSchedulePageComponent implements OnInit {
  chartData: ChartData<'doughnut'>;
  dashboardData: DashboardDTO;
  vestingSchedules: VestingScheduleDTO[];
  unlockSchedules: UnlockScheduleDTO[];

  scheduleMode: 'table' | 'timeline' | 'chart' = 'table';

  public doughnutChartOptions: ChartConfiguration<'doughnut'>['options'] = {
    offset: 0,
    aspectRatio: 1,
    cutout:73.5,
    responsive: true,
    animation: {
      animateRotate: true,
    }
  };
  constructor(private tokenService: TokenService){}

  async ngOnInit() {
    this.dashboardData = await this.tokenService.getDashboardData();
    this.vestingSchedules = await this.tokenService.getVestingSchedule();
    this.unlockSchedules = await this.tokenService.getUnlockSchedule();

    this.chartData = {
      labels: ['In Circulation', 'Locked'],
      datasets: [
        {
          type: 'doughnut', 
          data: [this.dashboardData.circulatingSupply, this.dashboardData.nonCirculatingSupply],
          backgroundColor: ['#B084F6', '#333'],
          //borderWidth: 0,
        }
      ]
    };
  }

  changeScheduleMode(mode: 'table' | 'timeline' | 'chart'){
    this.scheduleMode = mode;
  }
  

  getTotalAmountforRound(roundName: string){
    let round = this.vestingSchedules.find(i => i.round === roundName);
    return round ? round.tokens : null;
  }
}
