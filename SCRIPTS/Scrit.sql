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
	ELIMINATO BIT
)

GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_GetSignDigitalInfoByDocument' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_GetSignDigitalInfoByDocument] AS BEGIN SET NOCOUNT ON; END')

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
	ELIMINATO as 'Disabled'
	FROM dbo.FIRMA_DIGITALE_BIRDID
	WHERE 
	DOCUMENTO LIKE '%'+@Documento+'%'
	

END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_CreateSignDigitalInfo' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_CreateSignDigitalInfo] AS BEGIN SET NOCOUNT ON; END')

ALTER PROCEDURE SP_SignBirdID_CreateSignDigitalInfo 
@Documento varchar(14),
@Cliente_ID varchar(100),
@Cliente_Segreto varchar(100),
@Numero_Acesso varchar(100),
@Autorizzazione varchar(100),
@Data_Di_Scadenza DATETIME,
@Eliminato bit
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
		AUTORIZZAZIONE
		)
	VALUES
	(
		@Documento,
		@Cliente_ID,
		@Cliente_Segreto,
		@Numero_Acesso,
		@Data_Di_Scadenza,
		@Eliminato,
		@Autorizzazione
	)
	
	SELECT SCOPE_IDENTITY();
END
GO

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SP_SignBirdID_CreateSignDigitalInfo' 
AND ROUTINE_SCHEMA = 'dbo' AND ROUTINE_TYPE = 'PROCEDURE')
EXEC('CREATE PROCEDURE [dbo].[SP_SignBirdID_CreateSignDigitalInfo] AS BEGIN SET NOCOUNT ON; END')

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