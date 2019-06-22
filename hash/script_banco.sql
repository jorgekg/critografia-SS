create database hash

use hash

create table user(
id int not null,
login varchar(255) not null,
pass varchar(255) not null,
sal varchar(255),
hash_pass varchar(255),
updateAt datetime,
primary key (id)
)

SELECT * FROM user