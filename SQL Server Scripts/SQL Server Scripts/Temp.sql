DECLARE @myNewPKTable TABLE (myNewPK INT)

	declare @TB_IMP_FEED table 
		(
		[NodeId]			int not null unique,
		[FeedId]			int not null,
		[Name]				nvarchar(100) not null,
		[FeedTypeId]		int not null,
		[Active]			bit not null
		)

	declare @TB_FeedKeyValue table 
		(
		KeyValueId INT IDENTITY(1,1) NOT NULL,
		FeedId int,
		Chave nvarchar(100),
		Valor nvarchar(100),
		FeedSpecific bit		
		)

insert into @TB_IMP_FEED ([NodeId], [FeedId], [Name], [FeedTypeId], [Active])
values (1, 1, 'BOVESPAFEED1', 1, 0)
insert into @TB_IMP_FEED ([NodeId], [FeedId], [Name], [FeedTypeId], [Active])
values (2, 0, 'BOVESPAFEED2', 1, 0)
insert into @TB_IMP_FEED ([NodeId], [FeedId], [Name], [FeedTypeId], [Active])
values (3, 0, 'BOVESPAFEED3', 1, 0)

insert into @TB_FeedKeyValue (FeedId, Chave, Valor, FeedSpecific)
values (1, 'FileMask', 'VALOR1', 0)
insert into @TB_FeedKeyValue (FeedId, Chave, Valor, FeedSpecific)
values (1, 'SiteAddress', 'VALOR2', 0)

SELECT * from @TB_IMP_FEED F
		inner join TB_FeedType FT on F.FeedTypeId = FT.FeedTypeId
		inner Join TB_FeedTypeDefaultKeys FTD on FTD.FeedTypeId = F.FeedTypeId 
		Left Join @TB_FeedKeyValue KV on F.FeedId = KV.FeedID and KV.Chave = FTD.Chave
order by F.FeedId

insert into @TB_FeedKeyValue (FeedId, Chave, Valor, FeedSpecific)
OUTPUT INSERTED.KeyValueId INTO @myNewPKTable
SELECT F.FeedId, FTD.Chave, '', 1 from @TB_IMP_FEED F
		inner join TB_FeedType FT on F.FeedTypeId = FT.FeedTypeId
		inner Join TB_FeedTypeDefaultKeys FTD on FTD.FeedTypeId = F.FeedTypeId 
		Left Join @TB_FeedKeyValue KV on F.FeedId = KV.FeedID and KV.Chave = FTD.Chave
WHERE 
		KV.Chave is null

SELECT * from @TB_IMP_FEED F
		inner join TB_FeedType FT on F.FeedTypeId = FT.FeedTypeId
		inner Join TB_FeedTypeDefaultKeys FTD on FTD.FeedTypeId = F.FeedTypeId 
		Left Join @TB_FeedKeyValue KV on F.FeedId = KV.FeedID and KV.Chave = FTD.Chave
order by F.FeedId



select * from @myNewPKTable




		select * from TB_FeedTypeDefaultKeys
		select * from TB_FeedType
		

		insert into TB_FeedType (EnumCode, Descricao) values('BDI', 'Bovespa arquivo BDI' )

		select * from TB_FeedType 

		
		insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES(1, 'SiteAddress')
		insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES(1, 'FileMask')
		insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES(1, 'SaveDownloadAs')
		insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES(1, 'ExtractAs')
		insert into TB_FeedTypeDefaultKeys (FeedTypeId, Chave) VALUES(1, 'SearchInZip')


