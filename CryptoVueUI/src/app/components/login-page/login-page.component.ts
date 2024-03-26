import { Component, ViewChild } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BaseComponent } from '../../BaseComponent';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [FormsModule, CommonModule, ReactiveFormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css'
})
export class LoginPageComponent extends BaseComponent {
  public loginForm: FormGroup;

  constructor(private authService: AuthService, private router: Router, private toastr: ToastrService, private formBuilder: FormBuilder){
    super(toastr);

    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    let formValues = this.loginForm.value;
    let email = formValues.email;
    let password = formValues.password

    this.authService.login(email, password)
      .subscribe({
        next: () => {
          this.showMessage('success', 'Login successful', '')
          this.router.navigate(['/']);
        },
        error: (error) => {
          this.showMessage('error', 'an error occured', '')
        }
      }
    );
  }

}
