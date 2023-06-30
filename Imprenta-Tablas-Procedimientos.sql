CREATE DATABASE Imprenta
USE Imprenta

--CREAR TABLA PROVEEDOR
create table Proveedor (
id_Proveedor varchar(15) not null PRIMARY KEY,
Razon_social varchar(30) not null,
Correo varchar(30) not null,
);

insert into Proveedor
values ('PR1','Tazas office S.A','tazasoffice@gmail.com')
insert into Proveedor
values ('PR2','Ropa Cuauti S.A','ropacuauti@gmail.com')
insert into Proveedor
values ('PR3','LonasMX S.A','lonasmx@gmail.com')

--Procedimiento Insertar Proveedoor
CREATE PROCEDURE INSProveedor
@id_Proveedor varchar(15),
@Razon_social varchar(30),
@Correo varchar (30)
as
insert into Proveedor (id_Proveedor,Razon_social, Correo)
values (@id_Proveedor,@Razon_social, @Correo);

Exec INSProveedor 'PR4', 'Cartas Izcalli S.A', 'cartasizcalli@gmail.com';

--Procedimiento Update Proveedor
CREATE PROCEDURE UPDProveedor
@id_Proveedor varchar(15),
@Razon_social varchar(30),
@Correo varchar (30)
as
UPDATE Proveedor
SET id_Proveedor = @id_Proveedor ,Razon_social = @Razon_social, Correo = @Correo
WHERE id_Proveedor = @id_Proveedor;

EXEC UPDProveedor 'PR2', 'Ropa Cuautitlán S.A', 'ropacuauti@gmail.com';

--Procedimiento Eliminar Proveedor
CREATE PROCEDURE DELProveedor
@id_Proveedor varchar(15),
@Razon_social varchar(30),
@Correo varchar (30)
as
DELETE Proveedor WHERE id_Proveedor = @id_Proveedor 
AND Razon_social = @Razon_social 
AND Correo = @Correo;

Exec DELProveedor 'PR4', 'Cartas Izcalli S.A', 'cartasizcalli@gmail.com';

select * from proveedor;


--CREAR TABLA MATERIA PRIMA
create table Materia_Prima(
id_mp varchar(15) not null PRIMARY KEY,
Nombre varchar(20) not null,
Descripcion varchar(50) not null,
id_Proveedor varchar(15) not null,
FOREIGN KEY (id_Proveedor) REFERENCES Proveedor(id_Proveedor)
);

ALTER TABLE Materia_Prima
ADD FOREIGN KEY (id_Proveedor)
REFERENCES Proveedor(id_Proveedor)
ON DELETE CASCADE
ON UPDATE CASCADE;

insert into Materia_Prima
values ('MP1','Tazas','Tazas blancas','PR1')
insert into Materia_Prima
values ('MP2','Camisas','Camisas cuello v','PR2')
insert into Materia_Prima
values ('MP3','Sudaderas','Sudaderas con gorra','PR2')
insert into Materia_Prima
values ('MP4','Lonas','Lonas plastificada de polietileno','PR3')


--Procedimiento Insertar Materia Prima
CREATE PROCEDURE INSmp
@id_mp varchar(15),
@Nombre varchar(20),
@Descripcion varchar (50),
@id_proveedor varchar(15)
as
insert into Materia_Prima(id_mp,Nombre,Descripcion,id_proveedor)
values (@id_mp,@Nombre,@Descripcion,@id_proveedor);

exec INSmp 'MP5','Cartas','Cartas de tamaño 4x4','PR4';

--Procedimiento Update Materia Prima
CREATE PROCEDURE UPDMateria_Prima
@id_mp varchar(15),
@Nombre varchar(20),
@Descripcion varchar (50),
@id_proveedor varchar(15)
as
UPDATE Materia_Prima
SET id_mp = @id_mp, Nombre = @Nombre, Descripcion = @Descripcion, id_proveedor = @id_proveedor
WHERE id_mp = @id_mp;

