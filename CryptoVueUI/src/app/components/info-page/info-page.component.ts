import { Component, OnInit } from '@angular/core';
import { TokenService } from '../../services/token.service';

@Component({
  selector: 'app-info-page',
  standalone: true,
  imports: [],
  templateUrl: './info-page.component.html',
  styleUrl: './info-page.component.css'
})
export class InfoPageComponent implements OnInit {
  tokenData: TokenData | null = null;

  constructor(private tokenService: TokenService){
  }
  
  ngOnInit() {
    this.tokenService.getTokenData()
      .subscribe(data => {
        this.tokenData = data;
      });
  }

}


export interface TokenData {
  name: string;
  totalSupply: number;
  circulatingSupply: number;
}