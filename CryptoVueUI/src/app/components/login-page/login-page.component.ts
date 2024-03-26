import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BaseComponent } from '../../BaseComponent';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent extends BaseComponent {
  email = '';
  password = '';
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private router: Router, private toastr: ToastrService){
    super(toastr);
  }

  onSubmit() {
    this.errorMessage = null; // Clear previous error message
    this.authService.login(this.email, this.password)
      .subscribe({
        next: () => {
          this.showMessage('success', 'Login successful', '')
          this.router.navigate(['/']);
        },
        error: (error) => {
          this.showMessage('error', 'an error occured', '')
          this.errorMessage = error.message || 'Login failed!';
        }
      }
    );
  }

}
