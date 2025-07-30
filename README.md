# 🎮 GameHub – API de Locadora de Jogos

GameHub é uma API RESTful desenvolvida em **.NET 9**, projetada para gerenciar o catálogo e as locações de jogos em uma locadora.  
O projeto segue os princípios de **Clean Architecture**, buscando uma separação clara de responsabilidades, aplicação de boas práticas de DDD e uso de padrões modernos de desenvolvimento backend.

## 📌 Objetivo

O objetivo deste projeto é servir como base de estudo e prática para o desenvolvimento de APIs em .NET utilizando:
- Clean Architecture (Domain, Application, Infrastructure, WebApi)
- Entity Framework Core para persistência de dados
- DTOs para transporte de informações entre camadas
- Unit of Work para consistência transacional

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

## 🚀 Funcionalidades Atuais

- Cadastro e listagem de jogos
- Controle básico de estoque
- Cadastro de clientes

## 📜 Licença

Projeto de uso livre para fins de estudo e prática.
