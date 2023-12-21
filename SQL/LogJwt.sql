--Log de Auth Jwt Token y Jwt Refresh
CREATE TABLE LogRefreshToken (
    LogRefreshTokenID INT PRIMARY KEY IDENTITY,
    UsuarioID INT,
    Token VARCHAR(500),
    RefreshToken VARCHAR(200),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaExpiracion DATETIME DEFAULT DATEADD(MINUTE, 240, GETDATE()),
    Estado AS (IIF(FechaExpiracion < GETDATE(), CONVERT(BIT, 0), CONVERT(BIT, 1))),
	FOREIGN KEY (UsuarioID) REFERENCES Usuario (UsuarioID)
);
select * from LogRefreshToken

--DROP TABLE LogRefreshToken;