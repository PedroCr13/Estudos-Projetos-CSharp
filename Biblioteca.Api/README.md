# 📚 Biblioteca.Api

![.NET](https://img.shields.io/badge/.NET-8.0-blue?logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-blueviolet?logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-Core-green?logo=ef)
![MySQL](https://img.shields.io/badge/MySQL-8.0-orange?logo=mysql)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-brightgreen?logo=swagger)
![License](https://img.shields.io/badge/License-MIT-yellow)

API REST desenvolvida em ASP.NET Core, um CRUD para gerenciamento de livros em uma biblioteca com Entity Framework Core

---

## Funcionalidades

- Cadastro de livros
- Consulta de livros por ID
- Listagem de todos os livros
- Atualização de dados de um livro
- Remoção de livros

## Organização projeto

Classes organizadas em dietórios: 

- Model 
- Service 
- Controllers
- DTOs
- Mappers

## Endpoints

| Método | Rota               | Descrição                     |
|--------|--------------------|-------------------------------|
| GET    | /api/livros        | Lista todos os livros         |
| GET    | /api/livros/{id}   | Busca um livro por ID         |
| POST   | /api/livros        | Cadastra um novo livro        |
| PUT    | /api/livros/{id}   | Atualiza os dados de um livro |
| DELETE | /api/livros/{id}   | Remove um livro               |

## Tecnologias utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Fluent API (mapeamento do banco de dados)
- Pomelo.EntityFrameworkCore.MySql
- MySQL 8.0.40
- Swagger / OpenAPI

## Como executar o projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/Biblioteca.Api.git