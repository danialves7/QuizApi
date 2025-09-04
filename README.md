# 🎯 Quiz API (C# .NET 8 Minimal API)

Uma API de Quiz desenvolvida em **C# com .NET 8 Minimal API**, utilizando **Entity Framework Core (InMemory)** para persistência e **Swagger** para documentação interativa.  
---

## ⚙️ Tecnologias

- [.NET 8](https://dotnet.microsoft.com/)  
- [Entity Framework Core InMemory](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/)  
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)  
---

## 🚀 Como rodar o projeto

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Clonar o repositório

git clone https://github.com/seu-usuario/QuizApi.git
cd QuizApi
Restaurar pacotes
dotnet restore
Rodar a aplicação


dotnet run
A API ficará disponível em:

https://localhost:7165/swagger

📌 Endpoints principais
Perguntas locais (InMemory)
GET /questions → lista todas as perguntas

GET /questions/{id} → busca uma pergunta específica

POST /questions → adiciona uma nova pergunta

PUT /questions/{id} → atualiza uma pergunta existente

DELETE /questions/{id} → remove uma pergunta

POST /questions/{id}/answer?answer=1 → verifica se a resposta está correta


🧪 Exemplo de payload para criar pergunta (POST /questions)
json

{
  "text": "Qual a capital da França?",
  "options": ["Paris", "Roma", "Londres", "Berlim"],
  "correctAnswer": 0
}
📖 Aprendizados
Este projeto foi feito para praticar:

Criação de Minimal API em .NET

Integração com banco InMemory usando EF Core

Documentação com Swagger


📌 Próximos passos
 Criar autenticação simples (JWT)

 Adicionar banco de dados real (SQL Server ou PostgreSQL)

 Melhorar validações dos endpoints

 Deploy em nuvem (Azure / Render / Railway)
