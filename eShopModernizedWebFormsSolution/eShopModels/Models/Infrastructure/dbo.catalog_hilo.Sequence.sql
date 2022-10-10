
USE [Microsoft.eShopOnContainers.Services.CatalogDb]
/****** Object:  Sequence [dbo].[catalog_hilo]    Script Date: 16/08/2017 11:21:49 ******/
CREATE SEQUENCE [dbo].[catalog_hilo] 
 AS [bigint]
 START WITH 1
 INCREMENT BY 10
 MINVALUE -9223372036854775808
 MAXVALUE 9223372036854775807
 CACHE 
