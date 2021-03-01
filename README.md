# CMPP248Workshop4-Group4

This application requires the importing of the attached travelexperts-mssql.sql scrip to Microsoft SQL Server Management Studio.

This project's aim was to produce a graphical interface for viewing and modifying the data of a travel agengy's database. 
The language we chose to develop this application in was C#.
The tables that will be used by this part of the project are:
1.Packages
2.Products
3.Products_suppliers
4.Suppliers
5.Packages_products_suppliers

Packages Highlights Include:
- Adding, editing and deleting travel packages.  
- Users are able to multi-select products from various suppliers to add or remove from their packages.
- Users are notified if two or more items of the same product are selected.
- Product Suppliers that are associated to the current package are displayed in a checklist box, users are able to deselect at their choosing.
- Product Suppliers that not associated to the current package are displayed in a checklist box, users are able to select at their choosing.

Products Highlights Include:
- Adding, editing and deleting travel products.  
- Application checks the database for duplicate values in product name.

Products Highlights Include:
- Adding, editing and deleting travel suppliers.  
- Application checks the database for duplicate values for supplier name.
- Users are able to add and remove multiple products associations to a single supplier.
- Products that are associated to the current supplier are displayed in a checklist box, users are able to deselect at their choosing.
- Products that not associated to the current supplier are displayed in a checklist box, users are able to select at their choosing.

Contraints:
- Agency Commission cannot be greater than the Base Price
- Package End Date must be later than Package Start Date
- Package Name and Package Description cannot be null

Thanks for reading!
Susan & Julie
