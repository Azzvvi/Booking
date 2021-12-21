create database booking;
\c booking;
create table users (id serial not null, login varchar(25) not null, password varchar(25) not null, name varchar(25) not null, primary key(id));
create table hotels (id serial not null, name varchar(25) not null, city varchar(25) not null, description varchar(250) not null, primary key(id));
create table rooms (id serial not null, hotel_id int not null references hotels(id), seats int not null, price int not null, begin_date date not null, end_date date not null, primary key(id), constraint check_date check (begin_date < end_date));

create index user_index on users (login, password);
create index room_index on rooms (hotel_id);
create index hotel_index on hotels (city);

create or replace function trf_delete_hotel() returns trigger as $body$ begin delete from rooms where hotel_id=old.id; return old; end; $body$ language plpgsql;
create trigger tr_delete_hotel before delete on hotels for each row execute procedure trf_delete_hotel();

insert into hotels (name, city, description) values ('отель1', 'астрахань', 'первый новый отель в Астрахани');
insert into hotels (name, city, description) values ('отель2', 'москва', 'первый новый отель в Москве');
insert into hotels (name, city, description) values ('отель3', 'астрахань', 'второй новый отель в Астрахани');
insert into rooms (hotel_id, seats, price, begin_date, end_date) values (1, 2, 15000, '2021-12-10', '2021-12-18');
insert into rooms (hotel_id, seats, price, begin_date, end_date) values (1, 3, 20000, '2021-12-01', '2021-12-16');
Insert into rooms (hotel_id, seats, price, begin_date, end_date) values (2, 1, 5000, '2021-12-01', '2021-12-31');
insert into rooms (hotel_id, seats, price, begin_date, end_date) values (3, 5, 25000, '2021-12-01', '2021-12-31');
