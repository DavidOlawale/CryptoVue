import { Component, OnInit } from '@angular/core';
import { TokenService } from '../../services/token.service';
import { BaseComponent } from '../../BaseComponent';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-info-page',
  standalone: true,
  imports: [],
  templateUrl: './info-page.component.html',
  styleUrl: './info-page.component.css'
})
export class InfoPageComponent extends BaseComponent {
  tokenData: TokenData | null = null;

  constructor(private tokenService: TokenService, private toastr: ToastrService){
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