# Introducão 

Bem vindo ao projeto da API do Senai MinhaVoz, uma apliação desenvolvida para dar voz aos estudantes da Instituição Senai Informática.  

# Vamos Começar

Requisitos para verificar o funcionamento da API
    - SQL Server 2016 ou superior
    - Microsoft sql server management studio (MSSM) 2017 ou superior
    - Visual Studio Code 2015 ou superior
    - Postman versão 7.3.5 ou superior


# Repositórios


# Criação do Banco de Dados

 Para criar o banco de dados é necessário ter instalado o SQL Server,  Microsoft SQL Server Management Studio e os arquivos contidos na pasta "s Banco de Dados" (disponível no repositório do GitHub)
 Execute os scrits na seguinte ordem:

1. CRIACAO
2. INSERCAO
3. SELECAO

# Configuração do Ambiente de desenvolvimento
A API foi desenvolvida com a IDE Visual Studio Code, com as seguintes pacotes instalados:

1. Microsoft.AspNetCore.App versão 2.1.1
2. Microsoft.EntityFrameworkCore versão 2.1.1
3. Microsoft.EntityFrameworkCore.Design versão 2.1.1
4. Microsoft.EntityFrameworkCore.SqlServer versão 2.1.1
5. Microsoft.EntityFrameworkCore.Tools versão 2.1.1
6. Microsoft.NETCore.App versão 2.1.0
7. Swashbuckle.AspNetCore 4.0.1

# Login
  A única área do sistema com acesso restrito é o Painel do Administrador.
  Por padrão o email do administrador é  **admin@admin.com** e a senha "**12345**" sem as aspas
  O login é feito com uma requisição HTTP POST que enviará um objeto no formato json, como no exemplo a seguir:
  
  [http://localhost:5000/api/Login](http://localhost:5000/api/Login)
  Tipo de Requisição: HTTP POST
  Autenticação: Não Necessária
  
 Entrada
{
  "email": "admin@admin.com",
  "senha": "12345"
}

Caso a requisição tenha sucesso, retornará um token JWT, como no exemplo abaixo

{
    "token": "eyJJc3RvIMOpIGFwZW5hcyB1bSB0ZXN0ZSI6IlRlc3RlIiwiYWxnIjoiSFMyNTYifQ.eyJJc3RvIMOpIGFwZW5hcyB1bSB0ZXN0ZSI6IlRlc3RlIn0._q0cQb5Re0UW_6z97yQuopctrr2pqLT-3ZqkigkbR9o"
}

# Cadastrar Chamados

O cadastro de chamados é feito com uma requisição do tipo POST, não há necessidade do usuário estar logado.

  [http://localhost:5000/cadastrar](http://localhost:5000/api/cadastrar)
  Tipo de Requisição: HTTP POST
  Autenticação: Não Necessária
  
  Entrada, os seguintes parâmetros devem ser passados.
  
  
  { 
  	    "nome": "NomeDoAluno",
        "email": "emailDoAluno@email.com",
        "telefone": "+55111111111111",
        "titulo": "Horário da Biblioteca"
        "assunto": "Biblioteca",
        "descricao": "Gostaria que o horário de funcionamento da biblioteca fosse ampliado",
        "data": "2019-05-08T00:00:00"
    }
    
Estando todos os dados corretos, retornará Status 200 OK.

# Listagem de chamados

A listagem de todos os chamados é uma operação possível somente ao administrador do sistema, logo a autenticação é necessária, é uma requisição do tipo HTPP GET
    
    
  [http://localhost:5000/listar](http://localhost:5000/api/listar)
  Tipo de Requisição: HTTP GET
  Autenticação: Necessária
  
  O retorno será um JSON com todas os chamados que foram cadastrados, como no exemplo a seguir.
  
  [
    {
        "id": 1,
        "nome": "Usuario Teste",
        "email": "teste@teste.com",
        "telefone": "+55(11)9872483773",
        "titulo": "Titulo Teste",
        "assunto": "Assunto Teste",
        "descricao": "Descricao Teste",
        "status": "Pendente",
        "data": "2019-05-08T00:00:00"
    },
    {
        "id": 3,
        "nome": "Usuario Teste2",
        "email": "teste@teste.com2",
        "telefone": "+55(11)98724837732",
        "titulo": "Titulo Teste2",
        "assunto": "Assunto Teste2",
        "descricao": "Descricao Teste2",
        "status": "Pendente",
        "data": "2019-05-08T00:00:00"
    },
    {
        "id": 4,
        "nome": "Usuario Teste3",
        "email": "teste@teste.com3",
        "telefone": "+55(11)98724837739",
        "titulo": "Titulo Teste2",
        "assunto": "Assunto Teste3",
        "descricao": "Descricao Teste3",
        "status": "Pendente",
        "data": "2019-05-08T00:00:00"
    }
]


# Contribuições
Esta API foi desenvolvida por Guilherme Moreno e Renato Nogueira

