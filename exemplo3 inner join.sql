select Categories.Description from Categories 
inner join Products on Categories.CategoryID = Products.CategoryID
inner join Suppliers on Products.SupplierID = Suppliers.SupplierID
and CompanyName='Exotic Liquids'