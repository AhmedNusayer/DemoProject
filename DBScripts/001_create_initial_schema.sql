
create table users(
    id int not null IDENTITY(1,1) primary key,
    name varchar(100),
	email varchar(100) not null,
	password varchar(100) not null
);

insert into users(name, email, password) VALUES ('Md. A', 'a@gmail.com', '1234');
insert into users(name, email, password) VALUES ('Md. B', 'b@gmail.com', 'abcd');
insert into users(name, email, password) VALUES ('Md. C', 'c@gmail.com', '1111');
insert into users(name, email, password) VALUES ('Md. D', 'd@gmail.com', 'aaaa');
insert into users(name, email, password) VALUES ('Md. E', 'e@gmail.com', '11aa');



insert into _changelog(applied_at, created_by, filename) VALUES (GETDATE(), 'nishat', '001_create_initial_schema.sql');
