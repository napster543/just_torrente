IF OBJECT_ID('cliente', 'U') IS NOT NULL  
  DROP TABLE cliente; 

create table cliente(
	id int identity(1,1) primary key not null,
	Nombre_Completo varchar(100),
	cedula varchar(18),
	PIN int
)

/* ****************************************************** */

IF OBJECT_ID('pagos', 'U') IS NOT NULL  
  DROP TABLE pagos; 

create table pagos(
	id int identity(1,1) primary key not null,
	cedula varchar(18),
	fecha_pago datetime default GETDATE(),
	monto money
)


/* ****************************************************** */
exec ConsultaPagosCliente '8-75-584'
exec ConsultaPagosCliente ''

IF OBJECT_ID('ConsultaPagosCliente', 'P') IS NOT NULL  
  DROP PROCEDURE ConsultaPagosCliente;
GO
CREATE PROCEDURE ConsultaPagosCliente(
	@Cedula varchar(18)
)
as
SELECT c.cedula, c.Nombre_Completo, p.fecha_pago, p.monto FROM cliente c JOIN pagos p ON c.cedula = p.cedula 
WHERE c.cedula = @Cedula OR @Cedula = '' order by p.fecha_pago desc


--truncate table cliente
--insert into cliente(Nombre_Completo, cedula, PIN) values ('Juan Perez', '8-75-584', 1478)
--insert into cliente(Nombre_Completo, cedula, PIN) values ('Miguel', 'PE-254-845', 1244)

--truncate table pagos
--insert into pagos(cedula, fecha_pago, monto) values ('8-75-584', '20210404', 200.00)
--insert into pagos(cedula, fecha_pago, monto) values ('8-75-584', '20210105', 198.22)
--insert into pagos(cedula, fecha_pago, monto) values ('8-75-584', '20210106', 210.00)


--insert into pagos(cedula, fecha_pago, monto) values ('PE-254-845', '20210430', 200.00)
--insert into pagos(cedula, fecha_pago, monto) values ('PE-254-845', '20210329', 198.22)
--insert into pagos(cedula, fecha_pago, monto) values ('PE-254-845', '20210217', 210.00)