EXEC UPDMateria_Prima 'MP2', 'Camisas Negras', 'Camisas Cuello V Negras', 'PR2';

--Procedimiento Delete Materia Prima
CREATE PROCEDURE DELMateria_Prima
@id_mp varchar(15),
@Nombre varchar(20),
@Descripcion varchar (50),
@id_proveedor varchar(15)
as
DELETE Materia_Prima WHERE id_mp = @id_mp 
AND Nombre = @Nombre 
AND Descripcion = @Descripcion 
AND id_proveedor = @id_proveedor;

EXEC DELMateria_Prima 'MP4', 'Lonas', 'Lonas plastificada de polietileno', 'PR3';

select * from Materia_Prima;

--CREAR TABLA INVENTARIO
CREATE TABLE Inventario (
  id_Inventario VARCHAR(15) NOT NULL PRIMARY KEY,
  id_mp VARCHAR(15) NOT NULL,
  mp_entrada INT NOT NULL,
  mp_salida INT NOT NULL,
  stock AS (mp_entrada - mp_salida),
  FOREIGN KEY (id_mp) REFERENCES Materia_Prima (id_mp)
);

ALTER TABLE Inventario
ADD FOREIGN KEY (id_mp)
REFERENCES Materia_Prima (id_mp)
ON DELETE CASCADE
ON UPDATE CASCADE;

insert into Inventario
values ('IV1','MP1',100,20)
insert into Inventario
values ('IV2','MP2',20,10)
insert into Inventario
values ('IV3','MP3',30,10)
insert into Inventario
values ('IV4','MP4',40,20)

--Procedimiento Insertar Inventario
CREATE PROCEDURE INSInventario
@id_Inventario varchar(15),
@id_mp varchar(15),
@mp_entrada int,
@mp_salida int
as
insert into Inventario(id_Inventario,id_mp,mp_entrada,mp_salida)
values (@id_Inventario,@id_mp,@mp_entrada,@mp_salida);

Exec INSInventario 'IV5', 'MP5', 60, 30;

--Procedimiento Update Inventario
CREATE PROCEDURE UPDInventario
@id_Inventario varchar(15),
@id_mp varchar(15),
@mp_entrada int,
@mp_salida int
as
UPDATE Inventario
SET id_Inventario = @id_Inventario, id_mp = @id_mp, mp_entrada = @mp_entrada, mp_salida = @mp_salida
WHERE id_Inventario = @id_Inventario;

EXEC UPDInventario 'IV2', 'MP2', 30, 10;

--Procedimiento Delete Inventario
CREATE PROCEDURE DELInventario
@id_Inventario varchar(15),
@id_mp varchar(15),
@mp_entrada int,
@mp_salida int
as
DELETE Inventario WHERE id_Inventario = @id_Inventario
AND id_mp = @id_mp
AND mp_entrada = @mp_entrada
AND mp_salida = @mp_salida;

EXEC DELInventario 'IV2', 'MP2', 30, 10;

select * from Inventario;

--CREAR TABLA PRODUCTO
CREATE TABLE Producto(
id_producto VARCHAR(15) NOT NULL PRIMARY KEY,
nombre VARCHAR(20) NOT NULL,
descripcion VARCHAR(50) NOT NULL,
precio MONEY NOT NULL,
sku NUMERIC(6) NOT NULL
);

insert into Producto
values ('PR01','Taza personalizada','Taza por grabado láser','$100',453453)
insert into Producto
values ('PR02','Camisa enamorados','Camisa personalizada por sublimación','$200',432423)
insert into Producto
values ('PR03','Sudadera con logo','Sudadera con logo personalizable por sublimación','$350',123242)
insert into Producto
values ('PR04','Lona 2mx2m','Lona de 2mx2m por grabado láser','$120',494342)
insert into Producto
values ('PR05','Lona 3mx3m','Lona de 3mx3m por grabado láser','$170',435123)


