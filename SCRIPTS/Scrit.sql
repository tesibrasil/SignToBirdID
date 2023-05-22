USE PATHOX

GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES 
			  WHERE TABLE_NAME = 'FIRMA_DIGITALE_BIRDID') 

CREATE TABLE FIRMA_DIGITALE_BIRDID
(
	ID INT PRIMARY KEY NOT NULL IDENTITY,
	DOCUMENTO VARCHAR(14),
	CLIENTE_ID VARCHAR(100),
	CLIENTE_SEGRETO VARCHAR(100),
	AUTORIZZAZIONE VARCHAR(100),
	NUMERO_ACESSO VARCHAR(100),
	DATA_DI_SCADENZA DATETIME,
	ELIMINATO BIT,
	MOSTRA_POSIZIONE_FIRMA BIT,
	ASSE_X_Y VARCHAR(20)
)

GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_GetSignDigitalInfoByDocument' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_GetSignDigitalInfoByDocument] AS BEGIN SET NOCOUNT ON; END')

go

ALTER PROCEDURE SP_SignBirdID_GetSignDigitalInfoByDocument 
@Documento varchar(14)
AS
BEGIN

	SELECT
	ID,
	DOCUMENTO as Document,
	CLIENTE_ID as ClientID,
	CLIENTE_SEGRETO as ClientSecret,
	NUMERO_ACESSO as AccessNumber,
	DATA_DI_SCADENZA as ExpirationDate,
	AUTORIZZAZIONE as 'Authorization',
	MOSTRA_POSIZIONE_FIRMA as ShowSignatureLocation,
	ELIMINATO as 'Disabled',
	ASSE_X_Y AS 'AXLE'
	FROM dbo.FIRMA_DIGITALE_BIRDID
	WHERE 
	DOCUMENTO LIKE '%'+@Documento+'%'
	

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_CreateSignDigitalInfo' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_CreateSignDigitalInfo] AS BEGIN SET NOCOUNT ON; END')

go

ALTER PROCEDURE SP_SignBirdID_CreateSignDigitalInfo
@Documento varchar(14),
@Cliente_ID varchar(100),
@Cliente_Segreto varchar(100),
@Numero_Acesso varchar(100),
@Autorizzazione varchar(100),
@Data_Di_Scadenza DATETIME,
@Mostra_Posizione_Firma bit,
@Eliminato bit,
@Asse  VARCHAR(20)
AS
BEGIN

	INSERT INTO dbo.FIRMA_DIGITALE_BIRDID
	(
		DOCUMENTO,
		CLIENTE_ID,
		CLIENTE_SEGRETO,
		NUMERO_ACESSO,
		DATA_DI_SCADENZA,
		ELIMINATO,
		AUTORIZZAZIONE,
		MOSTRA_POSIZIONE_FIRMA,
		ASSE_X_Y
		)
	VALUES
	(
		@Documento,
		@Cliente_ID,
		@Cliente_Segreto,
		@Numero_Acesso,
		@Data_Di_Scadenza,
		@Eliminato,
		@Autorizzazione,
		@Mostra_Posizione_Firma,
		@Asse
	)
	
	SELECT SCOPE_IDENTITY();
END
GO

go

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_UpdateSignDigitalInfo' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_UpdateSignDigitalInfo] AS BEGIN SET NOCOUNT ON; END')

go

ALTER PROCEDURE SP_SignBirdID_UpdateSignDigitalInfo 
@ID int,
@Numero_Acesso varchar(100),
@Data_Di_Scadenza DATETIME,
@Autorizzazione varchar(100)
AS
BEGIN

    UPDATE dbo.FIRMA_DIGITALE_BIRDID
	SET 
	NUMERO_ACESSO = @Numero_Acesso,
	DATA_DI_SCADENZA = @Data_Di_Scadenza,
	AUTORIZZAZIONE = @Autorizzazione
	WHERE ID = @ID

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_UpdateShowSignatureLocation' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_UpdateShowSignatureLocation] AS BEGIN SET NOCOUNT ON; END')

go

ALTER PROCEDURE SP_SignBirdID_UpdateShowSignatureLocation
@ID int,
@Mostra_Posizione_Firma bit
AS
BEGIN

    UPDATE dbo.FIRMA_DIGITALE_BIRDID
	SET 
	MOSTRA_POSIZIONE_FIRMA = @Mostra_Posizione_Firma
	WHERE ID = @ID

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_UpdateAxle' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_UpdateAxle] AS BEGIN SET NOCOUNT ON; END')

go

ALTER PROCEDURE SP_SignBirdID_UpdateAxle
@ID int,
@Asse VARCHAR(20)
AS
BEGIN

    UPDATE dbo.FIRMA_DIGITALE_BIRDID
	SET 
	ASSE_X_Y = @Asse

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_GetSignDigitalInfoValidationByExamId' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_GetSignDigitalInfoValidationByExamId] AS BEGIN SET NOCOUNT ON; END')

go

ALTER PROCEDURE SP_SignBirdID_GetSignDigitalInfoValidationByExamId 
@examId varchar(14)
AS
BEGIN
	DECLARE @nomeUtente varchar(50);
	DECLARE @idOperatori int;
	DECLARE @loginExterno varchar(14);

	--Pegar usuario que validou o exame
	SET @nomeUtente = (SELECT utentefinerefertazione FROM EsamiNew
	WHERE IDEsame = @examId);

	--Pegar idOperatori 
	SET @idOperatori = (SELECT id FROM Utenti
	WHERE Username LIKE '%' + @nomeUtente);

	--Pegar LoginExterno do usuario
	SET @loginExterno = (SELECT LoginEsterno FROM Operatori
	WHERE IDUserLogin = @idOperatori);

	SELECT
	ID,
	DOCUMENTO as Document,
	CLIENTE_ID as ClientID,
	CLIENTE_SEGRETO as ClientSecret,
	NUMERO_ACESSO as AccessNumber,
	DATA_DI_SCADENZA as ExpirationDate,
	AUTORIZZAZIONE as 'Authorization',
	MOSTRA_POSIZIONE_FIRMA as ShowSignatureLocation,
	ELIMINATO as 'Disabled',
	ASSE_X_Y AS 'AXLE',
	@nomeUtente as UserName
	FROM dbo.FIRMA_DIGITALE_BIRDID
	WHERE 
	DOCUMENTO LIKE '%'+@loginExterno+'%'
	AND GETDATE() < DATA_DI_SCADENZA 
	

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_GetCPFByExamId' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_GetCPFByExamId] AS BEGIN SET NOCOUNT ON; END')

go

create PROCEDURE SP_SignBirdID_GetCPFByExamId
@examId varchar(14)
AS
BEGIN
	DECLARE @nomeUtente varchar(50);
	DECLARE @idOperatori int;
	DECLARE @loginExterno varchar(14);

	--Pegar usuario que validou o exame
	SET @nomeUtente = (SELECT utentefinerefertazione FROM EsamiNew
	WHERE IDEsame = @examId);

	--Pegar idOperatori 
	SET @idOperatori = (SELECT id FROM Utenti
	WHERE Username LIKE '%' + @nomeUtente);

	--Pegar LoginExterno do usuario
   	SELECT LoginEsterno AS CPF FROM Operatori
	WHERE IDUserLogin = @idOperatori


END
GO