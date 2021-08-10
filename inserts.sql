
INSERT INTO Persona(idPersona,nombre,apellidos) 
VALUES (116530854,'josua','ortiz alvarado');

INSERT INTO Roles(idRoles,descripcionRoles) 
VALUES (1,'admin');

INSERT INTO Roles(idRoles,descripcionRoles) 
VALUES (2,'editor');

INSERT INTO Roles(idRoles,descripcionRoles) 
VALUES (3,'lector');

INSERT INTO Colaboradores VALUES (116530854,'san jose',1,'jsua','test1234','jsua986@gmail.com','89457568',1);

INSERT INTO Colaboradores VALUES (116530854,'san jose',2,'test2','test1234','jsua986@gmail.com','89457568',1);

INSERT INTO Colaboradores VALUES (116530854,'san jose',3,'test3','test1234','jsua986@gmail.com','89457568',1);


use DB_AnimaWeb
ALTER TABLE Documento
ALTER COLUMN Contenido varchar(1500);