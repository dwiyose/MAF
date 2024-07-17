CREATE DATABASE MASTER_DB;
CREATE DATABASE TRANSACTION_DB;

USE MASTER_DB;
CREATE TABLE ms_user(
user_id bigint,
user_name varchar(20),
password varchar(50),
is_active bit,
Primary Key (user_id));

CREATE TABLE ms_location_storage(
location_id varchar(10),
location_name varchar(100),
primary key (location_id));


USE TRANSACTION_DB;
CREATE TABLE tr_bpkb(
agreement_number varchar(100),
bpkb_no varchar(100),
branch_id varchar(10),
bpkb_date datetime,
faktur_no varchar(100),
location_id varchar(10),
police_no varchar(20),
bpkb_date_in datetime,
created_by varchar(20),
created_on datetime,
last_updated_by varchar(20),
last_updated_on datetime
primary key (agreement_number))

USE MASTER_DB 
INSERT INTO ms_user(user_id, user_name, password, is_active)
VALUES 
(1, 'jhonUmiro', 'admin1*', 1),
(2, 'trisNatan', 'admin2@', 1),
(3, 'hugoRess', 'admin3#*', 0)
;