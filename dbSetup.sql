CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS houses(id INT AUTO_INCREMENT PRIMARY KEY, bedrooms INT NOT NULL COMMENT 'number of bedrooms', bathrooms INT NOT NULL COMMENT 'number of bathrooms', year INT NOT NULL COMMENT 'year house was built', levels INT NOT NULL COMMENT 'number of stories', imgURL VARCHAR(5000) NOT NULL COMMENT 'image of house', description VARCHAR(5000) NOT NULL COMMENT 'description of house', price DOUBLE NOT NULL DEFAULT 1.00 COMMENT 'cost to purchase') default charset utf8 COMMENT '';

DROP table IF EXISTS houses;

-- ALTER TABLE houses
-- MODIFY COLUMN id

INSERT INTO houses(bedrooms, bathrooms, year, levels, imgUrl, description, price)
VALUES(4, 3, 1990, 2, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCaFRFhdPuQ1O3RfHM_usJAG0AJl3lhYFivw&usqp=CAU', 'A pretty nice home for a pretty nice family', 500000.01);
INSERT INTO houses(bedrooms, bathrooms, year, levels, imgUrl, description, price)
VALUES(1, 1, 1500, 1, 'https://c8.alamy.com/comp/A122X8/reconstruction-of-an-ancient-mud-hut-A122X8.jpg', 'It will keep you sheltered at least', 5.99);
INSERT INTO houses(bedrooms, bathrooms, year, levels, imgUrl, description, price)
VALUES(10, 100, 2030, 5, 'https://dwgyu36up6iuz.cloudfront.net/heru80fdn/image/upload/c_fill,d_placeholder_architecturaldigest.png,fl_progressive,g_face,h_1080,q_80,w_1920/v1645135325/architecturaldigest_on-the-market-inside-a-23-dollars-million-mega-mansion-surrounded-by-a-lake.jpg', 'You can only dream of living here', 1000000000);

SELECT 
*
FROM houses
WHERE bedrooms = 1;

SELECT * FROM houses;

DELETE FROM houses WHERE price > 500001;

DELETE FROM houses WHERE id = 4;

UPDATE houses
SET
bedrooms = 4,
bathrooms = 1,
year = 2022
WHERE year = 1990;


SELECT LAST_INSERT_ID();