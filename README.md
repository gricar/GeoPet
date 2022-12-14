# 🐾 Bem-vindo ao Geo Pet 🐕‍🦺!

### Descrição
> É uma aplicação com o propósito de proporcionar maior **segurança** para as mães e pais de pet, oferecendo um sensor de **geolocalização** acoplado à coleira do animal, transmitindo sua localização em tempo real.

<details>
  <summary><strong>Principais funcionalidades ✨</strong></summary>

  > As principais responsabilidade desta API estão relacionadas a integração com outras APIs externas de geolocalização e o banco de dados, seguindo os princípios do REST, com as requisições feitas baseadas nos *endpoints*:
  
  <h4>Pessoa cuidadora dos pets</h4>
  
  | Método | Caminho | Responsabilidade |
  |---|---|---|
  | POST | `/login` | Realizar *login* na aplicação para gerar o token de autenticação |
  | POST | `/api/sitters` | Criar nova pessoa cuidadora |
  | GET | `/api/sitters` | Listar todas pessoas cuidadoras cadastrados na aplicação |
  | GET | `/api/sitters/:id` | Listar a pessoa cuidadora e os pets sob sua responsabilidade |
  | PUT | `/api/sitters/:id` | Editar as propriedades da pessoa cuidadora |
  | DELETE | `/api/sitters/:id` | Remover a pessoa cuidadora cadastrada na aplicação |
  
  <hr>
  
  <h4>Pets</h4>
  
  | Método | Caminho | Responsabilidade |
  |---|---|---|
  | POST | `/api/pets` | Cadastrar novo pet com a responsabilidade de uma pessoa cuidadora |
  | GET | `/api/pets` | Listar todos pets cadastradas na aplicação |
  | GET | `/api/pets/:id` | Listar o pet e a pessoa cuidadora responsável |
  | GET | `/api/pets/:id/qrcode` | Retornar um QRCode com as informações do pet |
  | POST | `/api/pets/:id/location` | Retornar a localização do pet de acordo com as coordenadas geográficas enviadas |
  | PUT | `/api/pets/:id` | Editar as informações do pet |
  | DELETE | `/api/pets/:id` | Remover o pet cadastrado na aplicação |
  
  <hr>
  
   <h4>Address</h4>
  
  | Método | Caminho | Responsabilidade |
  |---|---|---|
  | POST | `/api/addresses` | Cadastrar novo endereço de uma pessoa cuidadora |
  | GET | `/api/addresses/:id` | Listar o endereço da pessoa cuidadora |
  | PUT | `/api/addresses/:id` | Editar as propriedades do endereço |
  | DELETE | `/api/addresses/:id` | Remover o endereço cadastrado na aplicação |
    
</details>

<details>
  <summary><strong>Tecnologias utilizadas 👨‍💻</strong></summary>

  - [`C#`](https://learn.microsoft.com/pt-br/dotnet/csharp/)
  - [`ASP.NET Core`](https://learn.microsoft.com/pt-br/aspnet/core/)
  - [`Entity Framework Core`](https://learn.microsoft.com/pt-br/ef/core/)
  - [`Docker`](https://www.docker.com/)
  - [`SQL Server`](https://www.microsoft.com/pt-br/sql-server/)
  - [`Azure`](https://azure.microsoft.com/pt-br/)
  - [`jwt`](https://jwt.io/)
</details>

<details>
  <summary><strong>Executando o projeto 🌐</strong></summary>

  - É necessário ter o `Docker` e o [`Docker Compose`](https://docs.docker.com/compose) instalado em sua máquina.

  - Clone o projeto: `git clone git@github.com:gricar/GeoPet.git`.

  - Entre na pasta do projeto: `cd GeoPet`.
  
  - Execute o **script** no terminal para iniciar o Docker Compose: `docker-compose up -d --build`.
  
  - Instale as dependências: `dotnet restore`.
  
  - Execute a aplicação: `dotnet run`.

  - Para desligar o container, utilize o script: `docker-compose down`
</details>
