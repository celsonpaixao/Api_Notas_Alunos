CREATE TABLE IF NOT EXISTS tbl_classe (
id SERIAL PRIMARY KEY,
classe VARCHAR(25) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_coordenador (
id SERIAL PRIMARY KEY,
primeiro_nome VARCHAR(25) NOT NULL,
ultimo_nome VARCHAR(25) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_professor (
id SERIAL PRIMARY KEY,
primeiro_nome VARCHAR(25) NOT NULL,
ultimo_nome VARCHAR(25) NOT NULL,
numero_bi VARCHAR(25) NOT NULL,
data_nascimento DATE NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_director_turma (
id SERIAL PRIMARY KEY,
primeiro_nome VARCHAR(25) NOT NULL,
ultimo_nome VARCHAR(25) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_sala (
id SERIAL PRIMARY KEY,
sala VARCHAR(25) NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_disciplina (
id SERIAL PRIMARY KEY,
id_professor INTEGER NOT NULL,
disciplina VARCHAR(150) NOT NULL,
FOREIGN KEY (id_professor) REFERENCES tbl_professor(id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS tbl_curso (
id SERIAL PRIMARY KEY,
curso VARCHAR(100) NOT NULL,
id_coordenador INTEGER NOT NULL,
FOREIGN KEY (id_coordenador) REFERENCES tbl_coordenador(id)
);

CREATE TABLE IF NOT EXISTS tbl_aluno (
id SERIAL PRIMARY KEY,
primeiro_nome VARCHAR(25) NOT NULL,
ultimo_nome VARCHAR(25) NOT NULL,
numero_bi VARCHAR(25) NOT NULL,
data_nascimento DATE NOT NULL
);

CREATE TABLE IF NOT EXISTS tbl_turma (
id SERIAL PRIMARY KEY,
id_director INTEGER NOT NULL,
id_sala INTEGER NOT NULL,
turma VARCHAR(25) NOT NULL,
id_curso INTEGER,
FOREIGN KEY (id_director) REFERENCES tbl_director_turma(id),
FOREIGN KEY (id_sala) REFERENCES tbl_sala(id),
FOREIGN KEY (id_curso) REFERENCES tbl_curso(id)
);

CREATE TABLE IF NOT EXISTS tbl_curso_classe (
id SERIAL PRIMARY KEY,
id_curso INTEGER NOT NULL,
id_classe INTEGER NOT NULL,
FOREIGN KEY (id_curso) REFERENCES tbl_curso(id),
FOREIGN KEY (id_classe) REFERENCES tbl_classe(id)
);

CREATE TABLE IF NOT EXISTS tbl_curso_disciplina (
id SERIAL PRIMARY KEY,
id_curso INTEGER NOT NULL,
id_disciplina INTEGER NOT NULL,
FOREIGN KEY (id_curso) REFERENCES tbl_curso(id),
FOREIGN KEY (id_disciplina) REFERENCES tbl_disciplina(id)
);

CREATE TABLE IF NOT EXISTS tbl_aluno_turma (
id SERIAL PRIMARY KEY,
id_aluno INTEGER NOT NULL,
id_turma INTEGER NOT NULL,
FOREIGN KEY (id_aluno) REFERENCES tbl_aluno(id),
FOREIGN KEY (id_turma) REFERENCES tbl_turma(id)
);

CREATE TABLE IF NOT EXISTS tbl_prova (
id SERIAL PRIMARY KEY,
p1 NUMERIC NOT NULL,
p2 NUMERIC NOT NULL,
pt NUMERIC NOT NULL,
id_aluno INTEGER NOT NULL,
id_disciplina INTEGER NOT NULL,
id_classe INTEGER NOT NULL,
trimestre VARCHAR(25),
mdf NUMERIC,
FOREIGN KEY (id_aluno) REFERENCES tbl_aluno(id),
FOREIGN KEY (id_disciplina) REFERENCES tbl_disciplina(id),
FOREIGN KEY (id_classe) REFERENCES tbl_classe(id)
);

CREATE TABLE IF NOT EXISTS tbl_nota (
id SERIAL PRIMARY KEY,
id_prova INTEGER NOT NULL,
FOREIGN KEY (id_prova) REFERENCES tbl_prova(id)
);



-- Exemplo de inserção para classes de 1 a 13
INSERT INTO tbl_classe (classe) VALUES
  ('1ª Classe'),
  ('2ª Classe'),
  ('3ª Classe'),
  ('4ª Classe'),
  ('5ª Classe'),
  ('6ª Classe'),
  ('7ª Classe'),
  ('8ª Classe'),
  ('9ª Classe'),
  ('10ª Classe'),
  ('11ª Classe'),
  ('12ª Classe'),
  ('13ª Classe');



-- Inserir professores
INSERT INTO tbl_professor (primeiro_nome, ultimo_nome, numero_bi, data_nascimento) VALUES
  ('Lecárcio', 'Palma', '123456789', TO_DATE('1980-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Faustino', 'Keya', '987654321', TO_DATE('1982-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Márcia', 'Pereira', '456789012', TO_DATE('1975-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Cedrik Kibongo', 'Mansoni', '567890123', TO_DATE('1988-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Francisco', 'Capassola', '789012345', TO_DATE('1983-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Luís', 'Marcolino', '890123456', TO_DATE('1978-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Tavares', 'Garcia', '901234567', TO_DATE('1985-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Ilídio Júlio', 'Mendes', '234567890', TO_DATE('1987-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM());

-- Associar professores a disciplinas

-- Inserir coordenador Cedrick
INSERT INTO tbl_coordenador (primeiro_nome, ultimo_nome) VALUES
  ('Cedrik', 'Kibongo Mansoni');

-- Inserir curso de informática
INSERT INTO tbl_curso (curso, id_coordenador) VALUES
  ('Informática', (SELECT id FROM tbl_coordenador WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni'));


INSERT INTO tbl_disciplina (id_professor, disciplina) VALUES
  (1, 'MATEMÁTICA'),
  (2, 'FÍSICA'),
  (3, 'ORGANIZAÇÃO E GESTÃO INDUSTRIAL'),
  (4, 'TÉCNICAS E LING. DE PROGRAMAÇÃO'),
  (5, 'SIST. DE EXPLOR. E ARQ. DE COMPUTADORES'),
  (6, 'TÉCNICAS DE REPARAÇÃO DE EQUIP. INFORM.'),
  (7, 'PROJECTO TECNOLÓGICO'),
  (8, 'EMPREENDEDORISMO');
-- Associar professores a cursos
-- (Assumindo que todos os professores estão associados ao mesmo curso no exemplo)


INSERT INTO tbl_curso_disciplina (id_curso, id_disciplina) VALUES
  (1, 1),
  (1, 2),
  (1, 3),
  (1, 4),
  (1, 5),
  (1, 6),
  (1, 7),
  (1, 8);


  -- Inserir 26 salas
INSERT INTO tbl_sala (sala) VALUES
  ('Sala 1'),
  ('Sala 2'),
  ('Sala 3'),
  ('Sala 4'),
  ('Sala 5'),
  ('Sala 6'),
  ('Sala 7'),
  ('Sala 8'),
  ('Sala 9'),
  ('Sala 10'),
  ('Sala 11'),
  ('Sala 12'),
  ('Sala 13'),
  ('Sala 14'),
  ('Sala 15'),
  ('Sala 16'),
  ('Sala 17'),
  ('Sala 18'),
  ('Sala 19'),
  ('Sala 20'),
  ('Sala 21'),
  ('Sala 22'),
  ('Sala 23'),
  ('Sala 24'),
  ('Sala 25'),
  ('Sala 26');


-- Inserir diretor Cedrik como diretor de turma
INSERT INTO tbl_director_turma (primeiro_nome, ultimo_nome) VALUES
  ('Cedrik', 'Kibongo Mansoni');

-- Inserir turma "A" para o curso de informática na 12ª classe
INSERT INTO tbl_turma (id_director, id_sala, turma, id_curso) VALUES
  ((SELECT id FROM tbl_director_turma WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni'),
   1, -- Substitua pelo ID da sala desejada
   'A',
   (SELECT id FROM tbl_curso WHERE curso = 'Informática' AND id_coordenador = (SELECT id FROM tbl_coordenador WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni')));


   -- Inserir alunos
INSERT INTO tbl_aluno (primeiro_nome, ultimo_nome, numero_bi, data_nascimento) VALUES
  ('Celso', 'Paixão', '123456789', TO_DATE('2005-01-01', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Yuane', 'Castro', '987654321', TO_DATE('2004-02-15', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Jessé', 'Inglês', '456789012', TO_DATE('2004-03-22', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Igor', 'Cabila', '567890123', TO_DATE('2004-05-10', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM()),
  ('Maurício', 'Santana', '789012345', TO_DATE('2004-08-07', 'YYYY-MM-DD') + INTERVAL '90 days' * RANDOM());


-- Associar alunos à turma "A" na 12ª classe no curso de informática
INSERT INTO tbl_aluno_turma (id_aluno, id_turma) VALUES
  ((SELECT id FROM tbl_aluno WHERE primeiro_nome = 'Celso' AND ultimo_nome = 'Paixão'),
   (SELECT id FROM tbl_turma WHERE turma = 'A' AND id_curso = (SELECT id FROM tbl_curso WHERE curso = 'Informática' AND id_coordenador = (SELECT id FROM tbl_coordenador WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni')))),
  
  ((SELECT id FROM tbl_aluno WHERE primeiro_nome = 'Yuane' AND ultimo_nome = 'Castro'),
   (SELECT id FROM tbl_turma WHERE turma = 'A' AND id_curso = (SELECT id FROM tbl_curso WHERE curso = 'Informática' AND id_coordenador = (SELECT id FROM tbl_coordenador WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni')))),
  
  ((SELECT id FROM tbl_aluno WHERE primeiro_nome = 'Jessé' AND ultimo_nome = 'Inglês'),
   (SELECT id FROM tbl_turma WHERE turma = 'A' AND id_curso = (SELECT id FROM tbl_curso WHERE curso = 'Informática' AND id_coordenador = (SELECT id FROM tbl_coordenador WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni')))),
  
  ((SELECT id FROM tbl_aluno WHERE primeiro_nome = 'Igor' AND ultimo_nome = 'Cabila'),
   (SELECT id FROM tbl_turma WHERE turma = 'A' AND id_curso = (SELECT id FROM tbl_curso WHERE curso = 'Informática' AND id_coordenador = (SELECT id FROM tbl_coordenador WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni')))),
  
  ((SELECT id FROM tbl_aluno WHERE primeiro_nome = 'Maurício' AND ultimo_nome = 'Santana'),
   (SELECT id FROM tbl_turma WHERE turma = 'A' AND id_curso = (SELECT id FROM tbl_curso WHERE curso = 'Informática' AND id_coordenador = (SELECT id FROM tbl_coordenador WHERE primeiro_nome = 'Cedrik' AND ultimo_nome = 'Kibongo Mansoni'))));





