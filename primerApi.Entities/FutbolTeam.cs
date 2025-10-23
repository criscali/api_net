using primerApi.Abstraccions;

namespace primerApi.Entities
{
    public class FutbolTeam : IEntity
    {
        public string Nombre { get; set; }
        public int puntaje { get; set; }

        public int Id { get; set; }
    }
}
