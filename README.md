-- Tabela de Alunos
CREATE TABLE TBL_Alunos (
    Id SERIAL PRIMARY KEY,
    Primeiro_Nome VARCHAR(50) NOT NULL,
    Ultimo_Nome VARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Alunos_Nome UNIQUE (Primeiro_Nome, Ultimo_Nome)
);

-- Tabela de Professores
CREATE TABLE TBL_Professores (
    Id SERIAL PRIMARY KEY,
    Primeiro_Nome VARCHAR(50) NOT NULL,
    Ultimo_Nome VARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Professores_Nome UNIQUE (Primeiro_Nome, Ultimo_Nome)
);

-- Tabela de Coordenadores
CREATE TABLE TBL_Coordenadores (
    Id SERIAL PRIMARY KEY,
    Primeiro_Nome VARCHAR(50) NOT NULL,
    Ultimo_Nome VARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Coordenadores_Nome UNIQUE (Primeiro_Nome, Ultimo_Nome)
);

-- Tabela de Diretores
CREATE TABLE TBL_Diretores (
    Id SERIAL PRIMARY KEY,
    Primeiro_Nome VARCHAR(50) NOT NULL,
    Ultimo_Nome VARCHAR(50) NOT NULL,
    CONSTRAINT UQ_Diretores_Nome UNIQUE (Primeiro_Nome, Ultimo_Nome)
);

-- Tabela de Classes
CREATE TABLE TBL_Classes (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Classes_Nome UNIQUE (Nome)
);

-- Tabela de Salas
CREATE TABLE TBL_Salas (
    Id SERIAL PRIMARY KEY,
    Numero INT NOT NULL,
    Capacidade INT NOT NULL,
    CONSTRAINT UQ_Salas_Numero UNIQUE (Numero)
);

-- Tabela de Turmas
CREATE TABLE TBL_Turmas (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Id_Diretor_Turma INT NOT NULL,
    Id_Sala INT NOT NULL,
    CONSTRAINT UQ_Turmas_Nome UNIQUE (Nome),
    FOREIGN KEY (Id_Diretor_Turma) REFERENCES TBL_Diretores(Id),
    FOREIGN KEY (Id_Sala) REFERENCES TBL_Salas(Id)
);

-- Tabela de Turmas_Classes (Tabela de junção)
CREATE TABLE TBL_Turmas_Classes (
    Id_Turma INT NOT NULL,
    Id_Classe INT NOT NULL,
    CONSTRAINT UQ_Turmas_Classes UNIQUE (Id_Turma, Id_Classe),
    FOREIGN KEY (Id_Turma) REFERENCES TBL_Turmas(Id),
    FOREIGN KEY (Id_Classe) REFERENCES TBL_Classes(Id)
);

-- Tabela de Cursos
CREATE TABLE TBL_Cursos (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Id_Coordenador INT NOT NULL,
    CONSTRAINT UQ_Cursos_Nome UNIQUE (Nome),
    FOREIGN KEY (Id_Coordenador) REFERENCES TBL_Coordenadores(Id)
);

-- Tabela de Disciplinas
CREATE TABLE TBL_Disciplinas (
    Id SERIAL PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Disciplinas_Nome UNIQUE (Nome)
);

-- Tabela de Cursos_Disciplinas (Tabela de junção)
CREATE TABLE TBL_Cursos_Disciplinas (
    Id_Curso INT NOT NULL,
    Id_Disciplina INT NOT NULL,
    CONSTRAINT UQ_Cursos_Disciplinas UNIQUE (Id_Curso, Id_Disciplina),
    FOREIGN KEY (Id_Curso) REFERENCES TBL_Cursos(Id),
    FOREIGN KEY (Id_Disciplina) REFERENCES TBL_Disciplinas(Id)
);

-- Tabela de Professores_Disciplinas (Tabela de junção)
CREATE TABLE TBL_Professores_Disciplinas (
    Id_Professor INT NOT NULL,
    Id_Disciplina INT NOT NULL,
    CONSTRAINT UQ_Professores_Disciplinas UNIQUE (Id_Professor, Id_Disciplina),
    FOREIGN KEY (Id_Professor) REFERENCES TBL_Professores(Id),
    FOREIGN KEY (Id_Disciplina) REFERENCES TBL_Disciplinas(Id)
);

-- Tabela de Provas
CREATE TABLE TBL_Provas (
    Id SERIAL PRIMARY KEY,
    Id_Aluno INT NOT NULL,
    Id_Disciplina INT NOT NULL,
    Trimestre VARCHAR(20) NOT NULL,
    P1 DECIMAL(5, 2) NOT NULL,
    P2 DECIMAL(5, 2) NOT NULL,
    P3 DECIMAL(5, 2) NOT NULL,
    MDF DECIMAL(5, 2) NOT NULL,
    FOREIGN KEY (Id_Aluno) REFERENCES TBL_Alunos(Id),
    FOREIGN KEY (Id_Disciplina) REFERENCES TBL_Disciplinas(Id)
);

-- Tabela de Alunos_Turmas (Tabela de junção)
CREATE TABLE TBL_Alunos_Turmas (
    Id_Aluno INT NOT NULL,
    Id_Turma INT NOT NULL,
    CONSTRAINT UQ_Alunos_Turmas UNIQUE (Id_Aluno, Id_Turma),
    FOREIGN KEY (Id_Aluno) REFERENCES TBL_Alunos(Id),
    FOREIGN KEY (Id_Turma) REFERENCES TBL_Turmas(Id)
);

