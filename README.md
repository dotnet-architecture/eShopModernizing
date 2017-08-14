# eshopLegacy

## Select in memory data or database connection
The program allows either to connect to the database to get the catalog or to use mock data if one database is not available. The option to select one or the another is in the `Web.config` file:
>```
><add key="UseMockData" value="true" />
>``` 

In case the database is selected ( UseMockData equals to false) then the connection string can be set in the section:
>```
><add name="CatalogDBContext" connectionString="Your connection string here" providerName="System.Data.SqlClient" />
>``` 