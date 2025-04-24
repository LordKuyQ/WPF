-- Insert sample data into the "type" table
INSERT INTO "type" ("id", "name") VALUES
(1, 'Type A'),
(2, 'Type B'),
(3, 'Type C');

-- Insert sample data into the "inventory" table
INSERT INTO "inventory" ("id", "description", "size", "type_id", "price", "model") VALUES
(1, 'Item 1 Description', 10, 1, 1000, 'Model X'),
(2, 'Item 2 Description', 20, 2, 2000, 'Model Y'),
(3, 'Item 3 Description', 30, 3, 3000, 'Model Z');

-- Insert sample data into the "client" table
INSERT INTO "client" ("id", "fio", "telefon", "email") VALUES
(1, 'John Doe', 1234567890, 'john.doe@example.com'),
(2, 'Jane Smith', 9876543210, 'jane.smith@example.com');

-- Insert sample data into the "bron" table
INSERT INTO bron (id, dt_bron, inv_id) VALUES
(1, CONVERT(datetime, '2025-04-24 10:00:00', 120), 1),
(2, CONVERT(datetime, '2025-04-24 11:00:00', 120), 2);

-- Insert sample data into the "skidka" table
INSERT INTO "skidka" ("id", "pers") VALUES
(1, 10),
(2, 20);

-- Insert sample data into the "zakaz" table
INSERT INTO "zakaz" ("id", "inv_id", "time", "clent_id") VALUES
(1, 1, 10, 1),
(2, 2, 10, 2);

-- Insert sample data into the "zakaz_skidka" table
INSERT INTO "zakaz_skidka" ("id", "id_zakaz", "id_skidka") VALUES
(1, 1, 1),
(2, 2, 2);
