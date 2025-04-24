CREATE TABLE "inventory"(
    "id" INT NOT NULL,
    "description" VARCHAR(255) NOT NULL,
    "size" INT NOT NULL,
    "type_id" INT NOT NULL,
    "price" INT NOT NULL,
    "model" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "inventory" ADD CONSTRAINT "inventory_id_primary" PRIMARY KEY("id");
CREATE TABLE "type"(
    "id" INT NOT NULL,
    "name" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "type" ADD CONSTRAINT "type_id_primary" PRIMARY KEY("id");
CREATE TABLE "bron"(
    "id" INT NOT NULL,
    "dt_bron" DATETIME NOT NULL,
    "inv_id" INT NOT NULL
);
ALTER TABLE
    "bron" ADD CONSTRAINT "bron_id_primary" PRIMARY KEY("id");
CREATE TABLE "skidka"(
    "id" INT NOT NULL,
    "pers" INT NOT NULL
);
ALTER TABLE
    "skidka" ADD CONSTRAINT "skidka_id_primary" PRIMARY KEY("id");
CREATE TABLE "zakaz"(
    "id" INT NOT NULL,
    "inv_id" INT NOT NULL,
    "time" INT NOT NULL,
    "clent_id" INT NOT NULL
);
ALTER TABLE
    "zakaz" ADD CONSTRAINT "zakaz_id_primary" PRIMARY KEY("id");
CREATE TABLE "client"(
    "id" INT NOT NULL,
    "fio" VARCHAR(255) NOT NULL,
    "telefon" BIGINT NOT NULL,
    "email" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "client" ADD CONSTRAINT "client_id_primary" PRIMARY KEY("id");
CREATE TABLE "zakaz_skidka"(
    "id" INT NOT NULL,
    "id_zakaz" INT NOT NULL,
    "id_skidka" INT NOT NULL
);
ALTER TABLE
    "zakaz_skidka" ADD CONSTRAINT "zakaz_skidka_id_primary" PRIMARY KEY("id");
ALTER TABLE
    "zakaz_skidka" ADD CONSTRAINT "zakaz_skidka_id_zakaz_foreign" FOREIGN KEY("id_zakaz") REFERENCES "zakaz"("id");
ALTER TABLE
    "zakaz" ADD CONSTRAINT "zakaz_clent_id_foreign" FOREIGN KEY("clent_id") REFERENCES "client"("id");
ALTER TABLE
    "zakaz" ADD CONSTRAINT "zakaz_inv_id_foreign" FOREIGN KEY("inv_id") REFERENCES "inventory"("id");
ALTER TABLE
    "inventory" ADD CONSTRAINT "inventory_type_id_foreign" FOREIGN KEY("type_id") REFERENCES "type"("id");
ALTER TABLE
    "bron" ADD CONSTRAINT "bron_inv_id_foreign" FOREIGN KEY("inv_id") REFERENCES "inventory"("id");
ALTER TABLE
    "zakaz_skidka" ADD CONSTRAINT "zakaz_skidka_id_skidka_foreign" FOREIGN KEY("id_skidka") REFERENCES "skidka"("id");