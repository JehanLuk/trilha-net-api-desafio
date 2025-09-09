# 📝 Gerenciador de Tarefas API

![.NET](https://img.shields.io/badge/.NET-9-brightgreen)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-blue)
![License](https://img.shields.io/badge/license-MIT-lightgrey)

---

## 1️⃣ Descrição

Este projeto é uma **Web API em .NET 9** utilizando **Entity Framework Core** e **PostgreSQL**.  
Permite gerenciar uma lista de tarefas com **CRUD completo**, ou seja, criar, ler, atualizar e deletar tarefas.

O projeto foi desenvolvido como desafio da **Trilha .NET da DIO**, com foco em boas práticas de API RESTful, migrations e Swagger.

---

## 2️⃣ Funcionalidades

- Criar tarefa (POST `/Tarefa`)
- Obter tarefa por ID (GET `/Tarefa/{id}`)
- Obter todas as tarefas (GET `/Tarefa/ObterTodos`)
- Obter tarefas por título (GET `/Tarefa/ObterPorTitulo?titulo=...`)
- Obter tarefas por data (GET `/Tarefa/ObterPorData?data=YYYY-MM-DD`)
- Obter tarefas por status (GET `/Tarefa/ObterPorStatus?status=Pendente`)
- Atualizar tarefa (PUT `/Tarefa/{id}`)
- Deletar tarefa (DELETE `/Tarefa/{id}`)

---

## 3️⃣ Schema de Tarefa

```json
{
  "id": 0,
  "titulo": "string",
  "descricao": "string",
  "data": "2022-06-08T01:31:07.056Z",
  "status": "Pendente"
}
```

![Diagrama da classe Tarefa](diagrama.png)

## Métodos esperados


**Swagger**


![Métodos Swagger](swagger.png)


**Endpoints**


| Verbo  | Endpoint                | Parâmetro | Body          |
|--------|-------------------------|-----------|---------------|
| GET    | /Tarefa/{id}            | id        | N/A           |
| PUT    | /Tarefa/{id}            | id        | Schema Tarefa |
| DELETE | /Tarefa/{id}            | id        | N/A           |
| GET    | /Tarefa/ObterTodos      | N/A       | N/A           |
| GET    | /Tarefa/ObterPorTitulo  | titulo    | N/A           |
| GET    | /Tarefa/ObterPorData    | data      | N/A           |
| GET    | /Tarefa/ObterPorStatus  | status    | N/A           |
| POST   | /Tarefa                 | N/A       | Schema Tarefa |
