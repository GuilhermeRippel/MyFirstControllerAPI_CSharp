# RippelStoreControllerApi

Projeto de estudos de uma API REST simples em **ASP.NET Core (.NET 8)**, usando Controllers para gerenciar uma lista de tarefas.

Os dados ficam armazenados **em memória** (uma lista estática), então são perdidos ao reiniciar a aplicação.

## Tecnologias

- C# / .NET 8
- ASP.NET Core Web API
- Swagger (Swashbuckle)

## Endpoints

| Método | Rota | Descrição |
|---|---|---|
| GET | `/api/Tarefas` | Lista todas as tarefas |
| GET | `/api/Tarefas/{id}` | Busca uma tarefa pelo Id |
| POST | `/api/Tarefas` | Cria uma nova tarefa |
| DELETE | `/api/Tarefas/{id}` | Remove uma tarefa |

Exemplo de corpo para o POST (o Id é gerado automaticamente):

```json
{
  "name": "Estudar C#",
  "description": "Revisar controllers e DTOs"
}
```

## Como executar

```bash
dotnet run
```

Depois acesse o Swagger em `https://localhost:<porta>/swagger` para testar os endpoints.

## Conceitos praticados

- Controllers e roteamento
- Retornos HTTP com `ActionResult<T>` e `IActionResult`
- DTOs para separar a entrada da model
- Consultas com LINQ (`FirstOrDefault`, `Max`)
