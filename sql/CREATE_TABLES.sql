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
