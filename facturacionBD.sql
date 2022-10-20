use master 
go

drop database facturacionDB
go

-- Creando la base de datos
create database facturacionDB
go

use facturacionDB
go

-- Creando las tablas de la base
create table usuarios(
	idUsuario int identity(1,1) primary key,
	usuario varchar(20),
	activo binary
)
go

create table tipoCliente(
	idTipoCliente int identity(1,1) primary key,
	tipoCliente varchar(20)
)

create table clientes(
	idCliente int identity(1,1) primary key,
	idUsuario int foreign key references usuarios(idUsuario),
	idTipoCliente int foreign key references tipoCliente(idTipoCliente),
	nombreCliente varchar(50),
	apellidoCliente varchar(50),
	activo binary
)
go

create table bitacoras(
	idBitacora int identity(1,1) primary key,
	idCliente int foreign key references clientes(idCliente),
	descripcion varchar(50),
	numReferencia varchar(60),
	fechaCreacion date,
	fechaVerificada date,
	horaVerificada time,
	montoTotal money,
	completada binary
)
go

create table tipoProceso(
	idTipoProceso int identity(1,1) primary key,
	tipoProceso varchar(20)
)	
go

create table facturas(
	idFactura int identity(1,1) primary key,
	idTipoProceso int foreign key references tipoProceso(idTipoProceso),
	idBitacora int foreign key references bitacoras(idBitacora),
	concepto varchar(50),
	fechaFactura date,
	valor money
)
go

-- Creando valores por defecto
insert into tipoCliente
values ('Personas'),('Empresas')
go

insert into tipoProceso
values ('Cargo'),('Abono')
go

-- Lectura de los datos
select * from tipoCliente
go

select * from tipoProceso
go