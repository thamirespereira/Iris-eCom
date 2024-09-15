create database db_irisecom;
use db_irisecom;

create table [tb_categorias](
		Id int identity(1,1) not null,
		Nome varchar(255) not null,
		Imagem varchar(5000),
	constraint [PK_TB_CATEGORIAS] primary key clustered
	(
	[Id] asc
	) with (ignore_dup_key = off)
	)

create table [tb_usuarios](
		Id int identity(1,1) not null,
		Nome varchar(500) not null,
		Email varchar(255) not null,
		Senha varchar(20) not null,
		CEP varchar(8) not null,
		Endereco varchar(255) not null,
		Bairro varchar(255) not null,
		Cidade varchar(255) not null,
		UF varchar(2) not null,
		CPF varchar(11) not null,
		DataNascimento date not null,
		Imagem varchar(5000),
	constraint [PK_TB_USUARIOS] primary key clustered
	(
	[Id] asc
	) with (ignore_dup_key = off)
	)

create table [tb_produtos](
		Id int identity(1,1) not null,
		Nome varchar(255) not null,
		Descricao text not null,
		Preco decimal not null,
		InfoTecnica text not null,
		Quantidade int,
		Imagem varchar(5000),
		CategoriaId int not null,
		UsuarioId int not null,
	constraint [PK_TB_PRODUTOS] primary key clustered
	(
	[Id] asc
	) with (ignore_dup_key = off)
	)
	 
alter table [tb_produtos] 
with check add constraint [tb_produtos_fk0] 
foreign key ([CategoriaId]) 
references [tb_categorias]([Id]) on update cascade
go

alter table [tb_produtos] check constraint [tb_produtos_fk0] 
go

alter table [tb_produtos]
with check add constraint [tb_produtos_fk1]
foreign key ([UsuarioId])
references [tb_usuarios]([Id]) on update cascade
go

alter table [tb_produtos] check constraint [tb_produtos_fk1]

select * from tb_categorias;
select * from tb_produtos;
select * from tb_usuarios;

