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
