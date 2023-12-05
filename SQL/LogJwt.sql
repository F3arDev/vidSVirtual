--Log de Auth Jwt Token y Jwt Refresh

CREATE TABLE LogRefreshToken(
	LogRefreshTokenID int primary key identity,
	UsuarioID int references Usuario(UsuarioID),
	Token varchar (500),
	RefreshToken varchar(200),
	FechaCreacion datetime,
	FechaExpiracion datetime,
	Estado as ( iif(FechaExpiracion < getdate(), convert(bit,0),convert(bit,1)))--Columna Calculada
)

select * from LogRefreshToken


