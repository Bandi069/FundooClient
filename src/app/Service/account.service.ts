import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  registrationform(values) {
    return this.http.post(environment.Url + 'register', values);
  }
  loginform(parm) {
    return this.http.post<any>(environment.Url + 'login', parm);
  }
  forgotform(data) {
    return this.http.put(environment.Url + 'forget', data);
  }
  resetform(value) {
    return this.http.put(environment.Url + 'reset', value);
  }
  profilepic(img)
  {
    return this.http.put(environment.Url +'profilePic',img);
  }
}
