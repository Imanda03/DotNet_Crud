create database employeesDetails;

use employeesDetails;

create table Employees (EmployeeId int primary key NOT null identity ,
Salary int,
EmployeeName varchar(255));

select * from Employees;

insert into Employees ( Salary, EmployeeName) values
(2000, 'Gita');

update Employees set Salary = 5000 where EmployeeId = 1;

select EmployeeId, EmployeeName, salary from Employees order by salary Desc;

SELECT *
FROM Employees
where Salary < ( select max(Salary) from Employees ) order by Salary offset 1 row;

SELECT EmployeeName, Salary from Employees where Salary = (select max(Salary) FROM Employees WHERE salary < (SELECT MAX(salary) FROM Employees));

select EmployeeName, count(*) as duplicated_data from Employees group by EmployeeName having count(*) > 1;

select EmployeeName,sum(Salary) as total_salary from Employees group by EmployeeName having count(*) > 1;

select distinct EmployeeName from Employees

select EmployeeName, Salary from Employees where Salary >= 5000;

SELECT * FROM Employees
select sum(Salary) as 'Total Salary' from Employees group by Salary having salary > 50000
