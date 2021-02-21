BEGIN TRANSACTION;
-- -----------------------------------------------------
-- Table "Cartera"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Cartera" (
  "Id_Cartera" INTEGER NOT NULL UNIQUE,
  "Estado_cartera" VARCHAR(45) NOT NULL,
  "Total_Neto_Recaudado" VARCHAR(45) NULL,
  "Total_Mora" VARCHAR(45) NULL,
  "Total_Cartera" VARCHAR(45) NULL,
  PRIMARY KEY ("Id_Cartera" AUTOINCREMENT)
  );
-- -----------------------------------------------------
-- Table "Cliente"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Cliente" (
  "Id_Cliente" INTEGER NOT NULL UNIQUE,
  "Cedula" INTEGER NOT NULL UNIQUE,
  "Nombre" VARCHAR(45) NOT NULL,
  "Apellido" VARCHAR(45) NOT NULL,
  "Telefono" INTEGER NOT NULL,
  "Direccion" VARCHAR(45) NULL,
  "Correo" VARCHAR(45) NULL,
  "Fk_Id_Cartera" INTEGER NOT NULL,
  PRIMARY KEY ("Id_Cliente" AUTOINCREMENT),
  FOREIGN KEY ("Fk_Id_Cartera")
    REFERENCES "Cartera" ("Id_Cartera")
);
-- -----------------------------------------------------
-- Table "Proyecto"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Proyecto" (
  "Id_Proyecto" INTEGER NOT NULL UNIQUE,
  "Proyecto_Nombre" VARCHAR(45) NOT NULL,
  "Proyecto_Ubicacion" VARCHAR(45) NULL,
  PRIMARY KEY ("Id_Proyecto" AUTOINCREMENT)
);
-- -----------------------------------------------------
-- Table "Tipo_Producto"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Tipo_Producto" (
  "Id_Tipo_Producto" INTEGER NOT NULL UNIQUE,
  "Nom_Tipo_Producto" VARCHAR(45) NOT NULL UNIQUE,
  PRIMARY KEY ("Id_Tipo_Producto" AUTOINCREMENT)
);
-- -----------------------------------------------------
-- Table "Financiacion"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Financiacion" (
  "Id_Financiacion" INTEGER NOT NULL UNIQUE,
  "Valor_Entrada" INTEGER NULL,
  "Valor_Sin_interes" INTEGER NULL,
  "Valor_Cuota_Sin_interes" INTEGER NULL,
  "Cuotas_Sin_interes" INTEGER NULL,
  "Valor_Con_Interes" INTEGER NULL,
  "Cuotas_Con_Interes" INT NULL,
  "Valor_Cuota_Con_Interes" INTEGER NULL,
  "Valor_Interes" INTEGER NULL,
  "Fecha_Recaudo" DATE NULL,
  "Fk_Predecesor_Financiacion" INTEGER NOT NULL,
  PRIMARY KEY ("Id_Financiacion" AUTOINCREMENT),
  FOREIGN KEY ("Fk_Predecesor_Financiacion")
  REFERENCES "Financiacion" ("Id_Financiacion")
  );
-- -----------------------------------------------------
-- Table "Producto"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Producto" (
  "Id_Producto" INTEGER NOT NULL UNIQUE,
  "Nombre_Producto" VARCHAR(45) NULL,
  "Numero_contrato" INTEGER NULL,
  "Forma_Pago" VARCHAR(45) NULL,
  "Valor_Total" INTEGER NULL,
  "Fecha_Venta" DATE NULL,
  "Observaciones" VARCHAR(255) NULL,
  "Fk_Id_Proyecto" INTEGER NOT NULL,
  "Fk_Id_Tipo_Producto" INTEGER NOT NULL,
  "Fk_Id_Financiacion" INTEGER NOT NULL,
  PRIMARY KEY ("Id_Producto" AUTOINCREMENT),
  FOREIGN KEY ("Fk_Id_Proyecto")
    REFERENCES "Proyecto" ("Id_Proyecto"),
  FOREIGN KEY ("Fk_Id_Tipo_Producto")
    REFERENCES "Tipo_Producto" ("Id_Tipo_Producto"),
  FOREIGN KEY ("Fk_Id_Financiacion")
    REFERENCES "Financiacion" ("Id_Financiacion")
);
-- -----------------------------------------------------
-- Table "Seguimiento"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Seguimiento" (
  "Id_Seguimiento" INTEGER NOT NULL UNIQUE,
  "Fecha_Seguimieto" DATE NOT NULL,
  "Comentario" VARCHAR(45) NOT NULL,
  "Fk_Id_Producto" INTEGER NOT NULL,
  PRIMARY KEY ("Id_Seguimiento" AUTOINCREMENT),
  FOREIGN KEY ("Fk_Id_Producto")
    REFERENCES "Producto" ("Id_Producto")
);
-- -----------------------------------------------------
-- Table "Pagos"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Pagos" (
  "Id_Pagos" INTEGER NOT NULL UNIQUE,
  "Porcentaje" VARCHAR(45) NOT NULL,
  "Numero_Cuota" INTEGER NOT NULL,
  "Fecha_Pago" DATE NOT NULL,
  "Referencia_Pago" VARCHAR(45) NOT NULL,
  "Valor_Pagado" VARCHAR(45) NOT NULL,
  "Descuento" VARCHAR(45) NULL,
  "Valor_Descuento" VARCHAR(45) NULL,
  "Fk_Id_Producto" INTEGER NOT NULL,
  PRIMARY KEY ("Id_Pagos" AUTOINCREMENT),
  FOREIGN KEY ("Fk_Id_Producto")
    REFERENCES "Producto" ("Id_Producto")
);
-- -----------------------------------------------------
-- Table "Usuario"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Usuario" (
  "Id_usuario" INTEGER NOT NULL UNIQUE,
  "Nom_Usuario" VARCHAR(45) NOT NULL,
  "Contraseña" VARCHAR(45) NOT NULL,
  PRIMARY KEY ("Id_usuario" AUTOINCREMENT)
);
-- -----------------------------------------------------
-- Table "Cliente_Producto"
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS "Cliente_Producto" (
  "Pfk_ID_Cliente" INTEGER NOT NULL UNIQUE,
  "Pfk_ID_Producto" INTEGER NOT NULL UNIQUE,
  PRIMARY KEY ("Pfk_ID_Cliente", "Pfk_ID_Producto"),
  FOREIGN KEY ("Pfk_ID_Cliente")
    REFERENCES "Cliente" ("Id_Cliente"),
  FOREIGN KEY ("Pfk_ID_Producto")
    REFERENCES "Producto" ("Id_Producto")
);
COMMIT;