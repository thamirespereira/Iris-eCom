<h1>Íris eCom - API</h1>

<div>
  <h2>Sobre</h2>
  <p>A API Íris eCom permite aos usuários gerenciar suas contas e interagir com produtos e categorias de maneira eficiente. Com uma interface RESTful simples, a API possibilita operações de CRUD (Create, Read, Update, Delete) tanto para usuários quanto para produtos e categorias, garantindo flexibilidade para desenvolvedores em integrar funcionalidades de e-commerce de forma ágil.</p>
<h3>🔗Funcionalidades</h3>
  <ul>
    <li><h4>Usuários:</h4></li>
    <li>Cadastrar um novo usuário.</li>
    <li>Buscar informações do usuário.</li>
    <li>Atualizar os dados do usuário.</li>
    <li>Excluir um usuário.</li>
</ul>
<ul>
  <li><h4>Produtos:</h4></li>
  <li>Cadastrar novos produtos.</li>
  <li>Buscar produtos existentes.</li>
  <li>Atualizar detalhes de produtos.</li>
  <li>Excluir produtos.</li>
</ul>
<ul>
  <li><h4>Categorias:</h4></li>
  <li>Cadastrar novas categorias de produtos.</li>
  <li>Buscar categorias.</li>
  <li>Atualizar informações de categorias.</li>
  <li>Excluir categorias.</li>
</ul>

<h3>Endpoints</h3>
<h4>Usuários</h4>
<strong>1. Cadastrar um usuário</strong>
<ul>
  <li>URL: /apiUsuario</li>
  <li>Método: POST</li>
  <li>Descrição: Cria um novo usuário no sistema.</li>
  <li>Corpo da Requisição:</li>
</ul>
<pre><code>
{
"nome": "string",
  "email": "string",
  "senha": "string",
  "cep": "string",
  "endereco": "string",
  "bairro": "string",
  "cidade": "string",
  "uf": "string",
  "cpf": "string",
  "dataNascimento": "2024-09-24",
  "imagem": "string"
  }
</code></pre>
<li>Resposta de Sucesso (201 - Created):</li>
<pre><code>
  {
  "id": 8,
  "nome": "Usuário Exemplo",
  "email": "email@exemplo.com",
  "senha": "12345678",
  "cep": "09876543",
  "endereco": "Exemplo",
  "bairro": "Exemplo",
  "cidade": "Exemplo",
  "uf": "SP",
  "cpf": "1234567899",
  "dataNascimento": "2024-09-24",
  "imagem": "Exemplo"
}
</code></pre>
<strong>2. Buscar dados do usuário</strong>
<ul>
  <li>URL: /buscarId/{id}</li>
  <li>Método: GET</li>
  <li>Descrição: Retorna os detalhes de um usuário específico.</li>
  <li>Resposta de Sucesso (200 - OK):</li>
</ul>
<pre><code>
  {
  "id": 8,
  "nome": "Usuário Exemplo",
  "email": "email@exemplo.com",
  "senha": "12345678",
  "cep": "09876543",
  "endereco": "Exemplo",
  "bairro": "Exemplo",
  "cidade": "Exemplo",
  "uf": "SP",
  "cpf": "1234567899",
  "dataNascimento": "2024-09-24",
  "imagem": "Exemplo",
  "produtos": []
}
</code></pre>

<strong>3. Buscar todos os usuários</strong>
<ul>
  <li>URL: /api/Usuario</li>
  <li>Método: GET</li>
  <li>Descrição: Retorna todos os usuários cadastrados no sistema.</li>
  <li>Resposta de Sucesso (200 - OK):</li>
</ul>
<pre><code>
  [{
    "id": 8,
    "nome": "Usuário Exemplo",
    "email": "email@exemplo.com",
    "senha": "12345678",
    "cep": "09876543",
    "endereco": "Exemplo",
    "bairro": "Exemplo",
    "cidade": "Exemplo",
    "uf": "SP",
    "cpf": "1234567899",
    "dataNascimento": "2024-09-24",
    "imagem": "Exemplo",
    "produtos": []
  },
  {
    "id": 9,
    "nome": "Usuário Exemplo",
    "email": "email@teste.com",
    "senha": "",
    "cep": "",
    "endereco": "Exemplo",
    "bairro": "Exemplo",
    "cidade": "Exemplo",
    "uf": "SP",
    "cpf": "1234567899",
    "dataNascimento": "2024-09-24",
    "imagem": "Exemplo",
    "produtos": []
  }
]
</code></pre>

<strong>4. Buscar dados do usuário por email</strong>
<ul>
  <li>URL: /buscarEmail/{email}</li>
  <li>Método: GET</li>
  <li>Descrição: Retorna os detalhes de um usuário específico.</li>
  <li>Resposta de Sucesso (200 - OK):</li>
