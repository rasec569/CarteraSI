BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Cartera" (
	"Id_Cartera"	INTEGER NOT NULL UNIQUE,
	"Estado_cartera"	VARCHAR(45) NOT NULL,
	"Total_Neto_Recaudado"	VARCHAR(45),
	"Total_Mora"	VARCHAR(45),
	"Total_Cartera"	VARCHAR(45),
	PRIMARY KEY("Id_Cartera" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Seguimiento" (
	"Id_Seguimiento"	INTEGER NOT NULL UNIQUE,
	"Fecha_Seguimieto"	DATE NOT NULL,
	"Comentario"	VARCHAR(45) NOT NULL,
	"Fk_Id_Producto"	INT NOT NULL,
	PRIMARY KEY("Id_Seguimiento" AUTOINCREMENT),
	FOREIGN KEY("Fk_Id_Producto") REFERENCES "Producto"("Id_Producto")
);
CREATE TABLE IF NOT EXISTS "Pagos" (
	"Id_Pagos"	INTEGER NOT NULL UNIQUE,
	"Porcentaje"	VARCHAR(45) NOT NULL,
	"Fecha_Pago"	DATE NOT NULL,
	"Referencia_Pago"	VARCHAR(45) NOT NULL,
	"Valor_Pagado"	VARCHAR(45) NOT NULL,
	"Descuento"	VARCHAR(45),
	"Valor_Descuento"	VARCHAR(45),
	"Pagoscol"	INT,
	"Fk_Id_Producto"	INT NOT NULL,
	PRIMARY KEY("Id_Pagos" AUTOINCREMENT),
	FOREIGN KEY("Fk_Id_Producto") REFERENCES "Producto"("Id_Producto")
);
CREATE TABLE IF NOT EXISTS "Usuario" (
	"Id_usuario"	INTEGER NOT NULL,
	"Nom_Usuario"	TEXT NOT NULL UNIQUE,
	"Contraseña"	TEXT NOT NULL,
	PRIMARY KEY("Id_usuario" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Cliente" (
	"Id_Cliente"	INTEGER NOT NULL UNIQUE,
	"Cedula"	INTEGER NOT NULL UNIQUE,
	"Nombre"	VARCHAR(45) NOT NULL,
	"Apellido"	VARCHAR(45) NOT NULL,
	"Telefono"	INTEGER NOT NULL,
	"Direccion"	VARCHAR(45),
	"Correo"	VARCHAR(45),
	"Fk_Id_Cartera"	INTEGER NOT NULL,
	PRIMARY KEY("Id_Cliente" AUTOINCREMENT),
	FOREIGN KEY("Fk_Id_Cartera") REFERENCES "Cartera"("Id_Cartera")
);
CREATE TABLE IF NOT EXISTS "Tipo_Producto" (
	"Id_Tipo_Producto"	INTEGER NOT NULL UNIQUE,
	"Nom_Tipo_Producto"	VARCHAR(45) NOT NULL,
	PRIMARY KEY("Id_Tipo_Producto" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Producto" (
	"Id_Producto"	INTEGER NOT NULL,
	"Nombre_Producto"	VARCHAR(45) NOT NULL UNIQUE,
	"Numero_contrato"	VARCHAR(45) NOT NULL,
	"Forma_Pago"	VARCHAR(45) NOT NULL,
	"Valor_Total"	INTEGER NOT NULL,
	"Valor_Entrada"	INTEGER,
	"Valor_Sin_interes"	INTEGER,
	"Cuotas_Sin_interes"	INTEGER,
	"Valor_Cuota_Sin_interes"	INTEGER,
	"Valor_Con_Interes"	INTEGER,
	"Cuotas_Con_Interes"	INTEGER,
	"Valor_Cuota_Con_Interes"	INTEGER,
	"Valor_Interes"	INTEGER,
	"Fecha_Venta"	TEXT,
	"Fecha_Recaudo"	TEXT,
	"Observaciones"	VARCHAR(255),
	"Fk_Id_CarteraP"	INTEGER NOT NULL,
	"Fk_Id_Proyecto"	INTEGER NOT NULL,
	"Fk_Id_Tipo_Producto"	INTEGER NOT NULL,
	PRIMARY KEY("Id_Producto" AUTOINCREMENT),
	FOREIGN KEY("Fk_Id_CarteraP") REFERENCES "Cartera"("Id_Cartera"),
	FOREIGN KEY("Fk_Id_Proyecto") REFERENCES "Proyecto"("Id_Proyecto"),
	FOREIGN KEY("Fk_Id_Tipo_Producto") REFERENCES "Tipo_Producto"("Id_Tipo_Producto")
);
CREATE TABLE IF NOT EXISTS "Proyecto" (
	"Id_Proyecto"	INTEGER NOT NULL,
	"Proyecto_Nombre"	TEXT NOT NULL,
	"Proyecto_Ubicacion"	TEXT,
	PRIMARY KEY("Id_Proyecto" AUTOINCREMENT)
);
INSERT INTO "Cartera" ("Id_Cartera","Estado_cartera","Total_Neto_Recaudado","Total_Mora","Total_Cartera") VALUES (1,'Al dia','850000','0','0');
INSERT INTO "Cartera" ("Id_Cartera","Estado_cartera","Total_Neto_Recaudado","Total_Mora","Total_Cartera") VALUES (13,'Menos de 30 dias','8000','0','0');
INSERT INTO "Cartera" ("Id_Cartera","Estado_cartera","Total_Neto_Recaudado","Total_Mora","Total_Cartera") VALUES (14,'De 31 a 60 dias','8000','0','0');
INSERT INTO "Cartera" ("Id_Cartera","Estado_cartera","Total_Neto_Recaudado","Total_Mora","Total_Cartera") VALUES (15,'de 61 a 90 dias ','8000','0','0');
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (1,'sin interes','22/08/21','12345','150000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (2,'sin interes','22/09/20','01134','150000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (3,'sin interes','22/10/20','45677','150000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (4,'sin interes','22/11/20','24567','150000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (5,'sin interes','22/12/20','24567','150000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (6,'sin interes','22/01/21','24678','150000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (7,'con interes','22/02/21','35780','150000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (8,'con interes','22/02/21','32156','150000',NULL,NULL,NULL,3);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (9,'interes','19/02/21','65434','8000',NULL,NULL,NULL,1);
INSERT INTO "Pagos" ("Id_Pagos","Porcentaje","Fecha_Pago","Referencia_Pago","Valor_Pagado","Descuento","Valor_Descuento","Pagoscol","Fk_Id_Producto") VALUES (10,'con interes','22/02/21','13479','150000',NULL,NULL,NULL,1);
INSERT INTO "Usuario" ("Id_usuario","Nom_Usuario","Contraseña") VALUES (1,'admin','123');
INSERT INTO "Cliente" ("Id_Cliente","Cedula","Nombre","Apellido","Telefono","Direccion","Correo","Fk_Id_Cartera") VALUES (1,1075238593,'CESAR AUGUSTO','VALENCIA VALENCIA',3133250701,'Calle 12-67','cesarvalencia@gmail.com',1);
INSERT INTO "Cliente" ("Id_Cliente","Cedula","Nombre","Apellido","Telefono","Direccion","Correo","Fk_Id_Cartera") VALUES (13,1234566666,'LORENA','PEDROZA',43575,'carrera 5 # 3','fdgnfg@hjkl',13);
INSERT INTO "Cliente" ("Id_Cliente","Cedula","Nombre","Apellido","Telefono","Direccion","Correo","Fk_Id_Cartera") VALUES (14,5678,'MAURICIO','PASTRANA',5432,'fghj','fghj',14);
INSERT INTO "Cliente" ("Id_Cliente","Cedula","Nombre","Apellido","Telefono","Direccion","Correo","Fk_Id_Cartera") VALUES (15,1234,'CARLOS','TRUJILLO',765432,'hgdfd','nvgfx',15);
INSERT INTO "Tipo_Producto" ("Id_Tipo_Producto","Nom_Tipo_Producto") VALUES (0,'seleccione una opción');
INSERT INTO "Tipo_Producto" ("Id_Tipo_Producto","Nom_Tipo_Producto") VALUES (1,'LOTE');
INSERT INTO "Tipo_Producto" ("Id_Tipo_Producto","Nom_Tipo_Producto") VALUES (2,'CASA');
INSERT INTO "Producto" ("Id_Producto","Nombre_Producto","Numero_contrato","Forma_Pago","Valor_Total","Valor_Entrada","Valor_Sin_interes","Cuotas_Sin_interes","Valor_Cuota_Sin_interes","Valor_Con_Interes","Cuotas_Con_Interes","Valor_Cuota_Con_Interes","Valor_Interes","Fecha_Venta","Fecha_Recaudo","Observaciones","Fk_Id_CarteraP","Fk_Id_Proyecto","Fk_Id_Tipo_Producto") VALUES (1,'Lote 43','45678','Contado',19000000,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'23/08/2019','23/08/2019',NULL,1,1,1);
INSERT INTO "Producto" ("Id_Producto","Nombre_Producto","Numero_contrato","Forma_Pago","Valor_Total","Valor_Entrada","Valor_Sin_interes","Cuotas_Sin_interes","Valor_Cuota_Sin_interes","Valor_Con_Interes","Cuotas_Con_Interes","Valor_Cuota_Con_Interes","Valor_Interes","Fecha_Venta","Fecha_Recaudo","Observaciones","Fk_Id_CarteraP","Fk_Id_Proyecto","Fk_Id_Tipo_Producto") VALUES (2,'lote666','ghfdsa','Contado',654234,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'23/08/2019','23/08/2019',NULL,1,1,1);
INSERT INTO "Producto" ("Id_Producto","Nombre_Producto","Numero_contrato","Forma_Pago","Valor_Total","Valor_Entrada","Valor_Sin_interes","Cuotas_Sin_interes","Valor_Cuota_Sin_interes","Valor_Con_Interes","Cuotas_Con_Interes","Valor_Cuota_Con_Interes","Valor_Interes","Fecha_Venta","Fecha_Recaudo","Observaciones","Fk_Id_CarteraP","Fk_Id_Proyecto","Fk_Id_Tipo_Producto") VALUES (3,'iii','','Contado','',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'23/08/2019','03/02/2021',NULL,13,1,1);
INSERT INTO "Producto" ("Id_Producto","Nombre_Producto","Numero_contrato","Forma_Pago","Valor_Total","Valor_Entrada","Valor_Sin_interes","Cuotas_Sin_interes","Valor_Cuota_Sin_interes","Valor_Con_Interes","Cuotas_Con_Interes","Valor_Cuota_Con_Interes","Valor_Interes","Fecha_Venta","Fecha_Recaudo","Observaciones","Fk_Id_CarteraP","Fk_Id_Proyecto","Fk_Id_Tipo_Producto") VALUES (4,'lote555','r678','Contado',16999999,5678,654,NULL,10,543,NULL,10,5432,'13/01/2021','04/02/2021','',14,1,1);
INSERT INTO "Producto" ("Id_Producto","Nombre_Producto","Numero_contrato","Forma_Pago","Valor_Total","Valor_Entrada","Valor_Sin_interes","Cuotas_Sin_interes","Valor_Cuota_Sin_interes","Valor_Con_Interes","Cuotas_Con_Interes","Valor_Cuota_Con_Interes","Valor_Interes","Fecha_Venta","Fecha_Recaudo","Observaciones","Fk_Id_CarteraP","Fk_Id_Proyecto","Fk_Id_Tipo_Producto") VALUES (5,'Lote 33','442-55','Contado',876543,0,0,0,0,7635,0,0,0,'23/08/2019','16/12/2020','Modificar',15,1,1);
INSERT INTO "Proyecto" ("Id_Proyecto","Proyecto_Nombre","Proyecto_Ubicacion") VALUES (0,'seleccione una opción',NULL);
INSERT INTO "Proyecto" ("Id_Proyecto","Proyecto_Nombre","Proyecto_Ubicacion") VALUES (1,'SAN ISIDRO CONJUNTO RESIDENCIAL',NULL);
INSERT INTO "Proyecto" ("Id_Proyecto","Proyecto_Nombre","Proyecto_Ubicacion") VALUES (2,'RESERVA DEL BOSQUE PARQUE REISEDENCIAL',NULL);
INSERT INTO "Proyecto" ("Id_Proyecto","Proyecto_Nombre","Proyecto_Ubicacion") VALUES (7,'Casa barrio la paz','calle 6 fff');
COMMIT;
