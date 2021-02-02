--Ответ:
SELECT products.product_name, categories.category_name FROM products 
LEFT JOIN products_categories ON ([products_categories].[product_id]=products.product_id)
LEFT JOIN categories ON ([products_categories].category_id=categories.category_id)


--Подробно:
--В задании требуется сделать так, чтобы продукту могло соответствовать много категорий, а в одной категории могло быть много продуктов. Это отношение "многие ко многим", которое моделируется с помощью третьей, вспомогательной таблицы. Поэтому было создано 3 таблицы с помощью следующих команд:
CREATE TABLE [products]([product_id] int NOT NULL PRIMARY KEY IDENTITY, 
                        [product_name] NVARCHAR(150) NOT NULL);
CREATE TABLE [categories]([category_id] int NOT NULL PRIMARY KEY IDENTITY, 
                          [category_name] NVARCHAR(150) NOT NULL);
CREATE TABLE [products_categories]([pair_id] int NOT NULL PRIMARY KEY IDENTITY, 
                                   [product_id] int NOT NULL, 
                                   [category_id] int NOT NULL,
                                   FOREIGN KEY ([product_id]) REFERENCES products([product_id]),
                                   FOREIGN KEY ([category_id]) REFERENCES categories([category_id]));
								   
--Теперь заполним все 3 таблицы данными.	  
--Таблица продуктов:
INSERT INTO products(product_name) VALUES ('Laptop');
INSERT INTO products(product_name) VALUES ('Videocard AMD');
INSERT INTO products(product_name) VALUES ('Processor AMD');
INSERT INTO products(product_name) VALUES ('Processor Intel');
INSERT INTO products(product_name) VALUES ('Videocard NVIDIA');
INSERT INTO products(product_name) VALUES ('Display DELL');

--Таблица категорий:
INSERT INTO categories(category_name) VALUES ('AMD');
INSERT INTO categories(category_name) VALUES ('Processor');
INSERT INTO categories(category_name) VALUES ('Intel');
INSERT INTO categories(category_name) VALUES ('NVIDIA');
INSERT INTO categories(category_name) VALUES ('Videocard');

--Вспомогательная таблица пар продуктов и категорий. ID могут различаться в зависимости от того, что им назначит база данных.
INSERT INTO [dbo].products_categories ([product_id],[category_id]) VALUES (2,1);
INSERT INTO [dbo].products_categories ([product_id],[category_id]) VALUES (3,2);
INSERT INTO [dbo].products_categories ([product_id],[category_id]) VALUES (4,3);
INSERT INTO [dbo].products_categories ([product_id],[category_id]) VALUES (5,4);
INSERT INTO [dbo].products_categories ([product_id],[category_id]) VALUES (2,5);
INSERT INTO [dbo].products_categories ([product_id],[category_id]) VALUES (4,2);
INSERT INTO [dbo].products_categories ([product_id],[category_id]) VALUES (5,5);

--В задании требуется вывести пары название продукта-категория, но при этом также вывести продукты без категорий.
--Поэтому мы собираем данные следующим образом: к таблице продуктов products прикрепляем с помощью LEFT JOIN пары (т.е. таблицу products_categories), которые надо будет вывести, сравнивая записи по product_id
--В получившейся таблице оказываются все требуемые нам ряды, то есть и пары продукт-категория, и продукты без пар (где в категории просто окажется NULL). Но в этой таблице нет названий категорий. Ещё раз используем LEFT JOIN, используя category_id для присоединения таблицы categories.
--В итоговой таблице есть как все нужные ряды, так и все нужные столбцы. Первая часть запроса SELECT products.product_name, categories.category_name выбирает 2 нужных нам столбца из получившейся таблицы и возвращает их.
--Код был протестирован в SQL Server Management Studio, подключеной к Microsoft SQL Server Developer Edition 2019.
SELECT products.product_name, categories.category_name FROM products 
LEFT JOIN products_categories ON ([products_categories].[product_id]=products.product_id)
LEFT JOIN categories ON ([products_categories].category_id=categories.category_id)