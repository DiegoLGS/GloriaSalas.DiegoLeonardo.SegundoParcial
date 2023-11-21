# Aplicación: Organización de empleados - CRUD
## Sobre mi:
Soy un estudiante en la carrera de Tecnicatura Universitaria en Programación de la UTN-FRA que está interesado en dedicarse de manera profesional en el ámbito de la programación y desarrollo de software.

##  Resumen de la aplicación:
Esta aplicación está diseñada para realizar un CRUD sobre un listado de posibles empleados de (en este ejemplo) un restaurante, ordenando y detallando la información de cada elemento a la vez que impide la duplicación de sus miembros y previene posibles errores en los ingresos de datos.  

La aplicación cuenta con un login de usuario con contraseña, teniendo registro de estos mismos con fecha y hora. Los permisos dados en la aplicación para manipular la información dependerán del perfil del usuario logeado (vendedor, supervisor o administrador).

Los elementos son almacenados en una base de datos con sus correspondientes tablas y los cambios realizados en el CRUD se verán instantaneamente reflejados en la dicha base de datos.

Puede guardar y cargar la lista de empleados con formato un JSON. Se debe manipular con cuidado la carga de una lista externa diferente a la existente en la base de datos, ya que el programa intentará modificar los datos directamente en la base de datos y no en el archivo JSON cargado.

## Diagrama de clases:
![DiagradeClases](./Imagenes/Diagrama_de_clases.png)
