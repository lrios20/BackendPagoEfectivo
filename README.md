# PagoEfectivo
 ## Pasos para compilar el proyecto.
 *dotnet run
 ## Cambiar en el appsettings.json la conexion de la base de datos `Sql Server`
 ## Crear la base de datos

 Utilizar el comando `dotnet ef migrations add MyBaseMigration 
  --context DbPagoEfectivoContext`
  
  ## Verificar conexion en la clase DbPagoEfectivoContext 
  En el metodo `pptionsBuilder.UseSqlServer` tiene que ser la misma conexion que esta en el appsetiing.json.
