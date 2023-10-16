import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Designation, Employee } from './employee.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private myhttp: HttpClient) {}
  employeeUrl: string = 'https://localhost:7018/api/Employee';
  designationUrl: string = 'https://localhost:7018/api/Degination';

  //for getting data
  listEmployee: Employee[] = [];
  listDesignation: Designation[] = [];

  //for post data
  employeeData: Employee = new Employee();

  updateEmployee() {
    return this.myhttp.put(
      `${this.employeeUrl}/${this.employeeData.id}`,
      this.employeeData
    );
  }

  getEmployee(): Observable<Employee[]> {
    return this.myhttp.get<Employee[]>(this.employeeUrl);
  }
  saveEmployee() {
    return this.myhttp.post(this.employeeUrl, this.employeeData);
    this.getEmployee();
  }

  getDesignation(): Observable<Designation[]> {
    return this.myhttp.get<Designation[]>(this.designationUrl);
  }

  deleteEmployee(id: number) {
    return this.myhttp.delete(`${this.employeeUrl}/${id}`);
  }
}
