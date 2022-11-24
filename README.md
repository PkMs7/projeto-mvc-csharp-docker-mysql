# Passo a passo para criação de um projeto MVC com C#

## Requisitos

- Ter instalado em sua máquina um editor de código (VSCode ou Visual Studio Code)
- Ter instalado em sua máquina o pacote de desenvolvimento <a href="https://dotnet.microsoft.com/en-us/download" target="_blank">.NET</a>
- Ter instalado em sua máquina um banco de dados (SQL Server, PostgreSQL, MySQL)
- **Obs.:** Usados nesse projeto:
  - <a href="https://code.visualstudio.com/download" target="_blank">VSCode</a>
  - <a href="https://www.microsoft.com/pt-br/sql-server/sql-server-downloads" target="_blank">SQL Sever</a>

## Preparando ambiente de trabalho

- **Passo 1:** Inicie o projeto no seu terminal (CLI) com o comando `dotnet new mvc`
- **Passo 2:** Para visualizar o projeto em seu navegador, use o seguinte comando `dotnet watch run`
- **Passo 3:** Inicie o Entity Framework no seu projeto com o comando `dotnet add package Microsoft.EntityFrameworkCore.{seuservidor}`
- **Obs.:** No **Passo 3** um ponto a ser observado: Se você não tem instalado o Entity Framework, instale na sua máquina com o comando `dotnet tool install --global dotnet-ef` (mais sobre como configurar <a href="https://github.com/PkMs7/introducao-API-dotnetCSharp" target="_blank">clique aqui</a>)
- **Passo 4:** Inicie também o pacote Design do Entity Framework `dotnet add package Microsoft.EntityFrameworkCore.Design`


## Preparando o banco de dados

- **Passo 1:** Crie suas models na pasta model de acordo com os dados que você usará no DataBase(DB).
- **Passo 2:** Crie sua pasta Context, onde ficarão seus códigos construtores do DB
- **Passo 3:** No arquivo _appsettings.Development.json_ configure o comando para iniciar suas migrations: 
    ```
    "ConnectionStrings": {
        "ConexaoPadrao": "Server=localhost\\sqlexpress; Initial Catalog={seucontext}Mvc; Integrated Security=True"
    }        
    ```
- **Passo 4:** No arquivo _Program.cs_ abaixo do comentário _Add services to the container._ configure o seguinte comando:
    ```
    builder.Services.AddDbContext<{seucontext}>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
    ```
- **Passo 5:** Crie agora suas migrations de acordo com a model que você criou. Use o comando `dotnet ef migrations add {nomeDaMigration}`
- **Passo 6:** Com a pasta migration criada agora crie os dados no seu DB com o seguinte comando `dotnet ef database update`

## Resumo da programação

- **Passo 1:** Crie sua **CONTROLLER** da página a ser exibida
- **Passo 2:** Crie sua **VIEW** da página a ser exibida, na qual você referenciou sua controller
- **Passo 3:** Repetir os passos acima de acordo com o CRUD necessário para cada página
- **Obs.:** Cada página a ser criada é feita com uma pasta separada, onde tudo ali será referenciado com sua devida controller