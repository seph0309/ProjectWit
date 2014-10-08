/*
	Include test data here
*/

USE [WIT]
DELETE FROM WIT_USER
DELETE FROM AspNetRoles
DELETE FROM AspNetUsers
DELETE FROM AspNetUserRoles
DELETE FROM Wit_Item
DELETE FROM Wit_Category
DELETE FROM Wit_Company
DELETE FROM Wit_NavBar


INSERT INTO WIT_NAVBAR (Menu,SubMenu,URL) 
SELECT 'Admin Maintenance',REPLACE(name,'WIT_','') , REPLACE(name,'WIT_','') + '/Index' FROM SYS.tables WHERE name LIKE 'wit%'

INSERT INTO Wit_Company(Company_UID,CompanyName,CompanyAddress)
VALUES ('2D5BDCD6-7237-E411-90A1-EC9A7436DA60','WITTAPPS','MAKATI CITY')

INSERT INTO Wit_Company(Company_UID,CompanyName,CompanyAddress)
VALUES ('2E5BDCD6-7237-E411-90A1-EC9A7436DA60','ABC','MAKATI CITY')

INSERT INTO Wit_Company(Company_UID,CompanyName,CompanyAddress)
VALUES ('2E5BDCD6-7237-E411-90A1-EC9A7436DA61','DEF','MAKATI CITY')

INSERT INTO Wit_Company(Company_UID,CompanyName,CompanyAddress)
VALUES ('2E5BDCD6-7237-E411-90A1-EC9A7436DA62','ASTICOM','MAKATI CITY')

INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF23','2D5BDCD6-7237-E411-90A1-EC9A7436DA60','Appetizer')
INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF24','2D5BDCD6-7237-E411-90A1-EC9A7436DA60','Fish')
INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF25','2D5BDCD6-7237-E411-90A1-EC9A7436DA60','Chicken')
INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF26','2E5BDCD6-7237-E411-90A1-EC9A7436DA60','Pork')
INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF27','2E5BDCD6-7237-E411-90A1-EC9A7436DA60','Desert')
INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF28','2E5BDCD6-7237-E411-90A1-EC9A7436DA60','Drinks')
INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF29','2E5BDCD6-7237-E411-90A1-EC9A7436DA60','Cake')
INSERT INTO Wit_Category (Category_UID,Company_UID,CategoryName) VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF20','2E5BDCD6-7237-E411-90A1-EC9A7436DA60','Alcohol')

INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('17DF81BC-D64E-E411-A417-D459F8E9FF20','47DF81BC-D64E-E411-A417-D459F8E9FF20', 'San Miguel Beer', 'One of our best sellers!', 'yahoo.com', '1', '0', '1001', 'Good', '150.5', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('27DF81BC-D64E-E411-A417-D459F8E9FF20','47DF81BC-D64E-E411-A417-D459F8E9FF20', 'Red Horse', 'Strongest beer', 'yahoo.com', '0', '0', '1002', 'Good', '155.6', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('37DF81BC-D64E-E411-A417-D459F8E9FF20','47DF81BC-D64E-E411-A417-D459F8E9FF20', 'San Miguel Light', 'Lightest beer', 'yahoo.com', '0', '0', '1003', 'Good', '160.7', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF23','47DF81BC-D64E-E411-A417-D459F8E9FF23', 'Chicken Lollipop', 'This is our best seller', 'yahoo.com', '1', '0', '1012', 'Good', '206.6', '1') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('57DF81BC-D64E-E411-A417-D459F8E9FF23','47DF81BC-D64E-E411-A417-D459F8E9FF23', 'Peanut Brittle', 'Freshly baked!', 'yahoo.com', '1', '0', '1013', 'Good', '211.7', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('67DF81BC-D64E-E411-A417-D459F8E9FF23','47DF81BC-D64E-E411-A417-D459F8E9FF23', 'Popcorn', 'Sour cream flavor', 'yahoo.com', '1', '0', '1014', 'Good', '216.8', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('77DF81BC-D64E-E411-A417-D459F8E9FF23','47DF81BC-D64E-E411-A417-D459F8E9FF23', '', '', 'yahoo.com', '1', '0', '1015', 'Good', '221.9', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('87DF81BC-D64E-E411-A417-D459F8E9FF24','47DF81BC-D64E-E411-A417-D459F8E9FF24', 'Sweet and sour fish fillet', 'Deep fried fish mixed with sweet and sour sauce', 'yahoo.com', '1', '1', '1016', 'Good', '227', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('97DF81BC-D64E-E411-A417-D459F8E9FF24','47DF81BC-D64E-E411-A417-D459F8E9FF24', 'Fried lapu lapu', '', 'yahoo.com', '1', '2', '1017', 'Good', '232.1', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('07DF81BC-D64E-E411-A417-D459F8E9FF24','47DF81BC-D64E-E411-A417-D459F8E9FF24', 'Fish fillet with tausi sauce', '', 'yahoo.com', '1', '3', '1018', 'Good', '237.2', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('41DF81BC-D64E-E411-A417-D459F8E9FF25','47DF81BC-D64E-E411-A417-D459F8E9FF25', 'Fried chicken', 'Deep fried fried chicked', 'yahoo.com', '1', '3', '1020', 'Good', '247.4', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('42DF81BC-D64E-E411-A417-D459F8E9FF25','47DF81BC-D64E-E411-A417-D459F8E9FF25', 'Chicken pandan', 'Wrap in pandan leaves', 'yahoo.com', '1', '2', '1021', 'Good', '252.5', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('43DF81BC-D64E-E411-A417-D459F8E9FF25','47DF81BC-D64E-E411-A417-D459F8E9FF25', 'Soy chicked', '', 'yahoo.com', '1', '1', '1022', 'Good', '257.6', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('44DF81BC-D64E-E411-A417-D459F8E9FF25','47DF81BC-D64E-E411-A417-D459F8E9FF25', 'Roasted chicked', '', 'yahoo.com', '1', '0', '1023', 'Good', '262.7', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('45DF81BC-D64E-E411-A417-D459F8E9FF26','47DF81BC-D64E-E411-A417-D459F8E9FF26', 'Pork binagoongan', 'Chefs favorite', 'yahoo.com', '0', '0', '1024', 'Good', '267.8', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('46DF81BC-D64E-E411-A417-D459F8E9FF26','47DF81BC-D64E-E411-A417-D459F8E9FF26', 'Menudo', '', 'yahoo.com', '1', '0', '1025', 'Good', '272.9', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('47DF81BC-D64E-E411-A417-D459F8E9FF26','47DF81BC-D64E-E411-A417-D459F8E9FF26', 'Sinigang', '', 'yahoo.com', '1', '0', '1026', 'Good', '278', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('48DF81BC-D64E-E411-A417-D459F8E9FF26','47DF81BC-D64E-E411-A417-D459F8E9FF26', 'Adobo', '', 'yahoo.com', '1', '0', '1027', 'Good', '283.1', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('49DF81BC-D64E-E411-A417-D459F8E9FF27','47DF81BC-D64E-E411-A417-D459F8E9FF27', 'Leche flan', 'Good for 2', 'yahoo.com', '1', '0', '1028', 'Good', '288.2', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('40DF81BC-D64E-E411-A417-D459F8E9FF27','47DF81BC-D64E-E411-A417-D459F8E9FF27', 'Halo halo', '', 'yahoo.com', '1', '0', '1029', 'Good', '293.3', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('471F81BC-D64E-E411-A417-D459F8E9FF27','47DF81BC-D64E-E411-A417-D459F8E9FF27', 'Pandan shake', '', 'yahoo.com', '1', '0', '1030', 'Good', '298.4', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('472F81BC-D64E-E411-A417-D459F8E9FF27','47DF81BC-D64E-E411-A417-D459F8E9FF27', 'Mango shake', '', 'yahoo.com', '1', '0', '1031', 'Good', '303.5', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('473F81BC-D64E-E411-A417-D459F8E9FF28','47DF81BC-D64E-E411-A417-D459F8E9FF28', 'Coke', '', 'yahoo.com', '1', '0', '1032', 'Good', '308.6', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('474F81BC-D64E-E411-A417-D459F8E9FF28','47DF81BC-D64E-E411-A417-D459F8E9FF28', 'Sprite', '', 'yahoo.com', '1', '0', '1033', 'Good', '313.7', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('475F81BC-D64E-E411-A417-D459F8E9FF28','47DF81BC-D64E-E411-A417-D459F8E9FF28', 'Mountain due', '', 'yahoo.com', '0', '0', '1034', 'Good', '318.8', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('476F81BC-D64E-E411-A417-D459F8E9FF28','47DF81BC-D64E-E411-A417-D459F8E9FF28', 'Root beer', '', 'yahoo.com', '0', '0', '1035', 'Good', '323.9', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('477F81BC-D64E-E411-A417-D459F8E9FF29','47DF81BC-D64E-E411-A417-D459F8E9FF29', 'Chocolate', '', 'yahoo.com', '1', '0', '1036', 'Good', '329', '') 
INSERT INTO Wit_Item (Item_UID,Category_UID,ItemName,ItemDescription,ImageURL,OnStock,SpiceLevel,Likes,FoodMark,Amount,IsBestSeller)	VALUES ('478F81BC-D64E-E411-A417-D459F8E9FF29','47DF81BC-D64E-E411-A417-D459F8E9FF29', 'Vanilla', '', 'yahoo.com', '1', '0', '1037', 'Good', '334.1', '') 


 INSERT INTO AspNetRoles (ID,Name) VALUES ('31CAA23C-A8CE-4F25-B737-C435AD71A440' ,'SYSADMIN')
 INSERT INTO AspNetRoles (ID,Name) VALUES ('31CAA23C-A8CE-4F25-B737-C435AD71A441' ,'ADMIN')
 INSERT INTO AspNetRoles (ID,Name) VALUES ('31CAA23C-A8CE-4F25-B737-C435AD71A442' ,'CREW')
 INSERT INTO AspNetRoles (ID,Name) VALUES ('31CAA23C-A8CE-4F25-B737-C435AD71A443' ,'CUSTOMER')
 INSERT INTO AspNetRoles (ID,Name) VALUES ('31CAA23C-A8CE-4F25-B737-C435AD71A444' ,'GUEST')

 
 EXEC spCreateDummyData '299A2AD2-B6A4-47E8-A66A-CA84333AF7C0','SYSADMIN'
 EXEC spCreateDummyData '299A2AD2-B6A4-47E8-A66A-CA84333AF7C1','CREW'
 EXEC spCreateDummyData '299A2AD2-B6A4-47E8-A66A-CA84333AF7C2','ADMIN'
 EXEC spCreateDummyData '299A2AD2-B6A4-47E8-A66A-CA84333AF7C3','GUEST'
  