--Procedimiento Insertar Producto
CREATE PROCEDURE INSProducto
@id_producto VARCHAR(15),
@nombre VARCHAR(20),
@descripcion VARCHAR(50),
@precio MONEY,
@sku NUMERIC(6)
as
insert into Producto(id_producto, nombre, descripcion, precio, sku)
values (@id_producto, @nombre, @descripcion, @precio, @sku);

Exec INSProducto 'PR06', 'Cartas','Cartas personalizadas', 100,486464;

--update
CREATE PROCEDURE UPDProducto
@id_producto VARCHAR(15),
@nombre VARCHAR(20),
@descripcion VARCHAR(50),
@precio MONEY,
@sku NUMERIC(6)
as
update Producto
set id_producto= @id_producto, nombre=@nombre,descripcion=@descripcion,precio=@precio,sku=@sku
where id_producto=@id_producto
EXEC UPDProducto 'PR06','Cartas 4x4','Cartas personalizadas de amor',110,476302

--delete
CREATE PROCEDURE DELProducto
@id_producto VARCHAR(15),
@nombre VARCHAR(20),
@descripcion VARCHAR(50),
@precio MONEY,
@sku NUMERIC(6)
as
DELETE Producto WHERE id_producto= @id_producto
AND nombre=@nombre
AND descripcion=@descripcion
AND precio=@precio
AND sku=@sku

Exec DELProducto 'PR05','Lona 3mx3m','Lona de 3mx3m por grabado láser',170,435123

select * from Producto;

--CREAR TABLA CLIENTE
create table Cliente(
id_Cliente varchar(15) not null primary key,
Telefono numeric(10) not null,
Nombre varchar(20) not null,
Apellido_Paterno varchar(15) not null,
Apellido_Materno varchar(15) not null,
Correo varchar(20) not null,
rfc varchar (10) not null
);


insert into Cliente
values ('C1','5532538152','Jose Luis','Garza','Espinoza','josegarza@gmail.com','GAEL030426')
insert into Cliente
values ('C2','5543720870','Jessica','Gaytan','Cruz','jessicag@gmail.com','GACJ030808')
insert into Cliente
values ('C3','5532389564','Concepción','Cruz','Tapia','misssconi@gmail.com','CRT150974')


--Procedimiento Ins Cliente
CREATE PROCEDURE INSCliente
@id_Cliente varchar(15),
@Telefono varchar(10),
@Nombre varchar (20),
@Apellido_Paterno varchar(15),
@Apellido_Materno varchar(15),
@Correo varchar(20),
@rfc varchar(10)
as
insert into Cliente (id_Cliente, Telefono, Nombre, Apellido_Paterno, Apellido_Materno, Correo, rfc)
values (@id_Cliente, @Telefono, @Nombre, @Apellido_Paterno, @Apellido_Materno, @Correo, @rfc);

Exec INSCliente 'C4', '5510168163', 'Sahyra', 'Salcedo', 'Rosas', 'sahyras@gmail.com', 'SALC030413';

--update
CREATE PROCEDURE UPDCliente
@id_Cliente varchar(15),
@Telefono varchar(10),
@Nombre varchar (20),
@Apellido_Paterno varchar(15),
@Apellido_Materno varchar(15),
@Correo varchar(20),
@rfc varchar(10)
as
update Cliente
set id_Cliente=@id_Cliente, Telefono=@Telefono,Nombre=@Nombre,Apellido_Paterno=@Apellido_Paterno, 
Apellido_Materno=@Apellido_Materno,Correo=@Correo,rfc=@rfc
where id_Cliente=@id_Cliente

EXEC UPDCliente 'C1','5562986520','Jose Luis','Garza','Espinoza','josegarza@gmail.com','GAEL030426'

--delete
CREATE PROCEDURE DELCliente
@id_Cliente varchar(15),
@Telefono varchar(10),
@Nombre varchar (20),
@Apellido_Paterno varchar(15),
@Apellido_Materno varchar(15),
@Correo varchar(20),
@rfc varchar(10)
as
DELETE Cliente WHERE id_Cliente=@id_Cliente
AND Telefono=@Telefono
AND Nombre=@Nombre
AND Apellido_Paterno=@Apellido_Paterno
AND Apellido_Materno=@Apellido_Materno
AND Correo=@Correo
AND rfc=@rfc

