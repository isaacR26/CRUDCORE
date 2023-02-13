create database DBCRUDCORE; 
use DBCRUDCORE; 
create table CONTACTO(
IdContacto int primary key AUTO_INCREMENT, 
Nombre varchar(50), 
Telefono varchar(50),
Correo varchar(50)
 )

DELIMITER // 
create procedure sp_Listar()

begin
	select * from CONTACTO; 
    end // 
DELIMITER ; 

DELIMITER //
CREATE PROCEDURE sp_Obtener(IN p_IdContacto INT)
BEGIN
SELECT * FROM CONTACTO WHERE IdContacto = p_IdContacto;
END //
DELIMITER ; 
DROP PROCEDURE sp_Obtener;
call sp_Obtener(7);
DELIMITER // 

create procedure sp_Guardar( in Nombre varchar(100), in Telefono varchar(100), in Correo varchar(100))

begin
	insert into CONTACTO(Nombre,Telefono,Correo) values (Nombre,Telefono,Correo); 
    end // 
DELIMITER ; 

DELIMITER // 
create procedure sp_Editar(
in IdContac int, 
in new_Nombre varchar(100),
 in new_Telefono varchar(100), 
 in new_Correo varchar(100))

begin
	update CONTACTO set Nombre=new_Nombre, Telefono=new_Telefono, Correo=new_Correo where IdContacto=IdContac; 
    end // 
DELIMITER ; 
call sp_Editar(3, "karen","22", "karen@jej.com");
call sp_Editar(5,"camilo","2000","c@c"); 
DROP PROCEDURE sp_Editar;
DROP PROCEDURE sp_Eliminar;
DROP table CONTACTO; 
DELIMITER // 
create procedure sp_Eliminar( in IdContac int)

begin
	delete from CONTACTO where IdContacto = Idcontac; 
    end // 
DELIMITER ; 

insert into CONTACTO(Nombre,Telefono,Correo) values ("isaac","3046769595","is@ac.com"); 
select * from CONTACTO; 
call sp_Guardar("rex","0605","ala@lele.com"); 
call sp_Eliminar("4");
call sp_Listar(); 
ALTER TABLE CONTACTO
MODIFY COLUMN IdContacto INT AUTO_INCREMENT;
delete from CONTACTO where IdContacto=2; 