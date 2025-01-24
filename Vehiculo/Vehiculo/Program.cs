public abstract class Vehiculo
{
    public string Marca { get; set; }

    public string Modelo { get; set; }

    public abstract void Conducir();

    public abstract void Detener()
    {
        Console.WriteLine("El vehiculo se detuvo");
    }
}

public class Coche : Vehiculo
{
    public override void Conducir()
    {
        Console.WriteLine($"Estoy conduciendo un coche de marca: {Marca} y modelo: {Modelo}");
    }

    public override void Detener()
    {
        Console.WriteLine($"El coche se detuvo de forma segura.");
    }
}

public class Bicicleta : Vehiculo
{
    public override void Conducir()
    {
        Console.WriteLine($"Pedaleando la bicicleta {Marca} {Modelo}");
    }
}
