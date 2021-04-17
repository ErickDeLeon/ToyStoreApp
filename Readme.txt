
Programas Instalados:
 Node.js
 Visual Studio Code
 Visual Studio 2019
 Sql Server 

VISUAL STUDIO CODE
1. Colocarse en la carpeta del proyeccto "\ToyStoreApp"
2. Dentro de esta carpeta, abrir la terminal y ejecutar lo siguiente.

	> npm install
	> npm i -g @angular/cli@latest                           
	> npm i ngx-toastr@13.2.1   
	> npm i --s @angular/material @angular/cdk @angular/animations    
	> npm i sweetalert2 --save
	> ng serve --o

3. Con esto tendriamos el lado del cliente.

VISUAL STUDIO 2019
1. Abrimos el proyecto ToyStore.sln
2.Verificar que los paquetes NuGets esten instalados correctamente. 
	+ Verificamos desde el Explorador de Soluciones > ToyStore > Dependencias > Paquetes
		Si los paquetetes no tienen un triangulo de warming significa que todos los paguetes estan bien y pasar al paso 4,
		de lo contrario continuar con el paso 3.

3. Desde el visual studio 2019, desde Herramientas > Administrador de paquetes NuGet > Administrador de paguetes NuGet para la solución....
	En este asistente vamos a verificar el Orgien del Paquete, damos click en el engrane lado derecho superior del asistente y verificamos 
	si se ecnuentra con el siguiente origen: https://api.nuget.org/v3/index.json
	Si no se encuentra debems de agregar en nombre "Package source" y en origen "https://api.nuget.org/v3/index.json" (ambos sin comillas) y damos en Aceptar

	En la pestaña de Examinar de este mismo asistence buscamos los sigueintes paquetes NuGet y los instalamos
	- Microsoft.EntityFrameworkCore
	- Microsoft.EntityFrameworkCore.SqlServer
	- Microsoft.EntityFrameworkCore.Tools

4. En appsettings.json vamos a cambiar la conexión a la base de datos. Abrimos el archivo y donde esta la conexión y dice Server vamos a colocar el Nombre de la instancia 
   de nuestra base datos donde alojaran los datos, es decir en lugar de ERICK\\SQLServer2017 debe ir la instancia de su sqlserver.

5. Abrimos la consola desde visual studio 2019. Herramientas > Administrador de paquetes NuGet > Consola de Administrador de Paquetes
   En esta consola usaremos el comando Update-Database, una vez que querminó de ejecutar podemos reviar en SQL Server que ya se ha creado la Base de Datos junto con la tabla
   donde se guardarán los registros.

6. Ejecutar el proyecto IIExpress y con esto tendriamos el back-end

////////////// PD
En el controlador de Toys esta comentada la clase donde se implementa el Patron IRepository.
La comenté ya que el context marca error al momento de actualizar un registro diciendo que el id esta repetido o simplemnte no actualiza.
y al momento de eliminar, el registro no se elimina del context es por ello que comenté y dejé que directamente se hiciera las consultas
desde el controlador. 