Exec DELCliente 'C4','5510168163','Sahyra','Salcedo','Rosas','sahyras@gmail.com','SALC030413'

select * from Cliente;


--CREAR TABLA FACTURA
 Create table Factura(
 id_Factura varchar(15) not null primary key,
 Fecha date not null,
 Tipo_de_pago varchar(10) not null,
 Cantidad_pagada money not null,
 Pagado char(2) not null,
 id_Cliente varchar(15) not null,
 FOREIGN KEY (id_Cliente) REFERENCES Cliente (id_Cliente)
 );
 
 ALTER TABLE Factura
ADD FOREIGN KEY (id_Cliente)
REFERENCES Cliente (id_Cliente)
ON DELETE CASCADE
ON UPDATE CASCADE
;

 insert into Factura
 values('F1','08-08-2023','Debito', '$200','SI', 'C1');
 insert into Factura 
 values('F2','02-02-2023','Debito', '$100','NO', 'C2');
 insert into Factura 
 values('F3','04-15-2023','Efectivo', '$125','NO', 'C2');
insert into Factura
values('F4','04-26-2023','Credito', '$180','SI', 'C3');


--ins Factura
CREATE PROCEDURE INSFactura
@id_Factura varchar(15),
@Fecha date,
@Tipo_De_Pago varchar (10),
@Cantidad_Pagada money,
@Pagado char(2),
@id_Cliente varchar(15)
as
insert into Factura (id_Factura, Fecha, Tipo_De_Pago, Cantidad_Pagada, Pagado, id_Cliente)
values (@id_Factura, @Fecha, @Tipo_De_Pago, @Cantidad_Pagada, @Pagado, @id_Cliente);

Exec INSFactura 'F2', '2023-12-03', 'Efectivo', '150', 'NO', 'C1';

--Procedimiento Update Factura
CREATE PROCEDURE UPDFactura
@id_Factura varchar(15),
@Fecha date,
@Tipo_De_Pago varchar (10),
@Cantidad_Pagada money,
@Pagado char(2),
@id_Cliente varchar(15)
as
UPDATE Factura 
SET id_Factura = @id_Factura, Fecha = @Fecha, Tipo_De_Pago = @Tipo_De_Pago, 
Cantidad_Pagada = @Cantidad_Pagada, Pagado= @Pagado, id_Cliente = @id_Cliente
WHERE id_Factura = @id_Factura;

EXEC UPDFactura 'F1', '2023-08-08', 'Efectivo', 200, 'SI', 'C1';

--Procedimiento Delete Factura
CREATE PROCEDURE DELFactura
@id_Factura varchar(15),
@Fecha date,
@Tipo_De_Pago varchar (10),
@Cantidad_Pagada money,
@Pagado char(2),
@id_Cliente varchar(15)
as
DELETE Factura 
WHERE id_Factura = @id_Factura
AND Fecha = @Fecha
AND Tipo_De_Pago = @Tipo_De_Pago
AND Cantidad_Pagada = @Cantidad_Pagada
AND Pagado= @Pagado
AND id_Cliente = @id_Cliente;

EXEC DELFactura 'F2', '2023-12-03', 'Efectivo', 150, 'NO', 'C1';

select *from Factura;

--CREAR TABLA PEDIDOS
 create table Pedidos (
 id_Pedidos varchar(15) not null primary key,
 Cantidad int not null,
 Fecha_Pedido date,
 Fecha_Entrega date,
 id_mp varchar(15) not null,
 FOREIGN KEY (id_mp) REFERENCES Materia_Prima (id_mp),
 id_producto VARCHAR(15) NOT NULL,
 FOREIGN KEY (id_producto) REFERENCES Producto (id_producto),
 id_Cliente varchar(15) not null,
 FOREIGN KEY (id_Cliente) REFERENCES Cliente (id_Cliente)
 );

 ALTER TABLE Pedidos