-- Tabela de Notas
CREATE TABLE TBL_Notas (
    Id SERIAL PRIMARY KEY,
    Id_Aluno INT NOT NULL,
    Id_Disciplina INT NOT NULL,
    Trimestre VARCHAR(20) NOT NULL,
    Nota DECIMAL(5, 2) NOT NULL,
    CONSTRAINT UQ_Notas_Aluno_Disciplina UNIQUE (Id_Aluno, Id_Disciplina, Trimestre),
    FOREIGN KEY (Id_Aluno) REFERENCES TBL_Alunos(Id),
    FOREIGN KEY (Id_Disciplina) REFERENCES TBL_Disciplinas(Id)
);

CREATE TABLE IF NOT EXISTS TBL_Alunos_Turmas (
    Id_Aluno INT NOT NULL,
    Id_Turma INT NOT NULL,
    CONSTRAINT PK_Alunos_Turmas PRIMARY KEY (Id_Aluno, Id_Turma),
    FOREIGN KEY (Id_Aluno) REFERENCES TBL_Alunos(Id),
    FOREIGN KEY (Id_Turma) REFERENCES TBL_Turmas(Id)
);


-- Obter o ID da turma A
WITH TurmaInfo AS (
    SELECT Id FROM TBL_Turmas WHERE Nome = 'Turma A'
)
-- Inserir os alunos na turma A da 12ª classe do curso de Informática
INSERT INTO TBL_Alunos_Turmas (Id_Aluno, Id_Turma)
SELECT Alunos.Id, TurmaInfo.Id
FROM TBL_Alunos Alunos
CROSS JOIN TurmaInfo
WHERE Alunos.Primeiro_Nome IN ('Celson', 'Daniel', 'Mauricio', 'Yuane', 'Jessé', 'Leando', 'Igor', 'Eliezer')
AND Alunos.Ultimo_Nome IN ('Paixão', 'Dala', 'Santana', 'Castro', 'Inglês', 'Gonçalves', 'Cabila', 'Carlos');





-- Cadastre o coordenador Cedrick Kibongo Manson
INSERT INTO TBL_Coordenadores (Primeiro_Nome, Ultimo_Nome)
VALUES ('Cedrick', 'Kibongo Manson');

-- Inserir o curso de Informática associando-o ao coordenador Cedrick Kibongo Manson
INSERT INTO TBL_Cursos (Nome, Id_Coordenador)
VALUES (
    'Informática', 
    (SELECT Id FROM TBL_Coordenadores WHERE Primeiro_Nome = 'Cedrick' AND Ultimo_Nome = 'Kibongo Manson')
);

-- Associar todas as disciplinas ao curso de Informática
INSERT INTO TBL_Cursos_Disciplinas (Id_Curso, Id_Disciplina)
SELECT 
    (SELECT Id FROM TBL_Cursos WHERE Nome = 'Informática'),
    Id 
FROM 
    TBL_Disciplinas;


-- Cadastre as salas de aula de 1 a 26
INSERT INTO TBL_Salas (Numero, Capacidade)
VALUES 
    (1, 30),
    (2, 25),
    (3, 35),
    (4, 20),
    (5, 40),
    (6, 30),
    (7, 25),
    (8, 35),
    (9, 20),
    (10, 40),
    (11, 30),
    (12, 25),
    (13, 35),
    (14, 20),
    (15, 40),
    (16, 30),
    (17, 25),
    (18, 35),
    (19, 20),
    (20, 40),
    (21, 30),
    (22, 25),
    (23, 35),
    (24, 20),
    (25, 40),
    (26, 30);


    

-- Inserir turma A
INSERT INTO TBL_Turmas (Nome, Id_Diretor_Turma, Id_Sala)
VALUES ('Turma A', (SELECT Id FROM TBL_Diretores WHERE Primeiro_Nome = 'Cedrick' AND Ultimo_Nome = 'Kibongo Manson'), 26); -- Supondo que a sala de aula para Turma A seja a sala 26

-- Cadastre os alunos em ordem alfabética

-- Celson Paixão
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Celson', 'Paixão');

-- Daniel Dala
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Daniel', 'Dala');

-- Eliezer Carlos
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Eliezer', 'Carlos');

-- Igor Cabila
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Igor', 'Cabila');

-- Jessé Inglês
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Jessé', 'Inglês');

-- Leando Gonçalves
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Leando', 'Gonçalves');

-- Mauricio Santana
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Mauricio', 'Santana');

-- Yuane Castro
INSERT INTO TBL_Alunos (Primeiro_Nome, Ultimo_Nome)
VALUES ('Yuane', 'Castro');

-- Cadastre as classes de 1 a 13
INSERT INTO TBL_Classes (Nome)
VALUES 
    ('Classe 1'),
    ('Classe 2'),
    ('Classe 3'),
    ('Classe 4'),
    ('Classe 5'),
    ('Classe 6'),
    ('Classe 7'),
    ('Classe 8'),
    ('Classe 9'),
    ('Classe 10'),
    ('Classe 11'),
    ('Classe 12'),
    ('Classe 13');
