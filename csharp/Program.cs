using System;
using StackExchange.Redis;

namespace CSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conectar a Redis (usando el nombre del contenedor Redis en lugar de localhost)
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis");

            // Obtener la base de datos de Redis
            IDatabase db = redis.GetDatabase();

            // Insertar un valor en Redis
            Console.WriteLine("Enviando voto a Redis...");
            db.ListRightPush("votes", "voto-csharp");

            // Obtener y mostrar los votos de Redis
            Console.WriteLine("Mostrando votos desde Redis:");
            var votos = db.ListRange("votes");
            foreach (var voto in votos)
            {
                Console.WriteLine(voto.ToString());
            }
        }
    }
}
