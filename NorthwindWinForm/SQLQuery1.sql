select Customers.CompanyName, Orders.OrderDate
from Customers join Orders 
on Customers.CustomerID = Orders.CustomerID
where year(Orders.OrderDate) = '1996'

select * from Customers join Orders on Customers.CustomerID = Orders.CustomerID
where year(Orders.OrderDate) = '1997'

select distinct year(Orders.OrderDate) from Orders

