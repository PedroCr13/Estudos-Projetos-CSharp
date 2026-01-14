![.NET](https://img.shields.io/badge/.NET-8.0-blue?logo=dotnet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-blueviolet?logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-Core-green?logo=ef)
![MySQL](https://img.shields.io/badge/MySQL-8.0-orange?logo=mysql)
![Swagger](https://img.shields.io/badge/Swagger-OpenAPI-brightgreen?logo=swagger)
![License](https://img.shields.io/badge/License-MIT-yellow)

# 📚 Biblioteca.Api

API REST em desenvolvimento em **ASP.NET Core 8**, implementando um **CRUD para gerenciamento de uma biblioteca**, utilizando **Entity Framework Core** e **MySQL**.

Projeto com foco em aprendizado prático, organização em camadas e boas práticas no desenvolvimento de APIs.

---

## 🚀 Funcionalidades

- Cadastro, consulta, listagem, atualização e remoção de **Livros**
- Cadastro, consulta, listagem, atualização e remoção de **Editoras**
- Cadastro e consulta de **Autores**
- Validações de dados
- Documentação automática com Swagger

---

## 🏗️ Organização do Projeto

A aplicação foi organizada seguindo boas práticas de separação de responsabilidades:

```
Biblioteca.Api
│
├── Controllers
│   ├── AutorController.cs
│   ├── EditoraController.cs
│   └── LivrosController.cs
│
├── DTOs
│   ├── AutorDTO.cs
│   ├── EditoraDTO.cs
│   └── LivroDTO.cs
│
├── Service
│   ├── AutorService.cs
│   ├── EditoraService.cs
│   └── LivrosService.cs
│
├── Validators
│   ├── AutorDtoValidator.cs
│   ├── EditoraDtoValidator.cs
│   └── LivroDtoValidator.cs
│
├── Mappers
│   ├── AutorMapper.cs
│   ├── EditoraMapper.cs
│   └── LivroMapper.cs
│
├── Models
│   ├── Entities
│   ├── Mappings
│   └── Context
│
├── Common
│   └── ErrorResponse.cs
│
├── appsettings.json
└── Program.cs
```

---

## 🔗 Endpoints

### Autores
| Método | Rota       | Descrição              |
|--------|------------|------------------------|
| GET    | /api/autor | Lista todos os autores |
| POST   | /api/autor | Cadastra um novo autor |

### Editoras
| Método | Rota              | Descrição              |
|------  |-------------------|------------------------|
| GET    | /api/editora      | Lista todas as editoras|
| GET    | /api/editora/{id} | Consulta editora por ID|
| POST   | /api/editora      | Cadastra uma editora   |
| PUT    | /api/editora/{id} | Atualiza dados editora |
| DELETE | /api/editora/{id} | Remove uma editora     |

### Livros
| Método | Rota              | Descrição              |
|--------|-------------------|------------------------|
| GET    | /api/livros       | Lista todos os livros  |
| GET    | /api/livros/{id}  | Consulta livro por ID  |
| POST   | /api/livros       | Cadastra um novo livro |
| PUT    | /api/livros/{id}  | Atualiza dados do livro|
| DELETE | /api/livros/{id}  | Remove um livro        |

---

### 📄 Documentação Swagger

A API possui documentação interativa gerada automaticamente via Swagger,
onde é possível visualizar e testar todos os endpoints disponíveis.

<p align="center">
  <img src="Screenshot/swagger-api.png" alt="Swagger - Endpoints da API Biblioteca" width="450">
</p>

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Fluent API
- Pomelo.EntityFrameworkCore.MySql
- MySQL 8
- Swagger / OpenAPI

---

## 📋 Pré-requisitos

- .NET SDK 8
- MySQL 8 ou superior
- Visual Studio ou VS Code

---

## ▶️ Como Executar o Projeto

1. Clone o repositório:
```bash
git clone https://github.com/PedroCr13/Estudos-Projetos-CSharp.git
```

2. Acesse a pasta do projeto:
```bash
cd Estudos-Projetos-CSharp/Biblioteca.Api
```

3. Configure a string de conexão no `appsettings.json`.

4. Execute o projeto:
```bash
dotnet run
```

5. Acesse a documentação Swagger pelo navegador.

---

## ⭐ Contribuição

Se este projeto te ajudou ou serviu como referência, considere deixar uma ⭐ no repositório.
Sugestões e melhorias são sempre bem-vindas!
