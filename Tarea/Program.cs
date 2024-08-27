/// Interface para Mensaje
public interface IMensaje
{
    string ObtenerContenido();
}

// Mensaje Base
public class MensajeBase : IMensaje
{
    // Método que devuelve el contenido del mensaje
    public string ObtenerContenido()
    {
        return "Tu código de verificación de tu cuenta GitHub en 2 pasos es: 5467";
    }
}

// Clase base (Abstracta) para los decoradores.
public abstract class MensajeDecorador : IMensaje
{
    protected IMensaje mensajeDecorado; // Este es un atributo que se encarga de proteger el mensaje a decorar

    // Constructor que se encarga de recibir y guardar el mensaje
    public MensajeDecorador(IMensaje mensaje)
    {
        mensajeDecorado = mensaje;
    }

    // Se sobreescribe el método, que se encarga de obtener el contenido del mensaje
    public virtual string ObtenerContenido()
    {
        return mensajeDecorado.ObtenerContenido();
    }
}

// Decorador que se encarga de "encriptar" el mensaje
public class EncriptarMensaje : MensajeDecorador
{
    // Constructor que recibe y guarda el mensaje
    public EncriptarMensaje(IMensaje mensaje) : base(mensaje) { }

    // Método que modifica el contenido del mensaje simulando la fase de encriptación
    public override string ObtenerContenido()
    {
        return "Fase Encriptación --> " + base.ObtenerContenido();
    }
}

// Decorador que se encarga de comprimir el mensaje
public class ComprimirMensaje : MensajeDecorador
{
    // Constructor que recibe y guarda el mensaje
    public ComprimirMensaje(IMensaje mensaje) : base(mensaje) { }

    // Método que modifica el contenido del mensaje simulando la fase de compresión
    public override string ObtenerContenido()
    {
        return "Fase Compresión --> " + base.ObtenerContenido();
    }
}

// Decorador que firma el mensaje
public class FirmarMensaje : MensajeDecorador
{
    // Constructor que recibe y guarda el mensaje
    public FirmarMensaje(IMensaje mensaje) : base(mensaje) { }

    // Método que añade una firma al mensaje
    public override string ObtenerContenido()
    {
        return base.ObtenerContenido() + " --> Fase Firma";
    }
}

public class Programa
{
    public static void Main(string[] args)
    {
        // Se crea el mensaje base
        IMensaje mensaje = new MensajeBase();

        // Se aplican los decoradores
        mensaje = new EncriptarMensaje(mensaje); // Encriptar
        mensaje = new ComprimirMensaje(mensaje); // Comprimir
        mensaje = new FirmarMensaje(mensaje); // Firmar

        // Finalmente se imprime el mensaje base, con todos los decoradores agregados
        Console.WriteLine(mensaje.ObtenerContenido());
    }
}