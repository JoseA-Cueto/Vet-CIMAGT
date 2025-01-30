README - Aplicación Backend en .NET 9
Este documento proporciona las instrucciones necesarias para configurar y ejecutar la aplicación backend desarrollada en .NET 9. Sigue estos pasos para poner en marcha la aplicación en tu máquina local.

Requisitos
Sistema operativo: Windows, macOS o Linux.
.NET 9 SDK: Debes tener instalado el SDK de .NET 9.
Editor de código: Se recomienda Visual Studio Code o Visual Studio para un mejor flujo de trabajo.
Base de Datos: SQL Server o cualquier motor de base de datos que utilice la aplicación.
Pasos para ejecutar la aplicación
1. Descargar e Instalar .NET 9 SDK
Si no tienes instalado .NET 9, sigue estos pasos:

Dirígete a la página oficial de descarga de .NET 9 y descarga el .NET 9 SDK para tu sistema operativo.

Sigue las instrucciones de instalación para tu plataforma.

Para verificar que .NET 9 está correctamente instalado, abre una terminal y ejecuta:

bash
dotnet --version
Esto debería devolver la versión instalada, por ejemplo, 9.x.x.

2. Clonar el repositorio
Clona el repositorio de GitHub en tu máquina local con el siguiente comando:

bash
Copiar
git clone https://github.com/JoseA-Cueto/Vet-CIMAGT-Backend.git
cd Vet-CIMAGT-Backend
3. Restaurar los paquetes NuGet
Para restaurar los paquetes NuGet necesarios para la aplicación, abre una terminal en la carpeta del proyecto y ejecuta:

bash
Copiar
dotnet restore
Esto descargará e instalará todas las dependencias necesarias.

4. Crear la base de datos
La base de datos puede crearse de forma automática utilizando EF Core si está configurado para usar migraciones.

a) Ejecutar migraciones
Si estás usando Entity Framework Core para gestionar la base de datos, ejecuta las migraciones para crear las tablas necesarias. En la terminal, dentro de la carpeta del proyecto, ejecuta:

bash
Copiar
dotnet ef database update
Esto aplicará las migraciones y creará la base de datos si no existe.

5. Ejecutar la aplicación
Para ejecutar la aplicación, simplemente corre el siguiente comando en la terminal:

bash
Copiar
dotnet run
Esto iniciará la aplicación en el puerto predeterminado (generalmente http://localhost:5000).

6. Verificar el funcionamiento
Abre tu navegador web y navega a http://localhost:5000. Deberías ver la aplicación funcionando correctamente.

Problemas comunes
1. Error de conexión a la base de datos
Verifica que el servidor de la base de datos esté en funcionamiento y que la configuración de la conexión esté correcta en el archivo appsettings.json.
2. Paquete NuGet faltante
Si tienes problemas con paquetes NuGet, ejecuta dotnet restore nuevamente o elimina las carpetas obj y bin, luego ejecuta dotnet restore.
¡Listo! Ahora deberías tener la aplicación backend corriendo con .NET 9 en tu máquina local.
