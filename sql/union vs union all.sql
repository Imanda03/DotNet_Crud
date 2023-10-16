create database unionPrac

use unionPrac

create table Teachers (id int identity primary key, sName varchar(150), city varchar(150))


select * from Teachers

select * from Students

update Teachers set sName = 'Anish Sharma', city = 'Pokhara' where id = 3

insert into Teachers( sName, city) values ('Anish Sharma', 'Pokhara')

select sName,city from Students union select sName,city from Teachers

select * from Students union select * from Teachers