Ejercicio 2.a

- La relación entre las clases Cadeteria y Cadete, y las clases Cadete y Pedido son relaciones de agregación, ya que las clases en si existen independientemente, en cambio la relación entre las clases Pedido y Cliente es una relación de composición porque la relación esta planteada de una manera en que no existe un objeto Cliente sin que exista un objeto Pedido que lo contenga.

- La clase Cadeteria debe contar con los metodos Agregar Cadete, Asignar Pedido, Dar de Alta Pedido, Reasignar Pedido, Cargar Cliente y Cambiar Estado del Pedido.
Por otro lado, la clase Cadete debe tener un metodo para obtener el Jornal a Cobrar correspondiente (Carga Cliente y Cambiar Estado Pedido podrian tambien pero no segun como lo plantie).

- El constructor de la clase Cadeteria debe exigir el ingreso de los atributos nombre, telefono y lista de cadetes. La clase Cadete obliga la carga de los atributos id, nombre, direccion y telefono. En ambos casos, los datos obligatorios se obtienen a partir del archivo CSV, pero a su ves tienen otros atributos que pueden cargarse despues.
La clase Pedido cuenta con un constructor vacio y además uno en el que se exige la carga de los atributos numero, observacion, estado y de un objeto tipo cliente. Por último, el constructor de la clase Cliente exige que se carguen todos sus atributos en la declaración del objeto.


