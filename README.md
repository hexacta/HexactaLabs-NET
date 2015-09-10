# HexactaLabs-NET

##Pre-requisitos
Es necesario contar con el siguiente software para poder realizar las actividades:

 - Microsoft Windows 7 o superior.
 - [Microsoft SQL Server 2014 Express Edition](http://www.microsoft.com/en-us/server-cloud/products/sql-server-editions/sql-server-express.aspx) . Version Gratuita, se necesita una cuenta gratis Microsoft para la descarga. Seleccionar el paquete **SQL Server 2014 Express with Advanced Services**
 - [Microsoft Visual Studio Community Edition](https://www.visualstudio.com/products/visual-studio-community-vs) Version gratuita, asegurarse de instalar con todos los complementos para C Sharp y MVC

--
--

- Para poder realizar las actividades, es necesario utilizar la máquina virtual provista en el curso o instalar el IDE y el servidor de base de datos.
- Además es necesario crear una base de datos de nombre `Capacitacion_MVC`. Un dump con datos de prueba se puede encontrar en la carpeta `SQL` de la solución provista.
- El script SQL con el schema y datos de la base se deberá correr conectado a la nueva base `Capacitacion_MVC`.
- Por último es necesario descargar la solución inicial y apuntar la aplicación web a la base de datos creada en el punto anterior, con el correspondiente connection string en el archivo `Web.config`.
Un ejemplo de connection string:
<add name="MoviesContext" connectionString="data source=localhost\SQLEXPRESS;initial catalog=Capacitacion_MVC;Trusted_Connection=True;App=EntityFramework" providerName="System.Data.SqlClient" />

Donde nos conectamos al servidor 'SQLEXPRESS' en localhost, utilizando la autenticación por usuario de windows en el servidor SqlServer (es equivalente utilizar Integrated Security=SSPI).
--
--
 
[Primera Parte - Actividades1](actividades1.md)

[Segunda Parte - Actividades2](actividades2.md)
