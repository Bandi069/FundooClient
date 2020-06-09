import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/Service/account.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(private service: AccountService, private route: Router, private snackBar: MatSnackBar) { }
  email = new FormControl('', [
    Validators.required, Validators.email, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'),]);
  password = new FormControl('', [
    Validators.required, Validators.minLength(8),]);
  ngOnInit() {
  }
  loginForm() {
    // debugger;
    let pwd = new String(this.password.value);
    if (this.email.value != null && pwd.length >= 8) {
      const cred = {
        email: this.email.value,
        password: this.password.value
      };
      this.service.loginform(cred).subscribe(
        (result) => {
        this.snackBar.open('Login Successful', 'Dismiss', { duration: 3000 });
        console.log('result :', result );
      localStorage.setItem('Token', result.token);  
      this.route.navigate(['dashboard/displaynote'], { queryParams: { page: 'notes' } });

      },
      (error) => {
        console.log('error :', error );
        this.snackBar.open('Login unsuccesfull', '', { duration: 4000 });

      });
    }
  }
}
