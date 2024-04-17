# SmartTalent

Prueba tecnica para el cargo de Desarrollador Backend
Presentado por: Julian Andres Fernandez
Correo: juanfedo@gmail.com

Uso: Por defecto se crearon dos usuarios para acceder al sistema:

login: admin
password: admin
EsAdministrador: true

login: user
password: user
EsAdministrador: false

Con cualquiera de esas credenciales se debe autenticar en el metodo: "api/Autenticacion" del API para generar el token y poder acceder a las diversas funcionalidades.

Solo los administradores podran acceder a los siguientes metodos:
	api/Alimento (POST)
	api/Alimento (PUT)
	api/Alimento (DELETE)
	api/Usuario (POST)
	api/Usuario (PUT)
	api/Usuario (DELETE)
	api/Catalogo (POST)
	api/Catalogo/AgregarAlimentos (POST)
	api/Catalogo/BorrarAlimento (POST)
