<h1>Resultado do Teste Técnico 🏅</h1>
        <p>Este é o resultado do teste técnico para o processo seletivo no qual era preciso realizar 📝</p>
        <ol>
            <li>
                <p>Duas tabelas no SQL Server </p>
                <ul>
                    <li><strong>Clientes:</strong> Deve conter as colunas ClienteId (INT, PK), Nome (VARCHAR(100)), Email (VARCHAR(100)).</li> 
                    <li><strong>Pedidos:</strong> Deve conter as colunas PedidoId (INT, PK), ClienteId (INT, FK para a tabela Clientes), DataPedido (DATETIME), ValorTotal (DECIMAL).</li>
                </ul>
            </li>
            <li>Criar um projeto .NET Core utilizando C# que conecte ao banco de dados SQL Server </li>
            <li>Criar um serviço que insira um cliente e um pedido associado em uma transação </li>
            <li>Um serviço que implementa a lógica de inserção de cliente e pedido em uma transação </li>
            <li>Um controlador API que recebe os dados do cliente e pedido e chama o serviço para realizar a inserção </li>
        </ol>
        <h2>Implementações Adicionais ✅</h2>
        <p>Além das exigências anteriores, também foram implementadas algumas novas features e Design Patterns para escalabilidade do projeto</p>
        <ol>
            <li>Validações de entidades com FluentValidation. </li>
            <li>Mapeamento das entidades para DTOs utilizando o AutoMapper. </li>
            <li>Utilização de evento para notificar erros. </li>
            <li>Commit e rollback com UnitOfWork. </li>
            <li>Design Pattern de Repository. </li>
            <li>Divisão em camadas de negócio. </li>
            <li>Operações de CRUD de pedidos e clientes. </li>
            <li>Padronização de responses. </li>
        </ol>
        
<h1>Video demonstração da API 💻</h1>

https://www.youtube.com/watch?v=87--sOey8ZI
        
<h2>Endpoints da API 🔍</h2>
        
<h3>Clientes</h3>
        <ul>
            <li>GET <code>/api/clientes</code>: Obtém todos os clientes</li>
            <li>POST <code>/api/clientes</code>: Cria um cliente</li>
            <li>GET <code>/api/clientes/{id}</code>: Obtém um cliente por ClienteId</li>
            <li>PUT <code>/api/clientes/{id}</code>: Atualiza as informações de um cliente com base em um ClienteId</li>
            <li>DELETE <code>/api/clientes/{id}</code>: Exclui um cliente por ClienteId</li>
            <li>POST <code>/api/clientes/criar-cliente-pedido</code>: Cria um cliente e pedidos associados a ele na mesma operação</li>
        </ul>

<h3>Pedidos</h3>
        <ul>
            <li>GET <code>/api/pedidos</code>: Obtém todos os pedidos</li>
            <li>POST <code>/api/pedidos</code>: Cria um pedido associado a um ClienteId</li>
            <li>GET <code>/api/pedidos/obter-pedidos-cliente/{id}</code>: Obtém todos os pedidos de um cliente com base em um ClienteId</li>
            <li>PUT <code>/api/pedidos/{id}</code>: Edita um pedido com base em um PedidoId</li>
            <li>DELETE <code>/api/pedidos/{id}</code>: Exclui um pedido com base em um PedidoId</li>
        </ul>
        
  <h2>Tecnologias Utilizadas 🛠️</h2>
        <ul>
            <li>.NET Core </li>
            <li>ASP.NET </li>
            <li>SQL Server </li>
        </ul>
        
   <h2>Pacotes 💼</h2>
        <ul>
            <li>FluentValidation </li>
            <li>Automapper </li>
        </ul>
        
  <h2>Princípios e Design Patterns 📖</h2>
        <ul>
            <li>Implementação de Repository e UnitOfWork </li>
            <li>SOLID e Clean Code </li>
        </ul>
        
  <h2>Arquitetura ✏️</h2>
        <p>O projeto está dividido em três camadas :</p>
        <ul>
            <li><strong>Apresentação:</strong> Contém as controllers, DTOs, ConnectionString do banco de dados, middlewares e outras configurações da API. </li>
            <li><strong>Business:</strong> Inclui as entidades e suas validações, services, notificações (eventos) e interfaces. </li>
            <li><strong>Data:</strong> Contém os repositórios e a configuração do DbContext. </li>
        </ul>
        

![arch](https://github.com/Guidev123/DesafioTecnico/assets/155389912/fd86e69b-41fd-489c-9bb4-5643fb19d702)


<br>
<br>
<br>
   
  </div>
<h2>Script de Criação das Tabelas</h2>
<p>Os scripts de criação das tabelas e do banco foram adicionados na pasta <code>sql</code>.</p>

<pre><code>
USE desafiodev
GO
DROP TABLE IF EXISTS Pedidos
GO
DROP TABLE IF EXISTS Clientes
GO
CREATE TABLE Clientes (
    ClienteId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
);

GO
GRANT ALL ON Clientes TO PUBLIC
GO

CREATE TABLE Pedidos (
    PedidoId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ClienteId INT NOT NULL,
    DataPedido DATETIME NOT NULL,
    ValorTotal DECIMAL(18,2) NOT NULL,
	FOREIGN KEY (ClienteId) REFERENCES Clientes(ClienteId)
);
GO
GRANT ALL ON Pedidos TO PUBLIC
        </code></pre>
 <h2>Script de Criação do Banco </h2>
         <pre><code>
           USE [master]
GO

/****** Object:  Database [desafiodev]    Script Date: 04/07/2024 18:49:49 ******/

CREATE DATABASE [desafiodev]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'desafiodev', FILENAME = N'C:\Users\guira\desafiodev.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'desafiodev_log', FILENAME = N'C:\Users\guira\desafiodev_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [desafiodev].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [desafiodev] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [desafiodev] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [desafiodev] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [desafiodev] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [desafiodev] SET ARITHABORT OFF 
GO

ALTER DATABASE [desafiodev] SET AUTO_CLOSE ON 
GO

ALTER DATABASE [desafiodev] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [desafiodev] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [desafiodev] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [desafiodev] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [desafiodev] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [desafiodev] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [desafiodev] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [desafiodev] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [desafiodev] SET  ENABLE_BROKER 
GO

ALTER DATABASE [desafiodev] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [desafiodev] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [desafiodev] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [desafiodev] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [desafiodev] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [desafiodev] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [desafiodev] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [desafiodev] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [desafiodev] SET  MULTI_USER 
GO

ALTER DATABASE [desafiodev] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [desafiodev] SET DB_CHAINING OFF 
GO

ALTER DATABASE [desafiodev] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [desafiodev] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [desafiodev] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [desafiodev] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [desafiodev] SET QUERY_STORE = OFF
GO

ALTER DATABASE [desafiodev] SET  READ_WRITE 
GO

   </code></pre>
