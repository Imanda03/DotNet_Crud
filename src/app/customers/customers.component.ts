import { Component, OnInit } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
})
export class CustomersComponent implements OnInit {
  customers: any;
  token: any;

  constructor(private http: HttpClient) {
    this.token = localStorage.getItem('jwt');
  }

  ngOnInit(): void {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${this.token}`,
    });

    this.http
      .get('https://localhost:7051/api/Customer', { headers: headers })
      .subscribe({
        next: (result: any) => (this.customers = result),
        error: (err: HttpErrorResponse) => console.log(err),
      });
  }
}
