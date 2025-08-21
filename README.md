# 🎮 GameHub – API de Locadora de Jogos

GameHub é uma API RESTful desenvolvida em **.NET 9**, projetada para gerenciar o catálogo e as locações de jogos em uma locadora.  
O projeto segue os princípios de **Clean Architecture**, buscando uma separação clara de responsabilidades, aplicação de boas práticas de DDD e uso de padrões modernos de desenvolvimento backend.

## 📌 Objetivo

O objetivo deste projeto é servir como base de estudo e prática para o desenvolvimento de APIs em .NET utilizando:
- Clean Architecture (Domain, Application, Infrastructure, WebApi)
- Entity Framework Core para persistência de dados
- DTOs para transporte de informações entre camadas
- Unit of Work para consistência transacional

## 📚 Principais Conceitos e Tecnologias

- **Framework**: .NET 9
- **Arquitetura**: Arquitetura Limpa
- **Padrão de Casos de Uso**: CQRS (Command Query Responsability Segregation) com MediatR
- **Tratamento de Resultado**: Implementação de Result Pattern customizado para tratamento de erros e respostas de API padronizadas.
- **Validação de Entrada**: Validação robusta e automatizada com FluentValidation.
- **Acesso a Dados**: Entity Framework Core 9 com abordagem "Code First".
- **Padrões de Persistência**: Repositório (Repository Pattern) e Unidade de Trabalho (Unit of Work) para abstrair a lógica de acesso a dados.
- **Paginação de Dados**: Sistema de paginação com um DTO PagedResult<T>.
- **Injeção de Dependência**: Configuração limpa e centralizada por camada.
- **API**: API RESTful construída com ASP.NET Core Controllers.

## 📂 Estrutura do Projeto

```
GameHub/
├── src/
│   ├── GameHub.Domain/           # Entidades, Enums, Interfaces de Repositórios
│   ├── GameHub.Application/      # Casos de uso, DTOs, Mappers, Serviços
│   ├── GameHub.Infrastructure/   # Implementações de repositórios, DbContext, Migrations
│   └── GameHub.WebApi/           # Endpoints da API, Controllers, Configurações
└── tests/
    ├── GameHub.UnitTests/        # Testes unitários
    └── GameHub.IntegrationTests/ # Testes de integração
```

## 🚀Endpoints da API


```GET``` ```/api/games```: Retorna uma lista paginada de todos os jogos.

```GET```	```/api/games/{id}```:	Retorna um jogo específico pelo seu ID.

```GET```	```/api/games/active```:	Retorna uma lista paginada de jogos ativos.

```GET```	```/api/games/inactive```:	Retorna uma lista paginada de jogos inativos.

```GET```	```/api/games/AgeRating/{ageRating}```:	Filtra e retorna jogos por classificação etária.

```GET```	```/api/games/Genre/{genre}```:	Filtra e retorna jogos por gênero.

```GET```	```/api/games/Platform/{platform}```:	Filtra e retorna jogos por plataforma.

```POST```	```/api/games```:	Cria um novo jogo no catálogo.

```PUT```	```/api/games/{id}```:	Atualiza todas as informações de um jogo existente.

```DELETE```	```/api/games/{id}```:	Deleta um jogo do catálogo.

```PUT```	```/api/games/{id}/activate```:	Ativa um jogo, tornando-o disponível para aluguel.

```PUT```	```/api/games/{id}/deactivate```:	Desativa um jogo.

```PUT```	```/api/games/{id}/addstock```:	Adiciona uma quantidade ao estoque de um jogo.

```PUT```	```/api/games/{id}/removestock```:	Remove uma quantidade do estoque de um jogo.

## Como Executar o Projeto

### 📌 Pré-requisitos
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)  
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (LocalDB, Express ou outra instância)

---

### ⚙️ Passo a Passo

1. **Clone o repositório**
   ```bash
   git clone https://github.com/gusropdev/ProjetoGameHub.git
   cd ProjetoGameHub 
   
2. **Configure a Connection String**

    - Abra o arquivo src/GameHub.WebApi/appsettings.Development.json

    - Altere a propriedade DefaultConnection para apontar para a sua instância do SQL Server

3. **Aplique as Migrações do Banco de Dados**
    Navegue até a pasta raiz da solução (onde está o arquivo .sln) e execute:

    ```bash
    dotnet ef database update --project src/GameHub.Infrastructure --startup-project src/GameHub.WebApi

4. **Execute a Aplicação**
    - Acesse a pasta da API:
        ```bash
        cd src/GameHub.WebApi
    - Rode o comando:
        ```bash
         dotnet run

### 🌐 Acessando a API

- API disponível em: https://localhost:PORTA

- Documentação Swagger: https://localhost:PORTA/swagger

## 🔨 Próximos Passos
[ ] Implementar sistema de autenticação e autorização com JWT.

[ ] Concluir o CRUD para as entidades User e Rental.

[ ] Adicionar testes de unidade e integração.

## 📜 Licença

Projeto de uso livre para fins de estudo e prática.



