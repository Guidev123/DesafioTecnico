<h1>Technical Test Results 🏅</h1>
<p>This is the result of the technical test for the selection process, which required the following tasks 📝</p>
<ol>
    <li>
        <p>Two tables in SQL Server </p>
        <ul>
            <li><strong>Clients:</strong> Must contain the columns ClienteId (INT, PK), Nome (VARCHAR(100)), Email (VARCHAR(100)).</li> 
            <li><strong>Orders:</strong> Must contain the columns PedidoId (INT, PK), ClienteId (INT, FK to the Clients table), DataPedido (DATETIME), ValorTotal (DECIMAL).</li>
        </ul>
    </li>
    <li>Create a .NET Core project using C# that connects to the SQL Server database </li>
    <li>Create a service that inserts a client and an associated order in a transaction </li>
    <li>A service that implements the logic for inserting a client and an order in a transaction </li>
    <li>An API controller that receives the client and order data and calls the service to perform the insertion </li>
</ol>
<h2>Additional Implementations ✅</h2>
<p>In addition to the previous requirements, some new features and Design Patterns were implemented for the scalability of the project</p>
<ol>
    <li>Entity validation with FluentValidation. </li>
    <li>Mapping of entities to DTOs using AutoMapper. </li>
    <li>Event usage for error notification. </li>
    <li>Commit and rollback with UnitOfWork. </li>
    <li>Repository Design Pattern. </li>
    <li>Separation into business layers. </li>
    <li>CRUD operations for orders and clients. </li>
    <li>Response standardization. </li>
</ol>
        
<h1>API Demonstration Video 💻</h1>

<p><a href="https://www.youtube.com/watch?v=87--sOey8ZI">Watch the demo here</a></p>
        
<h2>API Endpoints 🔍</h2>
        
<h3>Clients</h3>
<ul>
    <li>GET <code>/api/clients</code>: Retrieves all clients</li>
    <li>POST <code>/api/clients</code>: Creates a client</li>
    <li>GET <code>/api/clients/{id}</code>: Retrieves a client by ClienteId</li>
    <li>PUT <code>/api/clients/{id}</code>: Updates a client's information based on a ClienteId</li>
    <li>DELETE <code>/api/clients/{id}</code>: Deletes a client by ClienteId</li>
    <li>POST <code>/api/clients/create-client-order</code>: Creates a client and associated orders in the same operation</li>
</ul>

<h3>Orders</h3>
<ul>
    <li>GET <code>/api/orders</code>: Retrieves all orders</li>
    <li>POST <code>/api/orders</code>: Creates an order associated with a ClienteId</li>
    <li>GET <code>/api/orders/get-client-orders/{id}</code>: Retrieves all orders for a client based on a ClienteId</li>
    <li>PUT <code>/api/orders/{id}</code>: Edits an order based on a PedidoId</li>
    <li>DELETE <code>/api/orders/{id}</code>: Deletes an order based on a PedidoId</li>
</ul>
        
<h2>Technologies Used 🛠️</h2>
<ul>
    <li>.NET Core </li>
    <li>ASP.NET </li>
    <li>SQL Server </li>
</ul>
        
<h2>Packages 💼</h2>
<ul>
    <li>FluentValidation </li>
    <li>AutoMapper </li>
</ul>
        
<h2>Principles and Design Patterns 📖</h2>
<ul>
    <li>Implementation of Repository and UnitOfWork </li>
    <li>Utilization of coding principles such as Domain Driven Design, SOLID, and Clean Code </li>
</ul>
        
<h2>Architecture ✏️</h2>
<p>The project is divided into three layers:</p>
<ul>
    <li><strong>Presentation:</strong> Contains controllers, DTOs, database ConnectionString, middlewares, and other API configurations. </li>
    <li><strong>Business:</strong> Includes entities and their validations, services, notifications (events), and interfaces. </li>
    <li><strong>Data:</strong> Contains repositories and the configuration of DbContext. </li>
</ul>

<img src="https://github.com/Guidev123/DesafioTecnico/assets/155389912/fd86e69b-41fd-489c-9bb4-5643fb19d702" alt="Architecture Diagram">

<br>
<br>
<br>

<h2>Table Creation Script</h2>
<p>The scripts for creating the tables and the database have been added to the <code>sql</code> folder.</p>

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
