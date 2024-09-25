use db_irisecom;

select * from tb_categorias;

insert into tb_categorias (Nome, Imagem) 
values ('Hardware', 'https://placehold.co/900x200'),
	   ('Periféricos', 'https://placehold.co/900x200'),
	   ('Notebooks', 'https://placehold.co/900x200'),
	   ('Cabos e Acessórios', 'https://placehold.co/900x200');

		insert into tb_usuarios (Nome, Email, Senha, Endereco, Bairro, Cidade, UF, CPF, DataNascimento, Imagem, CEP)
values ('Ana Pereira', 'ana.pereira@email.com', 'SenhaSegura321', 'Travessa do Sol, 78', 'Jardim das Flores', 'Belo Horizonte', 'MG', '12345678909', '1986-07-09',' ', '12345678');

select * from tb_produtos;

insert into tb_produtos (Nome, Descricao, Preco, InfoTecnica, Quantidade, CategoriaId, UsuarioId, Imagem)
values ('Notebook Azul', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
		3299, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 30, 3, 1, 'https://placehold.co/600x400'),
		('Teclado Mecânico', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
		299, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 24, 2, 1, 'https://placehold.co/600x400'),
		('Cabo HDMI', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
		20, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 200, 4, 1, 'https://placehold.co/600x400'),
		('HD 500GB', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.',
		600, 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', 50, 1, 1, 'https://placehold.co/600x400');


select * from tb_usuarios;

select p.Nome, p.CategoriaId, c.Id as Categoria, c.Nome as CategoriaNome
from tb_produtos p
inner join tb_categorias c
on p.CategoriaId = c.Id;

