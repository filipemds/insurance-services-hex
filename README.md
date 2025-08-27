# Insurance Services Hex 🛡️

Este projeto é um **desafio técnico** desenvolvido em **.NET 8** para demonstrar boas práticas de:
- Arquitetura **Hexagonal (Ports & Adapters)**
- **Clean Architecture**, **DDD** e **SOLID**
- Comunicação entre **microserviços via REST**
- Persistência em **PostgreSQL** com **EF Core**
- Testes automatizados (**xUnit + FluentAssertions + NSubstitute**)
- Deploy em **Docker/Docker Compose**

## 📌 Serviços

### PropostaService
- Criar proposta de seguro
- Listar propostas
- Alterar status (Em Análise, Aprovada, Rejeitada)
- Expor API REST (Swagger)

### ContratacaoService
- Contratar proposta (apenas se **Aprovada**)
- Armazenar contratação (PropostaId, DataContratacao)
- Consultar **PropostaService** via REST
- Expor API REST (Swagger)

---

## ⚙️ Tecnologias
- C# / .NET 8
- ASP.NET Core Minimal API
- EF Core + PostgreSQL
- Docker & Docker Compose
- xUnit, FluentAssertions, NSubstitute

---

## ▶️ Como Rodar

### Usando Docker Compose
```bash
docker compose up -d --build
