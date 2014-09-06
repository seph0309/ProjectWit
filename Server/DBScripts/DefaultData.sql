/*
	Include test data here
*/

USE [WIT]
TRUNCATE TABLE WIT_NAVBAR

insert into WIT_NAVBAR (Menu,SubMenu,URL) 
SELECT REPLACE(name,'WIT_','') AS Menu,'', REPLACE(name,'WIT_','') + '/Index' FROM SYS.tables where name like 'wit%'
and name <>'Wit_Item' 
insert into WIT_NAVBAR (Menu,SubMenu,URL) 
VALUES ('Category', 'Item','Item/Index')

