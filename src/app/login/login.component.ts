import { Component, OnInit } from '@angular/core';
import { AuthenticatedResponse, LoginModel } from '../Interfaces/login.Model';
import { Router } from '@angular/router';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean | undefined;

  credentials: LoginModel = { username: '', password: '' };

  constructor(private router: Router, private http: HttpClient) {}

  ngOnInit(): void {}

  login = (form: NgForm) => {
    this.http
      .post<AuthenticatedResponse>(
        'https://localhost:7051/api/Auth/login',
        this.credentials,
        {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
        }
      )
      .subscribe({
        next: (response: AuthenticatedResponse) => {
          const token = response.token;
          localStorage.setItem('jwt', token);
          this.invalidLogin = false;
          this.router.navigate(['/']);
        },
        error: (err: HttpErrorResponse) => {
          this.invalidLogin = true;
          console.log(err);
        },
      });
  };
}
