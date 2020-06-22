import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/Service/account.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.scss']
})
export class ResetPasswordComponent implements OnInit {

  constructor(private service: AccountService, private route: Router, private snackBar: MatSnackBar) { }

  password = new FormControl('', [
    Validators.required, Validators.minLength(8),]);
  confirmPassword = new FormControl('', [
    Validators.required, Validators.minLength(8),]);
  ngOnInit() {
  }
  resetPassword() {
    debugger;
    if (this.password != null && this.confirmPassword === this.password) {
      const data =
      {
        password: this.password,
        confirmPassword: this.confirmPassword
      };
      this.service.resetform(data).subscribe(Response => {
        console.log('response', Response);
        this.snackBar.open('Password Reset Successfull', '', { duration: 4000, horizontalPosition: 'start' });
        token: localStorage.setItem('token', Response.toLocaleString());
      });
    }
    else
      this.snackBar.open('Incorrect Password', '', { duration: 4000 , horizontalPosition: 'start'});
  }
}
