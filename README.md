# User Management API

##Descrição:
Este sistema é uma aplicação web que permite o controle de cadastro de usuários, utilizando uma API gratuita chamada Random User Generator. Os dados dos usuários são armazenados em um banco de dados PostgreSQL. A aplicação segue o padrão de arquitetura limpa em camadas, promovendo uma estrutura organizada e fácil de manter.

##Funcionalidades:
Cadastro de Usuários -> Através da API Random User, é possível gerar informações de usuários aleatórios para cadastro.
Relatório de Usuários -> A aplicação exibe uma tela simples em HTML que apresenta um relatório com os usuários cadastrados.
Armazenamento em Banco de Dados -> Todos os dados são armazenados em um banco de dados PostgreSQL, garantindo persistência e integridade das informações.

##Estrutura do Projeto:
O projeto é organizado em camadas, seguindo o padrão de arquitetura limpa:
Camada de Apresentação -> Responsável pela interface do usuário, onde os dados são exibidos e coletados.
Camada de Aplicação -> Contém a lógica de negócios e as regras de interação com a API e o banco de dados.
Camada de Domínio -> Define as entidades e as regras de negócio fundamentais do sistema.

##Tecnologias Utilizadas:
Linguagem: C#
Framework Web: 
Banco de Dados: PostgreSQL
API: Random User Generator

## Pré-requisitos

Antes de executar a API, certifique-se de ter os seguintes itens instalados em sua máquina:

- **PgAdmin(PostgreSQL)**: Necessário para o banco de dados.

## Instruções de Configuração

Atualizar a connectionString do arquivo appsettings.

cd caminho\Backend\Domain\UM.Domain

dotnet ef database update --startup-project ..\..\Presentation\UM.Presentation\UM.Presentation.csproj

dotnet restore

dotnet build

dotnet run 