
# Hotel Management System

## Descrição
Este é um sistema de gestão hoteleira desenvolvido para ajudar na administração de reservas, gerenciamento de quartos e outros serviços oferecidos por um hotel. Ele foi criado com foco em eficiência e organização, proporcionando uma interface simples para os usuários gerenciarem as operações do hotel. 

Este projeto faz parte do meu portfólio como desenvolvedor, demonstrando minhas habilidades em C# e desenvolvimento de soluções para negócios.

## Funcionalidades (Incluindo as futuras funcionalidades)
- **Gestão de Quartos**: Permite o cadastro, edição e exclusão de quartos.
- **Reservas**: Gerenciamento completo de reservas de clientes.
- **Clientes**: Cadastro de novos clientes, histórico de estadias e dados relevantes para personalização de serviço.
- **Pagamentos**: Sistema para registrar pagamentos e emitir recibos.
- **Integração com Sistema de Contabilidade**: Integração opcional para facilitar o controle financeiro.
- **Relatórios**: Geração de relatórios mensais sobre ocupação de quartos e receita.
  
## Estrutura do Projeto
Este projeto é composto pelos seguintes arquivos principais:

- **App.config**: Arquivo de configuração do aplicativo que define as strings de conexão e outras variáveis.
- **Connection.cs**: Classe responsável por gerenciar a conexão com o banco de dados.
- **Form1.cs**: Arquivo que contém a lógica da interface do usuário para o formulário principal do sistema.
- **Form1.Designer.cs**: Código gerado automaticamente que define a estrutura visual do formulário.
- **Form1.resx**: Arquivo de recursos associados ao formulário.
- **Program.cs**: O ponto de entrada do sistema.

## Pré-requisitos
- .NET Framework ou .NET Core (dependendo da versão utilizada no projeto).
- Visual Studio para abrir e compilar o projeto.
- SQL Server ou outro banco de dados compatível com a string de conexão definida no arquivo **App.config**.

## Como Executar
1. Clone este repositório ou faça o download do código fonte.
2. Abra o arquivo de solução (`Hotel-Management-System.sln`) no Visual Studio.
3. Configure o banco de dados no arquivo `App.config`, atualizando a string de conexão conforme sua instância do banco de dados.
4. Compile o projeto no Visual Studio.
5. Execute o projeto através do Visual Studio ou usando o executável gerado na pasta `bin`.

## Como Contribuir
Se você deseja contribuir com este projeto, sinta-se à vontade para fazer um fork do repositório, criar novas branches para suas alterações, e submeter pull requests.
