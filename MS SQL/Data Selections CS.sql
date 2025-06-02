-- Display customer list by first name in descending order
SELECT * FROM customers ORDER BY first_name DESC;

-- Display first name, last name, and city of customers sorted by city and then first name
SELECT first_name, last_name, city FROM customers ORDER BY city ASC, first_name ASC;

-- Top three most expensive products
SELECT TOP 3 * FROM products ORDER BY list_price DESC;

-- Products with price > 300 and model year = 2018
SELECT * FROM products WHERE list_price > 300 AND model_year = 2018;

-- Products with price > 3000 OR model year = 2018
SELECT * FROM products WHERE list_price > 3000 OR model_year = 2018;

-- Products with price between 1899 and 1999.99
SELECT * FROM products WHERE list_price BETWEEN 1899 AND 1999.99;

-- Products with specific prices using IN
SELECT * FROM products WHERE list_price IN (299.99, 466.99, 489.99);

-- Customers where last name starts with A, B, or C
SELECT * FROM customers WHERE last_name LIKE 'A%' OR last_name LIKE 'B%' OR last_name LIKE 'C%';

-- Customers where first name does not start with A
SELECT * FROM customers WHERE first_name NOT LIKE 'A%';

-- Number of customers by state and city
SELECT state, city, COUNT(*) AS CustomerCount FROM customers GROUP BY state, city;

-- Number of orders placed by customer, grouped by customer ID and year
SELECT customer_id, YEAR(order_date) AS OrderYear, COUNT(*) AS OrderCount
FROM orders
GROUP BY customer_id, YEAR(order_date);

-- Question 12
SELECT category_id, MAX(list_price) AS MaxPrice, MIN(list_price) AS MinPrice FROM products GROUP BY category_id HAVING MAX(list_price) > 4000 OR MIN(list_price) < 500;