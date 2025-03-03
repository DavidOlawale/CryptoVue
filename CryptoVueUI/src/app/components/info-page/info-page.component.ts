import { Component, OnInit } from '@angular/core';
import { TokenService } from '../../services/token.service';
import { BaseComponent } from '../../BaseComponent';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-info-page',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './info-page.component.html',
  styleUrl: './info-page.component.css'
})
export class InfoPageComponent extends BaseComponent {
  tokenData: TokenData | null = null;

  constructor(public tokenService: TokenService, public authService: AuthService, public toastr: ToastrService){
    super(toastr);
  }
  
  override ngOnInit() {
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