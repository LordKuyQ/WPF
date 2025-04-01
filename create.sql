-- �������� ������� ������
CREATE TABLE ������ (
    id BIGINT PRIMARY KEY,
    ����_������ DATE,
    ����_����� DATE,
    ���� BIGINT
);

-- �������� ������� �������
CREATE TABLE ������� (
    id BIGINT PRIMARY KEY,
    ���������� BIGINT,
    ������� BIGINT
);

-- �������� ������� �������
CREATE TABLE ������� (
    id BIGINT PRIMARY KEY,
    ����� BIGINT,
    ������ BIGINT,
    �������� NCHAR(255)
);

-- �������� ������� ������_������
CREATE TABLE ������_������ (
    id BIGINT PRIMARY KEY,
    x BIGINT,
    y BIGINT
);

-- �������� ������� ���������
CREATE TABLE ��������� (
    id BIGINT PRIMARY KEY,
    �������� BIGINT,
    �������� NCHAR(255)
);

-- �������� ������� ������������
CREATE TABLE ������������ (
    id BIGINT PRIMARY KEY,
    ���_������������ NCHAR(255),
    ��� NCHAR(255),
    ������� BIGINT
);

-- �������� ������� ������_��������
CREATE TABLE ������_�������� (
    id_������� BIGINT,
    id_������� BIGINT,
    FOREIGN KEY (id_�������) REFERENCES ������(id),
    FOREIGN KEY (id_�������) REFERENCES �������(id)
);

-- �������� ������� ������_��������
CREATE TABLE ������_�������� (
    id_������� BIGINT,
    id_������� BIGINT,
    FOREIGN KEY (id_�������) REFERENCES �������(id),
    FOREIGN KEY (id_�������) REFERENCES �������(id)
);

-- �������� ������� ������_�������
CREATE TABLE ������_������� (
    id_������� BIGINT,
    id_������ BIGINT,
    FOREIGN KEY (id_�������) REFERENCES �������(id),
    FOREIGN KEY (id_������) REFERENCES ������_������(id)
);

-- �������� ������� ������_���������
CREATE TABLE ������_��������� (
    id_������ BIGINT,
    id_��������� BIGINT,
    FOREIGN KEY (id_������) REFERENCES ������_������(id),
    FOREIGN KEY (id_���������) REFERENCES ���������(id)
);

-- �������� ������� ������_����������
CREATE TABLE ������_���������� (
    id_������� BIGINT,
    id_������������ BIGINT,
    FOREIGN KEY (id_�������) REFERENCES ������(id),
    FOREIGN KEY (id_������������) REFERENCES ������������(id)
);

-- �������� ������� ����������_�������
CREATE TABLE ����������_������� (
    id_������� BIGINT,
    x BIGINT,
    y BIGINT,
    FOREIGN KEY (id_�������) REFERENCES �������(id)
);

-- �������� ������� ����������_�������
CREATE TABLE ����������_������� (
    id_������� BIGINT,
    x BIGINT,
    y BIGINT,
    FOREIGN KEY (id_�������) REFERENCES �������(id)
);
