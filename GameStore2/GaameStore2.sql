Create database GameStore2;
go 
use GameStore2
go

create table Categoria
(
Id int primary key identity,
Genero varchar(50)
)
go
create table Producto
(
Id int primary key identity,
Nombre varchar(50),
Consola Varchar(50),
Precio float,
FechaCreacion date,
CategoriaId int,
Path varchar(Max),
CantidadAlmacen int,

foreign key(CategoriaId) references Categoria)

select*from Producto
drop table Producto
go
insert into categoria(Genero) values

('Lucha'),
('Accion'),
('Aventura'),
('Carreras'),
('Deportes'),
('Musica'),
('FPS'),
('Roles'),
('Estrategia'),
('Otros')


go
insert into Producto(Nombre,Consola,Precio,FechaCreacion,CategoriaId) values 


go
create table Venta
(
Id int primary key identity,
DiaVenta datetime,
Subtotal float,
Itebis float,
Total float)
go
create table ListaVenta
(
Id int primary key identity,
VentaId int,
ProductoId int,
Cantidad int,
Total float,
foreign key(VentaId) references Venta,
foreign key(ProductoId) references Producto
)
drop  table listaVenta

Create table factura (
Id_Factura int primary key identity,
Idventa int,
IdListaVenta int,
IdCliente int,
)

drop table factura

