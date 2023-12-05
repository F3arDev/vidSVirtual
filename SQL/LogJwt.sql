--Log de Auth Jwt Token y Jwt Refresh
CREATE TABLE LogRefreshToken (
    LogRefreshTokenID INT PRIMARY KEY IDENTITY,
    UsuarioID INT REFERENCES Usuario(UsuarioID),
    Token VARCHAR(500),
    RefreshToken VARCHAR(200),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    FechaExpiracion DATETIME DEFAULT DATEADD(MINUTE, 2, GETDATE()),
    Estado AS (IIF(FechaExpiracion < GETDATE(), CONVERT(BIT, 0), CONVERT(BIT, 1))),
);
select * from LogRefreshToken

DROP TABLE LogRefreshToken;