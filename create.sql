-- Создание таблицы Проект
CREATE TABLE [Проект] (
    [id] INT PRIMARY KEY,
    [дата_начала] DATE NOT NULL,
    [дата_конца] DATE NOT NULL,
    [цена] INT NOT NULL
);

-- Создание таблицы Площадь
CREATE TABLE [Площадь] (
    [id] INT PRIMARY KEY,
    [координаты] INT NOT NULL,
    [площадь] INT NOT NULL
);

-- Создание таблицы Профиль
CREATE TABLE [Профиль] (
    [id] INT PRIMARY KEY,
    [длина] INT NOT NULL,
    [высота] INT NOT NULL,
    [описание] NVARCHAR(MAX) NOT NULL
);

-- Создание таблицы Пункты_наблюд
CREATE TABLE [Пункты_наблюд] (
    [id] INT PRIMARY KEY,
    [x] INT NOT NULL,
    [y] INT NOT NULL
);

-- Создание таблицы Измерения
CREATE TABLE [Измерения] (
    [id] INT PRIMARY KEY,
    [давление] INT NOT NULL,
    [описание] NVARCHAR(MAX) NOT NULL,
    [абсолютная_высота] INT NOT NULL,
    [расстояние] INT NOT NULL
);

-- Создание таблицы Пользователь
CREATE TABLE [Пользователь] (
    [id] INT PRIMARY KEY,
    [тип_пользователя] NVARCHAR(MAX) NOT NULL,
    [ФИО] NVARCHAR(MAX) NOT NULL,
    [пароль] NVARCHAR(MAX) NOT NULL,
    [емайл] NVARCHAR(MAX) NOT NULL,
    [телефон] INT NOT NULL
);

-- Создание таблицы список_площадей
CREATE TABLE [список_площадей] (
    [id] INT PRIMARY KEY,
    [id_проекта] INT NOT NULL,
    [id_площади] INT NOT NULL,
    FOREIGN KEY ([id_проекта]) REFERENCES [Проект]([id]),
    FOREIGN KEY ([id_площади]) REFERENCES [Площадь]([id])
);

-- Создание таблицы список_профилей
CREATE TABLE [список_профилей] (
    [id] INT PRIMARY KEY,
    [id_площади] INT NOT NULL,
    [id_профиля] INT NOT NULL,
    FOREIGN KEY ([id_площади]) REFERENCES [Площадь]([id]),
    FOREIGN KEY ([id_профиля]) REFERENCES [Профиль]([id])
);

-- Создание таблицы список_пунктов
CREATE TABLE [список_пунктов] (
    [id] INT PRIMARY KEY,
    [id_профиля] INT NOT NULL,
    [id_пункта] INT NOT NULL,
    FOREIGN KEY ([id_профиля]) REFERENCES [Профиль]([id]),
    FOREIGN KEY ([id_пункта]) REFERENCES [Пункты_наблюд]([id])
);

-- Создание таблицы список_измерений
CREATE TABLE [список_измерений] (
    [id] INT PRIMARY KEY,
    [id_пункта] INT NOT NULL,
    [id_измерения] INT NOT NULL,
    FOREIGN KEY ([id_пункта]) REFERENCES [Пункты_наблюд]([id]),
    FOREIGN KEY ([id_измерения]) REFERENCES [Измерения]([id])
);

-- Создание таблицы список_участников
CREATE TABLE [список_участников] (
    [id] INT PRIMARY KEY,
    [id_проекта] INT NOT NULL,
    [id_пользователя] INT NOT NULL,
    FOREIGN KEY ([id_проекта]) REFERENCES [Проект]([id]),
    FOREIGN KEY ([id_пользователя]) REFERENCES [Пользователь]([id])
);

-- Создание таблицы координаты_площади
CREATE TABLE [координаты_площади] (
    [id] INT PRIMARY KEY,
    [id_площади] INT NOT NULL,
    [x] INT NOT NULL,
    [y] INT NOT NULL,
    FOREIGN KEY ([id_площади]) REFERENCES [Площадь]([id])
);

-- Создание таблицы координаты_профиля
CREATE TABLE [координаты_профиля] (
    [id] INT PRIMARY KEY,
    [id_площади] INT NOT NULL,
    [x] INT NOT NULL,
    [y] INT NOT NULL,
    FOREIGN KEY ([id_площади]) REFERENCES [Площадь]([id])
);
