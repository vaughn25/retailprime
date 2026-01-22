CREATE TABLE [user] (
	[id] INT PRIMARY KEY IDENTITY(1,1),
	[username] NVARCHAR(50) NOT NULL,
	[email] NVARCHAR(100) NOT NULL,
	[created_at] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[last_login] DATETIME2 NULL,
	[first_name] NVARCHAR(50) NULL,
	[last_name] NVARCHAR(50) NULL
);
GO 

INSERT INTO [user] ([username], [email], [first_name], [last_name]) VALUES
('jdoe', 'jdoe@test.com','John', 'Doe'),
('asmith', 'asmith@green.org','Alice', 'Smith'),
('bjones', 'billy@bob.com','Billy', 'Bob');