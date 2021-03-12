# Prueba Técnica para Aranda Software

Este repositorio es para presentar la prueba técnica para Aranda Software.

**Fecha de Realización:** 12-03-2021
**Autor:** Fabián Mauricio Castrillón Franco

# Descripción del problema

Desarrollar una aplicación de escritorio con framework .net Core que al ejecutarla aparezca una pantalla donde el usuario pueda obtener una foto del estado actual de la maquina.


[Imagen de Apoyo #1](https://github.com/fcastril/test-aranda/blob/main/img-readme/test01.png)

Al dar clic sobre el botón, la aplicación debe detectar y presentar:
- Sistema operativo
- Nombre de la maquina y dirección IP
- Disco duro y % actual consumido
- Ram total y % actual consumido
- Procesador y % porcentaje actual consumido

[Imagen de Apoyo #2](https://github.com/fcastril/test-aranda/blob/main/img-readme/test02.png)

Una vez detecte estos datos se deben almacenar en una base de datos no relacional (por ejemplo SQL Lite), en esta base de datos se debe registrar los datos cada vez que el usuario de clic en “Obtener datos” con su respectiva fecha y hora; adiciona se refresca la pantalla con los datos actualizados.

Adicional le aparece un botón donde el usuario puede exportar el resultado y lo descarga en un archivo txt con el nombre: aplicativo_aranda_[fecha].txt.

**El aplicativo y sus operaciones debe funcionar tanto para sistemas operativos Windows, MAC y Linux.**

Requisitos de la prueba de concepto
- El proyecto debe contener Pruebas unitarias
- Es necesario implementar sobre el motor de base de datos no relacional que permita almacenar la información capturada de la maquina, con el nombre de usuario del sistema autenticado.
- Crear una clase de acceso a datos para acceder a la información de las tablas. Si cuenta con los conocimientos necesarios también puede utilizar un ORM como Entity Framework a través del cual realice las tareas de acceso a datos.
- Es necesario construir la interfaz de usuario pero no se requieren estilos y puede estar en idioma español o ingles. Plus si usa recursos de internacionalización



