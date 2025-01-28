# SalesDatePrediction
Aplicativo que tiene como objetivo crear órdenes y predecir cuándo ocurrirá la proxima orden por cliente de acuerdo a los registros almacenados en base de datos. La aplicación está construida con una arquitectura orientada a microservicios, utilizando .NET para el backend y Angular para el frontend.
## Tabla de contenidos
- Resumen
- Caracteristicas
- Tecnologias utilizadas
- Arquitectura del sistema
- Decisiones de diseño
- Instalación
  - Requisitos previos
  - Clonar el repositorio
  - Configuración del Backend (.Net)
  - Configuración del Frontend (Angular)
- Consideraciones especiales

## Resumen

El desarrollo del aplicativo comenzó con la revisión del diseño de la base de datos para definir las entidades, junto con sus respectivas llaves primarias y foráneas, y organizar el contexto de la aplicación. En el archivo ApplicationDbContext.cs, se configuraron las llaves primarias compuestas de la tabla OrderDetails, los esquemas correspondientes a cada tabla y la definición de las entidades necesarias para la interacción con la base de datos.

Capa de Servicios

En esta capa, se implementó el patrón Unit of Work, el cual gestiona las transacciones hacia la base de datos utilizando Entity Framework (EF). Esto permitió agilizar y automatizar acciones comunes, como obtener listas de productos, empleados o transportistas.

Para simplificar la transferencia de datos hacia el Frontend y organizar las respuestas del Backend, se construyeron los DTOs (Data Transfer Objects). Uno de los más relevantes fue el ResponseDto, utilizado como respuesta genérica en todo el aplicativo. Este contiene:

- Un booleano que indica el éxito o fracaso de la operación.
- Un mensaje descriptivo de la operación.
- Los datos que, según el caso, retorna el servicio.

Se utilizó AutoMapper para convertir las entidades en DTOs, con el objetivo de reducir código repetitivo, mejorar la legibilidad y mantener la consistencia en la capa de servicios. Entre las funcionalidades implementadas se incluyen:

- Obtener las órdenes por cliente.
- Listar empleados, transportistas y productos.
- Adicionar nuevos pedidos utilizando transacciones con EF.
- Listar clientes junto con la fecha de su último pedido y realizar una predicción de ventas futura.
- 
Con estas implementaciones, se completó la capa de servicios.

Capa de Controladores

En esta capa, se diseñaron controladores para cada módulo del aplicativo, incluyendo:

Customers (Clientes).
Employees (Empleados).
Orders (Órdenes).
Products (Productos).
Shippers (Transportistas).
Además, en el archivo Program.cs, se configuró la inyección de dependencias necesaria para la correcta operación del aplicativo. Esto incluyó:

- El contexto de datos.
- Los servicios.
- Los controladores.
- Los mapeadores (AutoMapper).
- Las políticas de seguridad (CORS).

Desarrollo del Frontend

Con el Backend listo, se procedió al desarrollo de la aplicación Frontend utilizando una arquitectura SPA (Single Page Application). Se configuraron el AppModule y el AppRouting para organizar la navegación y la estructura del aplicativo. Las principales librerías utilizadas fueron Angular Material y Bootstrap.

Dada la cantidad de tablas presentes en la aplicación, se creó un componente genérico en la carpeta shared para construir dinámicamente tablas basadas en la información proporcionada. Este componente incluye:

- Paginación.
- Ordenamiento por columnas.
- Botones habilitados para realizar acciones CRUD cuando sea necesario.

También se implementaron servicios para realizar peticiones al Backend y manejar la interacción con los datos.

Para funcionalidades específicas, como mostrar las órdenes por cliente o el formulario para crear nuevas órdenes, se utilizaron los diálogos (modals) de Angular Material. El formulario de creación de órdenes se desarrolló como un formulario reactivo, con validaciones dinámicas según cada campo proporcionado por el usuario.

## Características

- Microservicios: Arquitectura escalable y modular.
- Interfaz Intuitiva: Frontend desarrollado en Angular, SPA para una experiencia de usuario fluida.
- Predicción de Ordenes: Permite obtener predicciones de futuras fechas de venta segun regsitros en BD.
- Gestion de ordenes: Ver y crear ordenes facilmente

## Tecnologias utilizadas

### Backend
- .NET 8: Framework principal.
- ASP.NET Core: Para la creación de APIs REST.
- Entity Framework Core: ORM para la gestión de la base de datos.

### Frontend
- Angular 18: Framework de desarrollo web
- Angular Material: Componentes de interfaz de usuario

### Base de datos
- SQL Server

## Arquitectura del sistema
El sistema esta diseñado bajo una **arquitectura orientada a microservicios**, lo que permite una mayor escabilidad, flexibilidad y facilidad de mantenimiento. A continuación se detalla la estructura principal:

1. Capa de controladores
  - Como su nombre lo indica en esta capa se encuentran los controladores del aplicativo.
2. Capa de Servicios
  - En esta capa se concentra la logica de negocio conformadoa por los servicios, interfaces, DTO's y repositorios.
3. Capa de acceso a datos
  - Aqui se encuentra la conexion a la base de datos, **ApplicationDbContext**, entidades y las migraciones.

## Decisiones Técnicas
- Se eligió una arquitectura de microservicios para permitir escalabilidad independiente y facilitar el mantenimiento a largo plazo.
- Implementacion de una metodología o arquitectura de unidad de trabajo *(UnitOfWork)* para las transacciones hacia la base de datos, esto garantiza agilidad en desarrollo, puesto que las acciones simples para cada entidad quedan automatizadas y genericas.
- Uso de formularios reactivos para la creación de ordenes
- Componentes modulares: Debido a la cantidad de tablas en el aplicativo se deja una tabla generica.

## Instalación
### Requisitos previos
- .NET 8 SDK
- Node.js y npm
- Angular CLI
- SQL Server
- Git

### Clonar el repositorio
   ```
   git clone 
   ```
### Configuración del backend
1. Abrir el archivo *Sales Dates Prediction.sln*
2. Configurar la cadena de conexión hacia la base de datos en el *appsettings.json* y *appsettings.Development.json*
```
 {
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StoreSample;User Id=sa;Password=123456;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True"
  },
  "AllowedHosts": "*"
}
```
3. Tener una instancia de SQL Server
4. Ejecutar el script llamado "DBSetup.sql", el script crea la base de datos StoreSample, crea esquemas, crea tablas, crea indices inserta registros y crea vistas
5. Una vez tenga lista la BD, ejecutar el siguiente comando para iniciar el aplicativo
```
dotnet run
```
### Configuración del Frontend
1. Navega al directorio de SalesPredictioFront y instala las dependencias:
```
npm i
```
2. Configura las variables de entorno en settings.ts segun el puerto en que se despliegue el backend:
```
export const appsettings = {
    apiUrl: "http://localhost:5224"
}
```
3. Inicia el servidor
```
ng serve
```
4. Abre tu navegador en http://localhost:4200.
