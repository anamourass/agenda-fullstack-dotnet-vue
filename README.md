Full Stack Agenda: .NET 10 & Vue.js 3
Este projeto é uma aplicação completa de gerenciamento de contatos, desenvolvida para demonstrar a integração entre um ecossistema robusto de Backend (C#) e uma interface reativa e componentizada no Frontend (Vue.js).

Tecnologias e Frameworks Utilizados
Backend (C# / .NET 10)
Optei por uma arquitetura em camadas para garantir a separação de responsabilidades e facilidade de manutenção:

ASP.NET Core Web API: Estrutura principal da aplicação.

Entity Framework Core: Utilizado para a persistência de dados (Configurado com In-Memory Database para facilitar a execução imediata).

AutoMapper: Implementado para realizar o mapeamento inteligente entre Entidades de domínio e DTOs (Data Transfer Objects), evitando exposição desnecessária de dados.

FluentValidation: Biblioteca utilizada para isolar as regras de validação de entrada, garantindo que apenas dados íntegros cheguem à camada de serviço.

Injeção de Dependência (DI): Utilizada nativamente para desacoplar as classes (Interfaces, Repositories e Services).

Swagger (OpenAPI): Documentação interativa da API para testes rápidos de endpoints.

Qualidade e Testes
xUnit: Framework de testes unitários para validar a lógica de negócio.

Moq: Biblioteca de "Mocking" utilizada para isolar as dependências nos testes, garantindo que o comportamento do Service seja testado de forma pura.

Frontend (Vue.js 3)
Desenvolvido com foco em Componentização Reutilizável:

Vue 3 (Composition API): Utilizando ref e onMounted para gerenciamento de estado e ciclo de vida.

Axios: Cliente HTTP para comunicação assíncrona com a API .NET.

Componentes Customizados: Criação do ContatoCard.vue, separando a lógica de exibição da lógica de listagem principal.

🏗️ Padrões de Projeto Aplicados
Repository Pattern: Para abstrair a lógica de acesso a dados.

Service Layer: Onde reside toda a regra de negócio e validações.

DTO Pattern: Para transferência de dados segura entre as camadas.

Clean Code: Código organizado em pastas específicas (Interfaces, Mappings, Validators, DTOs).

🚀 Como Executar o Projeto
1. Backend
Bash
cd AgendaApiNova
dotnet restore
dotnet run
A API estará disponível em: http://localhost:5196/swagger

2. Frontend
Bash
cd agenda-vue
npm install
npm run dev
O site estará disponível em: http://localhost:5173

3. Testes
Bash
cd AgendaApiNova.Tests
dotnet test
👤 Desenvolvedora
Ana Carolina Moura
Analista e Desenvolvedora de Sistemas | Java & .NET Full Stack
Desenvolvido por **Ana Carolina Moura** ✨
