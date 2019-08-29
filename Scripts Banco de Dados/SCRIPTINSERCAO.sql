USE MinhaVozManha

INSERT INTO Tipo_Usuario(NOME)
VALUES ('Administrador'),('Usuario');

INSERT INTO usuario (EMAIL, SENHA, ID_TIPO_USUARIO)
VALUES('jeff@admin.com','12345', 1),('gabi@admin.com','12345', 1);

INSERT INTO chamado (NOME, EMAIL, TELEFONE, TITULO, ASSUNTO, DESCRICAO, STATUS, DATA)
VALUES ('Usuario Teste','teste@teste.com','+55(11)9872483773','Titulo Teste','Assunto Teste','Descricao Teste','Pendente','2019-08-05');