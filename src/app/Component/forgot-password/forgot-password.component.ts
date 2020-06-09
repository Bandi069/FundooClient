import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/Service/account.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(private service: AccountService, private route: Router, private snackBar: MatSnackBar) { }

  ngOnInit() {
  }
  email = new FormControl('', [
    Validators.required, Validators.email, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'),]);
    forgot()
    {
    if (this.email.value != null) {
      const form = {
        email: this.email.value,
      };
      this.service.forgotform(form).subscribe(result => {
        console.log('result :', result );
        this.snackBar.open('Reset Password Link Sent to Mail Successfully', ' ', { duration: 4000 });
       token: localStorage.setItem('token', result.toLocaleString());  
      });
      this.route.navigate(['/login']);
    }
    else
      this.snackBar.open('Invalid Email', '', { duration: 4000 });
    }
}
