import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/shared/employee.service';
import { NgForm } from '@angular/forms';
import { Employee } from 'src/app/shared/employee.model';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css'],
})
export class EmployeeFormComponent implements OnInit {
  constructor(public empService: EmployeeService) {}

  ngOnInit() {
    this.empService.getDesignation().subscribe((data) => {
      this.empService.listDesignation = data;
    });
  }

  submit(form: NgForm) {
    this.empService.employeeData.isMarried = form.value.isMarried = true
      ? 1
      : 0;
    this.empService.employeeData.isActive = form.value.isActive = true ? 1 : 0;

    if (this.empService.employeeData.id == 0) {
      this.insertEmployee(form);
    } else {
      this.updateEmployee(form);
    }
  }

  insertEmployee(myForm: NgForm) {
    this.empService.saveEmployee().subscribe((data) => {
      this.resetForm(myForm);
      this.refreshData();
      console.log('Data saved');
    });
  }

  updateEmployee(myForm: NgForm) {
    this.empService.updateEmployee().subscribe((data) => {
      console.log(myForm.value);
      this.resetForm(myForm);
      this.refreshData();
      console.log('Data has been update');
    });
  }

  resetForm(myForm: NgForm) {
    myForm.form.reset();
    this.empService.employeeData = new Employee();
  }

  refreshData() {
    this.empService.getEmployee().subscribe((res) => {
      this.empService.listEmployee = res;
    });
  }
}
