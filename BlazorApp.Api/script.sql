IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Aluno] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] NVARCHAR(255) NOT NULL,
    [Cpf] VARCHAR(14) NOT NULL,
    [Rg] VARCHAR(12) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
    [Telefone] VARCHAR(15) NOT NULL,
    [Assinatura] VARCHAR(255) NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [Status] int NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Aluno] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Curso] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] NVARCHAR(255) NOT NULL,
    [Logo] VARCHAR(255) NOT NULL,
    [CargaHorariaInicial] SMALLINT NOT NULL,
    [CargaHorariaPeriodico] SMALLINT NOT NULL,
    [Validade] SMALLINT NOT NULL,
    [Status] SMALLINT NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Empresa] (
    [Id] uniqueidentifier NOT NULL,
    [CNPJ] NVARCHAR(19) NOT NULL,
    [RazaoSocial] NVARCHAR(255) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
    [Status] SMALLINT NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Empresa] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Instrutor] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] NVARCHAR(255) NOT NULL,
    [Cpf] VARCHAR(14) NOT NULL,
    [Especializacao] NVARCHAR(80) NOT NULL,
    [Registro] NVARCHAR(80) NOT NULL,
    [Email] VARCHAR(160) NOT NULL,
    [Telefone] VARCHAR(15) NOT NULL,
    [Assinatura] VARCHAR(255) NOT NULL,
    [Status] SMALLINT NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Instrutor] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuario] (
    [UsuarioId] VARCHAR(255) NOT NULL,
    [Nome] NVARCHAR(255) NOT NULL,
    [Senha] NVARCHAR(32) NOT NULL,
    [IsAdmin] SMALLINT NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [Status] int NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([UsuarioId])
);
GO

