-- �������� ������� ������
CREATE TABLE [������] (
    [id] INT PRIMARY KEY,
    [����_������] DATE NOT NULL,
    [����_�����] DATE NOT NULL,
    [����] INT NOT NULL
);

-- �������� ������� �������
CREATE TABLE [�������] (
    [id] INT PRIMARY KEY,
    [����������] INT NOT NULL,
    [�������] INT NOT NULL
);

-- �������� ������� �������
CREATE TABLE [�������] (
    [id] INT PRIMARY KEY,
    [�����] INT NOT NULL,
    [������] INT NOT NULL,
    [��������] NVARCHAR(MAX) NOT NULL
);

-- �������� ������� ������_������
CREATE TABLE [������_������] (
    [id] INT PRIMARY KEY,
    [x] INT NOT NULL,
    [y] INT NOT NULL
);

-- �������� ������� ���������
CREATE TABLE [���������] (
    [id] INT PRIMARY KEY,
    [��������] INT NOT NULL,
    [��������] NVARCHAR(MAX) NOT NULL,
    [����������_������] INT NOT NULL,
    [����������] INT NOT NULL
);

-- �������� ������� ������������
CREATE TABLE [������������] (
    [id] INT PRIMARY KEY,
    [���_������������] NVARCHAR(MAX) NOT NULL,
    [���] NVARCHAR(MAX) NOT NULL,
    [������] NVARCHAR(MAX) NOT NULL,
    [�����] NVARCHAR(MAX) NOT NULL,
    [�������] INT NOT NULL
);

-- �������� ������� ������_��������
CREATE TABLE [������_��������] (
    [id] INT PRIMARY KEY,
    [id_�������] INT NOT NULL,
    [id_�������] INT NOT NULL,
    FOREIGN KEY ([id_�������]) REFERENCES [������]([id]),
    FOREIGN KEY ([id_�������]) REFERENCES [�������]([id])
);

-- �������� ������� ������_��������
CREATE TABLE [������_��������] (
    [id] INT PRIMARY KEY,
    [id_�������] INT NOT NULL,
    [id_�������] INT NOT NULL,
    FOREIGN KEY ([id_�������]) REFERENCES [�������]([id]),
    FOREIGN KEY ([id_�������]) REFERENCES [�������]([id])
);

-- �������� ������� ������_�������
CREATE TABLE [������_�������] (
    [id] INT PRIMARY KEY,
    [id_�������] INT NOT NULL,
    [id_������] INT NOT NULL,
    FOREIGN KEY ([id_�������]) REFERENCES [�������]([id]),
    FOREIGN KEY ([id_������]) REFERENCES [������_������]([id])
);

-- �������� ������� ������_���������
CREATE TABLE [������_���������] (
    [id] INT PRIMARY KEY,
    [id_������] INT NOT NULL,
    [id_���������] INT NOT NULL,
    FOREIGN KEY ([id_������]) REFERENCES [������_������]([id]),
    FOREIGN KEY ([id_���������]) REFERENCES [���������]([id])
);

-- �������� ������� ������_����������
CREATE TABLE [������_����������] (
    [id] INT PRIMARY KEY,
    [id_�������] INT NOT NULL,
    [id_������������] INT NOT NULL,
    FOREIGN KEY ([id_�������]) REFERENCES [������]([id]),
    FOREIGN KEY ([id_������������]) REFERENCES [������������]([id])
);

-- �������� ������� ����������_�������
CREATE TABLE [����������_�������] (
    [id] INT PRIMARY KEY,
    [id_�������] INT NOT NULL,
    [x] INT NOT NULL,
    [y] INT NOT NULL,
    FOREIGN KEY ([id_�������]) REFERENCES [�������]([id])
);

-- �������� ������� ����������_�������
CREATE TABLE [����������_�������] (
    [id] INT PRIMARY KEY,
    [id_�������] INT NOT NULL,
    [x] INT NOT NULL,
    [y] INT NOT NULL,
    FOREIGN KEY ([id_�������]) REFERENCES [�������]([id])
);
