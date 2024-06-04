
SELECT * FROM Usuario

INSERT INTO Usuario VALUES('Jovem@teste.com', 'JovemTeste', 'SenhaForteJovem@', 1, GETDATE(), NULL);
INSERT INTO Usuario VALUES('teste1@teste.com', 'Teste01', 'SenhaForteTeste@', 1, GETDATE(), NULL);

SELECT * FROM Instrutor

SELECT * FROM Alternativa

SELECT * FROM Questao

SELECT * FROM ConteudoProgramatico

SELECT * FROM Curso C
INNER JOIN ConteudoProgramatico CP
ON C.Id = CP.CursoId

SELECT * FROM Prova

SELECT * FROM Treinamento

SELECT * FROM ListaPresenca

SELECT * FROM Curso

INSERT INTO Curso VALUES (NEWID(), 'CURSO 1', 'LOGO 1', 8, 4, 6, 1, GETDATE(), NULL, 'teste1@teste.com');

INSERT INTO Prova VALUES (NEWID(), 1, GETDATE(), NULL, '9967062F-4B62-4980-86B9-DC3A0F255C23', 'teste1@teste.com');

INSERT INTO Questao VALUES (NEWID(), '1) MORRO DO DENDÊ?', 1, '5255B854-484E-4B3A-9B24-C1AC27EF9AE0', 'teste1@teste.com');