ADD FOREIGN KEY (id_mp)
REFERENCES Materia_Prima (id_mp)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Pedidos
ADD FOREIGN KEY (id_producto)
REFERENCES Producto (id_producto)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Pedidos
ADD FOREIGN KEY (id_Cliente)
REFERENCES Cliente (id_Cliente)
ON DELETE CASCADE
ON UPDATE CASCADE;


insert into Pedidos
values('P1', 1, '08-08-2023', '08-10-2023', 'MP1', 'PR01', 'C1');
insert into Pedidos
values('P2', 3, '02-02-2023', '02-15-2023', 'MP3', 'PR03', 'C2');
insert into Pedidos
values('P3', 2, '02-02-2023', '02-06-2023', 'MP2', 'PR02', 'C2');
insert into Pedidos
values('P4', 1, '04-26-2023', '04-30-2023', 'MP4', 'PR05', 'C3');
insert into Pedidos
values('P5', 5, '04-26-2023', '05-01-2023', 'MP4', 'PR04', 'C3');


--ins Pedidos
 CREATE PROCEDURE INSPedidos
@id_Pedidos varchar(15),
@Cantidad int,
@Fecha_Pedido date,
@Fecha_Entrega date,
@id_mp varchar(15),
@id_producto varchar(15),
@id_Cliente varchar (15)
as
insert into Pedidos (id_Pedidos, Cantidad,Fecha_Pedido,Fecha_Entrega, id_mp, id_producto, id_Cliente)
values (@id_Pedidos, @Cantidad,@Fecha_Pedido,@Fecha_Entrega, @id_mp, @id_producto, @id_Cliente);

Exec INSPedidos 'P6', '3', '06-01-2003', '06-04-2023', 'MP3', 'PR03', 'C3';

--Upd pedidos
 CREATE PROCEDURE UPDPedidos
@id_Pedidos varchar(15),
@Cantidad int,
@Fecha_Pedido date,
@Fecha_Entrega date,
@id_mp varchar(15),
@id_producto varchar(15),
@id_Cliente varchar (15)
as
UPDATE Pedidos
SET id_Pedidos = @id_Pedidos, Cantidad = @Cantidad, Fecha_Pedido = @Fecha_Pedido,
Fecha_Entrega = @Fecha_Entrega, id_mp = @id_mp, id_producto = @id_producto,
id_Cliente = @id_Cliente
WHERE id_Pedidos = @id_Pedidos;

EXEC UPDPedidos 'P2', 10, '2023-02-02', '2023-02-15', 'MP3', 'PR03', 'C2'

--del Pedidos
 CREATE PROCEDURE DELPedidos
@id_Pedidos varchar(15),
@Cantidad int,
@Fecha_Pedido date,
@Fecha_Entrega date,
@id_mp varchar(15),
@id_producto varchar(15),
@id_Cliente varchar (15)
as
DELETE Pedidos
WHERE id_Pedidos = @id_Pedidos
AND Cantidad = @Cantidad
AND Fecha_Pedido = @Fecha_Pedido
AND Fecha_Entrega = @Fecha_Entrega
AND id_mp = @id_mp
AND id_producto = @id_producto
AND id_Cliente = @id_Cliente;

EXEC DELPedidos 'P6', 3, '2003-06-01', '2023-06-04', 'MP3', 'PR03', 'C3'

SELECT * FROM Pedidos;

 
 Select Ped.id_Pedidos, Ped.Cantidad, Ped.Fecha_Pedido, 
 Ped.Fecha_Entrega, MP.Nombre, Pro.nombre, Cl.Nombre
 From Materia_Prima MP, Pedidos Ped,
 Producto Pro, Cliente Cl
 Where MP.id_mp = Ped.id_mp
 AND Ped.id_producto = Pro.id_producto
 AND Ped.id_Cliente = Cl.id_Cliente
 ORDER BY CAST(SUBSTRING(Ped.id_Pedidos, 2, LEN(Ped.id_Pedidos)) AS INT)
