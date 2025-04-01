-- Создание таблицы Проект
CREATE TABLE Проект (
    id BIGINT PRIMARY KEY,
    дата_начала DATE,
    дата_конца DATE,
    цена BIGINT
);

-- Создание таблицы Площадь
CREATE TABLE Площадь (
    id BIGINT PRIMARY KEY,
    координаты BIGINT,
    площадь BIGINT
);

-- Создание таблицы Профиль
CREATE TABLE Профиль (
    id BIGINT PRIMARY KEY,
    длина BIGINT,
    высота BIGINT,
    описание NCHAR(255)
);

-- Создание таблицы Пункты_наблюд
CREATE TABLE Пункты_наблюд (
    id BIGINT PRIMARY KEY,
    x BIGINT,
    y BIGINT
);

-- Создание таблицы Измерения
CREATE TABLE Измерения (
    id BIGINT PRIMARY KEY,
    давление BIGINT,
    описание NCHAR(255)
);

-- Создание таблицы Пользователь
CREATE TABLE Пользователь (
    id BIGINT PRIMARY KEY,
    тип_пользователя NCHAR(255),
    ФИО NCHAR(255),
    Телефон BIGINT
);

-- Создание таблицы список_площадей
CREATE TABLE список_площадей (
    id_проекта BIGINT,
    id_площади BIGINT,
    FOREIGN KEY (id_проекта) REFERENCES Проект(id),
    FOREIGN KEY (id_площади) REFERENCES Площадь(id)
);

-- Создание таблицы список_профилей
CREATE TABLE список_профилей (
    id_площади BIGINT,
    id_профиля BIGINT,
    FOREIGN KEY (id_площади) REFERENCES Площадь(id),
    FOREIGN KEY (id_профиля) REFERENCES Профиль(id)
);

-- Создание таблицы список_пунктов
CREATE TABLE список_пунктов (
    id_профиля BIGINT,
    id_пункта BIGINT,
    FOREIGN KEY (id_профиля) REFERENCES Профиль(id),
    FOREIGN KEY (id_пункта) REFERENCES Пункты_наблюд(id)
);

-- Создание таблицы список_измерений
CREATE TABLE список_измерений (
    id_пункта BIGINT,
    id_измерения BIGINT,
    FOREIGN KEY (id_пункта) REFERENCES Пункты_наблюд(id),
    FOREIGN KEY (id_измерения) REFERENCES Измерения(id)
);

-- Создание таблицы список_участников
CREATE TABLE список_участников (
    id_проекта BIGINT,
    id_пользователя BIGINT,
    FOREIGN KEY (id_проекта) REFERENCES Проект(id),
    FOREIGN KEY (id_пользователя) REFERENCES Пользователь(id)
);

-- Создание таблицы координаты_площади
CREATE TABLE координаты_площади (
    id_площади BIGINT,
    x BIGINT,
    y BIGINT,
    FOREIGN KEY (id_площади) REFERENCES Площадь(id)
);

-- Создание таблицы координаты_профиля
CREATE TABLE координаты_профиля (
    id_площади BIGINT,
    x BIGINT,
    y BIGINT,
    FOREIGN KEY (id_площади) REFERENCES Площадь(id)
);