CREATE TABLE [ConteudoProgramatico] (
    [Id] uniqueidentifier NOT NULL,
    [Assunto] NVARCHAR(255) NOT NULL,
    [CargaHoraria] SMALLINT NOT NULL,
    [Status] SMALLINT NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [CursoId] uniqueidentifier NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ConteudoProgramatico] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ConteudoProgramatico_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Curso] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Prova] (
    [Id] uniqueidentifier NOT NULL,
    [Status] SMALLINT NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [CursoId] uniqueidentifier NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Prova] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Prova_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Curso] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Treinamento] (
    [Id] uniqueidentifier NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [Tipo] SMALLINT NOT NULL,
    [Situacao] SMALLINT NOT NULL,
    [Status] SMALLINT NOT NULL,
    [CursoId] uniqueidentifier NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Treinamento] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Treinamento_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Curso] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AlunoEmpresa] (
    [AlunosId] uniqueidentifier NOT NULL,
    [EmpresasId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AlunoEmpresa] PRIMARY KEY ([AlunosId], [EmpresasId]),
    CONSTRAINT [FK_AlunoEmpresa_Aluno_AlunosId] FOREIGN KEY ([AlunosId]) REFERENCES [Aluno] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlunoEmpresa_Empresa_EmpresasId] FOREIGN KEY ([EmpresasId]) REFERENCES [Empresa] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [EnderecoEmpresa] (
    [EmpresaId] uniqueidentifier NOT NULL,
    [CEP] VARCHAR(9) NOT NULL,
    [Estado] VARCHAR(48) NOT NULL,
    [Cidade] VARCHAR(48) NOT NULL,
    [Bairro] VARCHAR(160) NOT NULL,
    [NomeRua] VARCHAR(255) NOT NULL,
    [Numero] VARCHAR(5) NOT NULL,
    [Complemento] NVARCHAR(160) NULL,
    [Status] SMALLINT NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_EnderecoEmpresa] PRIMARY KEY ([EmpresaId]),
    CONSTRAINT [FK_EnderecoEmpresa_Empresa_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresa] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TelefoneEmpresa] (
    [EmpresaId] uniqueidentifier NOT NULL,
    [NroTelefone] VARCHAR(15) NOT NULL,
    [Status] SMALLINT NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TelefoneEmpresa] PRIMARY KEY ([EmpresaId], [NroTelefone]),
    CONSTRAINT [FK_TelefoneEmpresa_Empresa_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Empresa] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AlunoUsuario] (
    [AlunosId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_AlunoUsuario] PRIMARY KEY ([AlunosId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_AlunoUsuario_Aluno_AlunosId] FOREIGN KEY ([AlunosId]) REFERENCES [Aluno] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlunoUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [CursoUsuario] (
    [CursosId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_CursoUsuario] PRIMARY KEY ([CursosId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_CursoUsuario_Curso_CursosId] FOREIGN KEY ([CursosId]) REFERENCES [Curso] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CursoUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [EmpresaUsuario] (
    [EmpresasId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_EmpresaUsuario] PRIMARY KEY ([EmpresasId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_EmpresaUsuario_Empresa_EmpresasId] FOREIGN KEY ([EmpresasId]) REFERENCES [Empresa] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmpresaUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [InstrutorUsuario] (
    [InstrutoresId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_InstrutorUsuario] PRIMARY KEY ([InstrutoresId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_InstrutorUsuario_Instrutor_InstrutoresId] FOREIGN KEY ([InstrutoresId]) REFERENCES [Instrutor] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InstrutorUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ConteudoProgramaticoUsuario] (
    [ConteudosProgramaticosId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_ConteudoProgramaticoUsuario] PRIMARY KEY ([ConteudosProgramaticosId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_ConteudoProgramaticoUsuario_ConteudoProgramatico_ConteudosProgramaticosId] FOREIGN KEY ([ConteudosProgramaticosId]) REFERENCES [ConteudoProgramatico] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ConteudoProgramaticoUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ProvaUsuario] (
    [ProvasId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_ProvaUsuario] PRIMARY KEY ([ProvasId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_ProvaUsuario_Prova_ProvasId] FOREIGN KEY ([ProvasId]) REFERENCES [Prova] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ProvaUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Questao] (
    [Id] uniqueidentifier NOT NULL,
    [Conteudo] NVARCHAR(255) NOT NULL,
    [Status] SMALLINT NOT NULL,
    [ProvaId] uniqueidentifier NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Questao] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Questao_Prova_ProvaId] FOREIGN KEY ([ProvaId]) REFERENCES [Prova] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AlunoTreinamento] (
    [AlunosId] uniqueidentifier NOT NULL,
    [TreinamentosId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AlunoTreinamento] PRIMARY KEY ([AlunosId], [TreinamentosId]),
    CONSTRAINT [FK_AlunoTreinamento_Aluno_AlunosId] FOREIGN KEY ([AlunosId]) REFERENCES [Aluno] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlunoTreinamento_Treinamento_TreinamentosId] FOREIGN KEY ([TreinamentosId]) REFERENCES [Treinamento] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Certificado] (
    [TreinamentoId] uniqueidentifier NOT NULL,
    [Codigo] VARCHAR(32) NOT NULL,
    [DataInicioCertificado] datetime2 NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [Situacao] SMALLINT NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Certificado] PRIMARY KEY ([TreinamentoId], [Codigo]),
    CONSTRAINT [FK_Certificado_Treinamento_TreinamentoId] FOREIGN KEY ([TreinamentoId]) REFERENCES [Treinamento] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [EmpresaTreinamento] (
    [EmpresasId] uniqueidentifier NOT NULL,
    [TreinamentosId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EmpresaTreinamento] PRIMARY KEY ([EmpresasId], [TreinamentosId]),
    CONSTRAINT [FK_EmpresaTreinamento_Empresa_EmpresasId] FOREIGN KEY ([EmpresasId]) REFERENCES [Empresa] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmpresaTreinamento_Treinamento_TreinamentosId] FOREIGN KEY ([TreinamentosId]) REFERENCES [Treinamento] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [InstrutorTreinamento] (
    [InstrutoresId] uniqueidentifier NOT NULL,
    [TreinamentosId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_InstrutorTreinamento] PRIMARY KEY ([InstrutoresId], [TreinamentosId]),
    CONSTRAINT [FK_InstrutorTreinamento_Instrutor_InstrutoresId] FOREIGN KEY ([InstrutoresId]) REFERENCES [Instrutor] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_InstrutorTreinamento_Treinamento_TreinamentosId] FOREIGN KEY ([TreinamentosId]) REFERENCES [Treinamento] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ListaPresenca] (
    [TreinamentoId] uniqueidentifier NOT NULL,
    [Codigo] VARCHAR(32) NOT NULL,
    [DataCriacao] datetime2 NULL,
    [DataAlteracao] datetime2 NULL,
    [DataInicioTreinamento] datetime2 NULL,
    [Situacao] SMALLINT NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ListaPresenca] PRIMARY KEY ([TreinamentoId]),
    CONSTRAINT [FK_ListaPresenca_Treinamento_TreinamentoId] FOREIGN KEY ([TreinamentoId]) REFERENCES [Treinamento] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TreinamentoUsuario] (
    [TreinamentosId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_TreinamentoUsuario] PRIMARY KEY ([TreinamentosId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_TreinamentoUsuario_Treinamento_TreinamentosId] FOREIGN KEY ([TreinamentosId]) REFERENCES [Treinamento] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TreinamentoUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [EnderecoEmpresaUsuario] (
    [EnderecosEmpresasEmpresaId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_EnderecoEmpresaUsuario] PRIMARY KEY ([EnderecosEmpresasEmpresaId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_EnderecoEmpresaUsuario_EnderecoEmpresa_EnderecosEmpresasEmpresaId] FOREIGN KEY ([EnderecosEmpresasEmpresaId]) REFERENCES [EnderecoEmpresa] ([EmpresaId]) ON DELETE CASCADE,
    CONSTRAINT [FK_EnderecoEmpresaUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [TelefoneEmpresaUsuario] (
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    [TelefonesEmpresasEmpresaId] uniqueidentifier NOT NULL,
    [TelefonesEmpresasNroTelefone] VARCHAR(15) NOT NULL,
    CONSTRAINT [PK_TelefoneEmpresaUsuario] PRIMARY KEY ([UsuariosUsuarioId], [TelefonesEmpresasEmpresaId], [TelefonesEmpresasNroTelefone]),
    CONSTRAINT [FK_TelefoneEmpresaUsuario_TelefoneEmpresa_TelefonesEmpresasEmpresaId_TelefonesEmpresasNroTelefone] FOREIGN KEY ([TelefonesEmpresasEmpresaId], [TelefonesEmpresasNroTelefone]) REFERENCES [TelefoneEmpresa] ([EmpresaId], [NroTelefone]) ON DELETE CASCADE,
    CONSTRAINT [FK_TelefoneEmpresaUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Alternativa] (
    [Id] uniqueidentifier NOT NULL,
    [Conteudo] NVARCHAR(255) NOT NULL,
    [Resposta] SMALLINT NOT NULL,
    [Status] SMALLINT NOT NULL,
    [QuestaoId] uniqueidentifier NOT NULL,
    [UsuarioId] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Alternativa] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Alternativa_Questao_QuestaoId] FOREIGN KEY ([QuestaoId]) REFERENCES [Questao] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [QuestaoUsuario] (
    [QuestoesId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_QuestaoUsuario] PRIMARY KEY ([QuestoesId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_QuestaoUsuario_Questao_QuestoesId] FOREIGN KEY ([QuestoesId]) REFERENCES [Questao] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_QuestaoUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [CertificadoUsuario] (
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    [CertificadosTreinamentoId] uniqueidentifier NOT NULL,
    [CertificadosCodigo] VARCHAR(32) NOT NULL,
    CONSTRAINT [PK_CertificadoUsuario] PRIMARY KEY ([UsuariosUsuarioId], [CertificadosTreinamentoId], [CertificadosCodigo]),
    CONSTRAINT [FK_CertificadoUsuario_Certificado_CertificadosTreinamentoId_CertificadosCodigo] FOREIGN KEY ([CertificadosTreinamentoId], [CertificadosCodigo]) REFERENCES [Certificado] ([TreinamentoId], [Codigo]) ON DELETE CASCADE,
    CONSTRAINT [FK_CertificadoUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ListaPresencaUsuario] (
    [ListasPresescasTreinamentoId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_ListaPresencaUsuario] PRIMARY KEY ([ListasPresescasTreinamentoId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_ListaPresencaUsuario_ListaPresenca_ListasPresescasTreinamentoId] FOREIGN KEY ([ListasPresescasTreinamentoId]) REFERENCES [ListaPresenca] ([TreinamentoId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ListaPresencaUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [AlternativaUsuario] (
    [AlternativasId] uniqueidentifier NOT NULL,
    [UsuariosUsuarioId] VARCHAR(255) NOT NULL,
    CONSTRAINT [PK_AlternativaUsuario] PRIMARY KEY ([AlternativasId], [UsuariosUsuarioId]),
    CONSTRAINT [FK_AlternativaUsuario_Alternativa_AlternativasId] FOREIGN KEY ([AlternativasId]) REFERENCES [Alternativa] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AlternativaUsuario_Usuario_UsuariosUsuarioId] FOREIGN KEY ([UsuariosUsuarioId]) REFERENCES [Usuario] ([UsuarioId]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Assinatura', N'Cpf', N'DataAlteracao', N'DataCriacao', N'Email', N'Nome', N'Rg', N'Status', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Aluno]'))
    SET IDENTITY_INSERT [Aluno] ON;
INSERT INTO [Aluno] ([Id], [Assinatura], [Cpf], [DataAlteracao], [DataCriacao], [Email], [Nome], [Rg], [Status], [Telefone], [UsuarioId])
VALUES ('1b5d254e-45cb-4c4f-8fd7-c1e2f5a15f2d', 'Assin1', '000.111.00011', NULL, '2024-06-03T23:54:35.7912267-03:00', '', N'Aluno Teste 1', '', 1, '', N'UsuarioTeste01@teste.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Assinatura', N'Cpf', N'DataAlteracao', N'DataCriacao', N'Email', N'Nome', N'Rg', N'Status', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Aluno]'))
    SET IDENTITY_INSERT [Aluno] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CargaHorariaInicial', N'CargaHorariaPeriodico', N'DataAlteracao', N'DataCriacao', N'Logo', N'Nome', N'Status', N'UsuarioId', N'Validade') AND [object_id] = OBJECT_ID(N'[Curso]'))
    SET IDENTITY_INSERT [Curso] ON;
INSERT INTO [Curso] ([Id], [CargaHorariaInicial], [CargaHorariaPeriodico], [DataAlteracao], [DataCriacao], [Logo], [Nome], [Status], [UsuarioId], [Validade])
VALUES ('9c6a17fd-8d5a-4f68-a6d1-5e9f8a2f4c17', CAST(4 AS SMALLINT), CAST(8 AS SMALLINT), NULL, '2024-06-03T23:54:35.7912706-03:00', '', N'Curso Teste 01', CAST(1 AS SMALLINT), N'UsuarioTeste01@teste.com', CAST(2 AS SMALLINT));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CargaHorariaInicial', N'CargaHorariaPeriodico', N'DataAlteracao', N'DataCriacao', N'Logo', N'Nome', N'Status', N'UsuarioId', N'Validade') AND [object_id] = OBJECT_ID(N'[Curso]'))
    SET IDENTITY_INSERT [Curso] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CNPJ', N'DataAlteracao', N'DataCriacao', N'Email', N'RazaoSocial', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Empresa]'))
    SET IDENTITY_INSERT [Empresa] ON;
INSERT INTO [Empresa] ([Id], [CNPJ], [DataAlteracao], [DataCriacao], [Email], [RazaoSocial], [Status], [UsuarioId])
VALUES ('7a9e5f7d-2c6e-4a1b-bc3f-4d5a1e2f5b6c', N'11.000.111/0001-10', NULL, '2024-06-03T23:54:35.7913520-03:00', '', N'Empresa Teste 01', CAST(1 AS SMALLINT), N'UsuarioTeste01@teste.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CNPJ', N'DataAlteracao', N'DataCriacao', N'Email', N'RazaoSocial', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Empresa]'))
    SET IDENTITY_INSERT [Empresa] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Assinatura', N'Cpf', N'DataAlteracao', N'DataCriacao', N'Email', N'Especializacao', N'Nome', N'Registro', N'Status', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Instrutor]'))
    SET IDENTITY_INSERT [Instrutor] ON;
INSERT INTO [Instrutor] ([Id], [Assinatura], [Cpf], [DataAlteracao], [DataCriacao], [Email], [Especializacao], [Nome], [Registro], [Status], [Telefone], [UsuarioId])
VALUES ('2f1b6d4e-8e7f-4a5d-9f1c-7c3e5d6b8f1a', '', '222.000.22202', NULL, '2024-06-03T23:54:35.7913753-03:00', '', N'Técnico de Segurança', N'Instrutor Teste 01', N'CAEPF01/542', CAST(1 AS SMALLINT), '(11) 991276269', N'UsuarioTeste01@teste.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Assinatura', N'Cpf', N'DataAlteracao', N'DataCriacao', N'Email', N'Especializacao', N'Nome', N'Registro', N'Status', N'Telefone', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Instrutor]'))
    SET IDENTITY_INSERT [Instrutor] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UsuarioId', N'DataAlteracao', N'DataCriacao', N'IsAdmin', N'Nome', N'Senha', N'Status') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] ON;
INSERT INTO [Usuario] ([UsuarioId], [DataAlteracao], [DataCriacao], [IsAdmin], [Nome], [Senha], [Status])
VALUES ('TesteUsuario02@teste.com', NULL, '2024-06-03T23:54:35.7913887-03:00', CAST(1 AS SMALLINT), N'Usuario 02', N'aqgbpo23', 1),
('UsuarioTeste01@teste.com', NULL, '2024-06-03T23:54:35.7913879-03:00', CAST(1 AS SMALLINT), N'Usuario 01', N'aqgbpo22', 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UsuarioId', N'DataAlteracao', N'DataCriacao', N'IsAdmin', N'Nome', N'Senha', N'Status') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'DataAlteracao', N'DataCriacao', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Prova]'))
    SET IDENTITY_INSERT [Prova] ON;
INSERT INTO [Prova] ([Id], [CursoId], [DataAlteracao], [DataCriacao], [Status], [UsuarioId])
VALUES ('3e6d2f3a-5f57-4c97-85c1-8f5d1b6c4d71', '9c6a17fd-8d5a-4f68-a6d1-5e9f8a2f4c17', NULL, '2024-06-03T23:54:35.7912850-03:00', CAST(1 AS SMALLINT), N'UsuarioTeste01@teste.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'DataAlteracao', N'DataCriacao', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Prova]'))
    SET IDENTITY_INSERT [Prova] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'DataAlteracao', N'DataCriacao', N'Situacao', N'Status', N'Tipo', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Treinamento]'))
    SET IDENTITY_INSERT [Treinamento] ON;
INSERT INTO [Treinamento] ([Id], [CursoId], [DataAlteracao], [DataCriacao], [Situacao], [Status], [Tipo], [UsuarioId])
VALUES ('d4f354e8-6e64-4b2c-91f5-99c5a6e5d7c1', '9c6a17fd-8d5a-4f68-a6d1-5e9f8a2f4c17', NULL, '2024-06-03T23:54:35.7912573-03:00', CAST(1 AS SMALLINT), CAST(1 AS SMALLINT), CAST(1 AS SMALLINT), N'UsuarioTeste01@teste.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CursoId', N'DataAlteracao', N'DataCriacao', N'Situacao', N'Status', N'Tipo', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Treinamento]'))
    SET IDENTITY_INSERT [Treinamento] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Conteudo', N'ProvaId', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Questao]'))
    SET IDENTITY_INSERT [Questao] ON;
INSERT INTO [Questao] ([Id], [Conteudo], [ProvaId], [Status], [UsuarioId])
VALUES ('b5aefd22-7c2e-42e5-9316-8f09d5f2c0f1', N'Questao 01', '3e6d2f3a-5f57-4c97-85c1-8f5d1b6c4d71', CAST(1 AS SMALLINT), N'UsuarioTeste01@teste.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Conteudo', N'ProvaId', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Questao]'))
    SET IDENTITY_INSERT [Questao] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Conteudo', N'QuestaoId', N'Resposta', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Alternativa]'))
    SET IDENTITY_INSERT [Alternativa] ON;
INSERT INTO [Alternativa] ([Id], [Conteudo], [QuestaoId], [Resposta], [Status], [UsuarioId])
VALUES ('8d7e2f3c-0d29-4d61-97f1-3453b6f7d631', N'alternativa A', 'b5aefd22-7c2e-42e5-9316-8f09d5f2c0f1', CAST(1 AS SMALLINT), CAST(1 AS SMALLINT), N'UsuarioTeste01@teste.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Conteudo', N'QuestaoId', N'Resposta', N'Status', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Alternativa]'))
    SET IDENTITY_INSERT [Alternativa] OFF;
GO

CREATE INDEX [IX_Alternativa_QuestaoId] ON [Alternativa] ([QuestaoId]);
GO

CREATE INDEX [IX_AlternativaUsuario_UsuariosUsuarioId] ON [AlternativaUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_AlunoEmpresa_EmpresasId] ON [AlunoEmpresa] ([EmpresasId]);
GO

CREATE INDEX [IX_AlunoTreinamento_TreinamentosId] ON [AlunoTreinamento] ([TreinamentosId]);
GO

CREATE INDEX [IX_AlunoUsuario_UsuariosUsuarioId] ON [AlunoUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_CertificadoUsuario_CertificadosTreinamentoId_CertificadosCodigo] ON [CertificadoUsuario] ([CertificadosTreinamentoId], [CertificadosCodigo]);
GO

CREATE INDEX [IX_ConteudoProgramatico_CursoId] ON [ConteudoProgramatico] ([CursoId]);
GO

CREATE INDEX [IX_ConteudoProgramaticoUsuario_UsuariosUsuarioId] ON [ConteudoProgramaticoUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_CursoUsuario_UsuariosUsuarioId] ON [CursoUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_EmpresaTreinamento_TreinamentosId] ON [EmpresaTreinamento] ([TreinamentosId]);
GO

CREATE INDEX [IX_EmpresaUsuario_UsuariosUsuarioId] ON [EmpresaUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_EnderecoEmpresaUsuario_UsuariosUsuarioId] ON [EnderecoEmpresaUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_InstrutorTreinamento_TreinamentosId] ON [InstrutorTreinamento] ([TreinamentosId]);
GO

CREATE INDEX [IX_InstrutorUsuario_UsuariosUsuarioId] ON [InstrutorUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_ListaPresencaUsuario_UsuariosUsuarioId] ON [ListaPresencaUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_Prova_CursoId] ON [Prova] ([CursoId]);
GO

CREATE INDEX [IX_ProvaUsuario_UsuariosUsuarioId] ON [ProvaUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_Questao_ProvaId] ON [Questao] ([ProvaId]);
GO

CREATE INDEX [IX_QuestaoUsuario_UsuariosUsuarioId] ON [QuestaoUsuario] ([UsuariosUsuarioId]);
GO

CREATE INDEX [IX_TelefoneEmpresaUsuario_TelefonesEmpresasEmpresaId_TelefonesEmpresasNroTelefone] ON [TelefoneEmpresaUsuario] ([TelefonesEmpresasEmpresaId], [TelefonesEmpresasNroTelefone]);
GO

CREATE INDEX [IX_Treinamento_CursoId] ON [Treinamento] ([CursoId]);
GO

CREATE INDEX [IX_TreinamentoUsuario_UsuariosUsuarioId] ON [TreinamentoUsuario] ([UsuariosUsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240604025436_v1', N'8.0.6');
GO

COMMIT;
GO

