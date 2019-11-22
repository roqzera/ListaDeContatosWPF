create database contatos;

use contatos;

create table contato(
	id_contato int auto_increment primary key,
    nome varchar(50),
    idade int,
    cidade varchar(50)
    )