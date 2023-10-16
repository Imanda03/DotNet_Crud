import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { Employee } from '../shared/employee.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css'],
})
export class EmployeeDetailsComponent implements OnInit {
  constructor(public empService: EmployeeService, public datePipe: DatePipe) {}
  ngOnInit() {
    this.empService.getEmployee().subscribe((data) => {
      this.empService.listEmployee = data;
    });
  }

  populateEmployee(selectedEmployee: Employee) {
    console.log(selectedEmployee);
    let df = this.datePipe.transform(selectedEmployee.doj, 'yyyy-MM-dd');
    selectedEmployee.doj = df;
    this.empService.employeeData = selectedEmployee;
  }

  delete(id: number) {
    if (confirm('Are you really want to delete the message??')) {
      this.empService.deleteEmployee(id).subscribe(
        (data) => {
          console.log('Recorded has been deleted...');
          this.empService.getEmployee().subscribe((data) => {
            this.empService.listEmployee = data;
          });
        },
        (error) => {
          console.log('Recoreded deleted');
        }
      );
    }
  }
}
