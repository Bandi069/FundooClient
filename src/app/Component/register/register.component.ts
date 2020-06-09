import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AccountService } from 'src/app/Service/account.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor(private service: AccountService, private route: Router, private snackBar: MatSnackBar) { }
  hide = true;
  firstName = new FormControl('', [
    Validators.required, Validators.minLength(4), Validators.pattern('^[a-zA-Z]*'),]);
  ngOnInit() {
  }
  lastName = new FormControl('', [
    Validators.required, Validators.minLength(4), Validators.pattern('^[a-zA-Z]*'),])

  email = new FormControl('', [
    Validators.required, Validators.email, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$'),]);

  password = new FormControl('', [
    Validators.required, Validators.minLength(8),]);

  registrationForm() {
    let fname = new String(this.firstName.value);
    let lname = new String(this.lastName.value);
    let pwd = new String(this.password.value);
    if (fname.length >= 4 && lname.length >= 4 && pwd.length >= 8) {
      const form = {
        firstName: this.firstName.value,
        lastName: this.lastName.value,
        email: this.email.value,
        password: this.password.value
      };
      this.service.registrationform(form).subscribe(
        (result) => {
          this.snackBar.open('Register Successfull', 'Dismiss', { duration: 3000 });
          console.log('result :', result);
          this.route.navigate(['/login']);

        },
        (error) => {
          this.snackBar.open('Registration Failed', '', { duration: 4000 });
      });
    }
  }
}
