use db_irisecom;

select * from tb_categorias;

insert into tb_categorias (Nome, Imagem) 
values ('Hardware', 'sedfdfd'),
	   ('Perif�ricos', 'sedfdfd'),
	   ('Notebooks', 'sedfdfd'),
	   ('Cabos e Acess�rios', 'sedfdfd');


select * from tb_produtos;

insert into tb_produtos (Nome, Descricao, Preco, InfoTecnica, Quantidade, CategoriaId, UsuarioId)
values ('Notebook Inspiron 15', 'O Notebook Inspiron 15 � um laptop vers�til e potente, ideal para trabalho e entretenimento. Ele vem equipado com processadores Intel ou AMD, tela de 15.6 polegadas Full HD, e oferece diversas op��es de mem�ria RAM e armazenamento, garantindo desempenho �gil em multitarefas. Com design elegante e durabilidade, o Inspiron 15 conta ainda com uma boa autonomia de bateria, teclado confort�vel e uma ampla gama de conectividade, tornando-o perfeito para usu�rios que buscam produtividade e mobilidade no dia a dia.',
		3199, 'Processador: 13� gera��o Intel� Core� i5-1334U (10-core, cache de 12MB, at� 4.60GHz)', 30, 3, 1);

		insert into tb_usuarios (Nome, Email, Senha, Endereco, Bairro, Cidade, UF, CPF, DataNascimento, Imagem, CEP)
values ('Thamires', 'thamiresemail.com', '123456', 'rua rodolfo', 'miguel couto', 'nova iguacu', 'rj', '12345678909', '1996-08-09',' ', '12345678');

UPDATE tb_categorias
SET Imagem = 'sedfdfd'

select * from tb_categorias; 

insert into tb_produtos (Nome, Descricao, Preco, InfoTecnica, Quantidade, CategoriaId, UsuarioId)
values ('SSD', 'teste', 300, 'teste', 200, 1, 1);

select * from tb_usuarios;

select p.Nome, p.CategoriaId, c.Id as Categoria, c.Nome as CategoriaNome
from tb_produtos p
inner join tb_categorias c
on p.CategoriaId = c.Id;

insert into tb_produtos (Nome, Descricao, Preco, InfoTecnica, CategoriaId)
values ('Mouse', 'teste', 34, 'teste', 2);