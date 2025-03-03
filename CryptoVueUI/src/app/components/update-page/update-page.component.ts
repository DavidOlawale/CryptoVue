import { Component, OnInit } from '@angular/core';
import { TokenService } from '../../services/token.service';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { BaseComponent } from '../../BaseComponent';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-update-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './update-page.component.html',
  styleUrl: './update-page.component.css'
})
export class UpdatePageComponent extends BaseComponent {
  errorMessage: string = "";
  isUpdating: boolean = false;

  constructor(private tokenService: TokenService, private authService: AuthService, private router: Router, private toastr: ToastrService){
    super(toastr);
  }

  override ngOnInit(): void {
    if(!this.authService.isLoggedIn()){
      this.router.navigate(['login']);
    }
  }

  async updateSupply() {
    this.isUpdating = true;
    this.errorMessage = "";
 
      this.tokenService.updateTokenData()
      .subscribe({
        next: ()=> {
          this.showMessage('success', 'Token supply data updated successfully', '')
          this.router.navigate(['/'])
        },
        error: ()=> {
          this.showMessage('error', 'An error occurred while updating supply data.', '')
          this.errorMessage = "An error occurred while updating supply data.";
        }
      });

  }
}
