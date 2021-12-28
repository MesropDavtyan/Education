-- Let’s have this table:
-- CREATE TABLE Orders(order_id INT PRIMARY KEY, order_date DATE, customer_id INT);
-- Create an SQL statement that will return for every customer his last order (all the columns).

with MaxDate
as
(
	select o.customer_id, max(o.order_date) as latestDate
	from Orders as o
	group by o.customer_id
)

select o.order_id, o.order_date, o.customer_id
from Orders as o
right join MaxDate as m
on o.customer_id = m.customer_id and o.order_date = m.latestDate