</ul>
<pre><code>
  {
  "id": 8,
  "nome": "Usuário Exemplo",
  "email": "email@exemplo.com",
  "senha": "12345678",
  "cep": "09876543",
  "endereco": "Exemplo",
  "bairro": "Exemplo",
  "cidade": "Exemplo",
  "uf": "SP",
  "cpf": "1234567899",
  "dataNascimento": "2024-09-24",
  "imagem": "Exemplo",
  "produtos": []
}
</code></pre>

<strong>5. Atualizar dados do usuário</strong>
<ul>
<li>URL: /api/Usuario</li>
<li>Método: PUT</li>
<li>Descrição: Atualiza as informações de um usuário.</li>
<li>Corpo da Requisição:</li>
  <pre><code>
    {
      "id": 0,
      "nome": "string",
      "email": "string",
      "senha": "string",
      "cep": "string",
      "endereco": "string",
      "bairro": "string",
      "cidade": "string",
      "uf": "string",
      "cpf": "string",
      "dataNascimento": "2024-09-24",
      "imagem": "string"
    }
  </code></pre>
  <li>Resposta de Sucesso (200 - OK):</li>
  <pre><code>
    {
      "id": 9,
      "nome": "Usuário Exemplo Atualizado",
      "email": "emailAtualizado@teste.com",
      "senha": "",
      "cep": "",
      "endereco": "Exemplo Atualizado",
      "bairro": "Exemplo Atualizado",
      "cidade": "Exemplo Atualizado",
      "uf": "SP",
      "cpf": "1234567899",
      "dataNascimento": "2024-09-24",
      "imagem": "Exemplo"
    }
  </code></pre>
</ul>

 <strong>6. Excluir usuário</strong>
 <ul>
   <li>URL: /api/Usuario/{id}</li>
   <li>Método: DELETE</li>
   <li>Descrição: Remove um usuário do sistema.</li>
   <li>Resposta de Sucesso (404 - Not Found):</li>
   <pre><code>
     Usuário não encontrado. O usuário foi excluído.
   </code></pre>
 </ul>





<h3>Erros comuns</h3>
<strong>1. 404 - Not Found</strong>
<ul>
<li>Motivo: O recurso solicitado não foi encontrado.</li>
<li>Exemplo de Resposta:</li>
  <pre><code>
    Usuário não encontrado.
  </code></pre>
</ul>

<strong>2. 400 - Bad Request</strong>
<ul>
  <li>Motivo: Já existe um usuário cadastrado com o mesmo email.</li>
  <li>Exemplo de Resposta:</li>
  <pre><code>Usuário já cadastrado.</code></pre>
</ul>

<strong>3. 500 - Internal Server Error</strong>
<ul>
  <li>Motivo: Ocorreu um erro inesperado no servidor.</li>
  <li>Exemplo de Resposta:</li>
  <pre><code>
    {
  "error": "Erro interno do servidor"
}
  </code></pre>
</ul>
  <h2>Tecnologias</h2>
  <ul>
    <li>ASP NET 8</li>
    <li>xUnit para o projeto de teste</li>
    <li>SQL Server</li>
    <li>Postman</li>
    <li>Swagger</li>
  </ul>

  <h2>Como Rodar o Projeto Localmente</h2>

  <h3>Pré-requisitos</h3>
  <ul>
    <li>Ter o .Net 8 instalado;</li>
    <li>Ter de preferência o Visual Studio instalado;</li>
    <li>Ter SQL Server Instalado.</li>
  </ul>

  <h3>Configuração do Ambiente</h3>
  <strong>1. Clone o repositório:</strong>
  <pre><code>
    git clone https://github.com/thamirespereira/Iris-eCom.git
  </code></pre>
  <strong>2. Instale as dependências:</strong>
  <ul>
    <li>NewtonsoftJson</li>
    <li>EntityFrameworkCore</li>
    <li>EntityFrameworkCore.Sql</li>
    <li>EntityFrameworkCore.Tools</li>
    <li>Swashbuckle.AspNetCore</li>
  </ul>

  <h2>Testes da API</h2>
<p>Para garantir a qualidade e a robustez da API, utilizamos uma suíte de testes automatizados. Aqui estão as instruções para executar os testes.</p>

<h3>Configuração do Ambiente de Teste</h3>
<strong>1. Clone o repositório:</strong>
  <pre><code>
    git clone https://github.com/thamirespereira/Iris-eCom.git
  </code></pre>
  <strong>2. Instale as dependências:</strong>
  <ul>
    <li>Moq</li>
    <li>RestSharp</li>
  </ul>
  <strong>3. Execute os testes</strong>
  <li>Utilize o gerenciador de testes do Visual Studio para executar os testes.</li>
</div>
