namespace AgendaApi.Entities
{

    public class Contatos
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}
