CREATE TABLE "inventory"(
    "id" BIGINT NOT NULL,
    "description" VARCHAR(255) NOT NULL,
    "size" BIGINT NOT NULL,
    "type_id" BIGINT NOT NULL,
    "price" BIGINT NOT NULL,
    "model" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "inventory" ADD CONSTRAINT "inventory_id_primary" PRIMARY KEY("id");
CREATE TABLE "type"(
    "id" BIGINT NOT NULL,
    "name" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "type" ADD CONSTRAINT "type_id_primary" PRIMARY KEY("id");
CREATE TABLE "bron"(
    "id" BIGINT NOT NULL,
    "dt_bron" DATETIME NOT NULL,
    "inv_id" BIGINT NOT NULL
);
ALTER TABLE
    "bron" ADD CONSTRAINT "bron_id_primary" PRIMARY KEY("id");
CREATE TABLE "skidka"(
    "id" BIGINT NOT NULL,
    "pers" BIGINT NOT NULL
);
ALTER TABLE
    "skidka" ADD CONSTRAINT "skidka_id_primary" PRIMARY KEY("id");
CREATE TABLE "zakaz"(
    "id" BIGINT NOT NULL,
    "inv_id" BIGINT NOT NULL,
    "time" BIGINT NOT NULL,
    "clent_id" BIGINT NOT NULL
);
ALTER TABLE
    "zakaz" ADD CONSTRAINT "zakaz_id_primary" PRIMARY KEY("id");
CREATE TABLE "client"(
    "id" BIGINT NOT NULL,
    "fio" VARCHAR(255) NOT NULL,
    "telefon" BIGINT NOT NULL,
    "email" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "client" ADD CONSTRAINT "client_id_primary" PRIMARY KEY("id");
CREATE TABLE "zakaz_skidka"(
    "id" BIGINT NOT NULL,
    "id_zakaz" BIGINT NOT NULL,
    "id_skidka" BIGINT NOT NULL
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