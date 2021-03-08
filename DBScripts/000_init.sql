drop database if exists demo_project;
create database demo_project;
use demo_project;

create table _changelog(
    id int not null IDENTITY(1,1) primary key,
    applied_at datetime not null,
    created_by varchar(100) not null,
    filename varchar(200) not null
);

insert into _changelog(applied_at, created_by, filename) VALUES (GETDATE(), 'nishat', '000_init.sql');
