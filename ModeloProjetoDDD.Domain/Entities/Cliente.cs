namespace ModeloProjetoDDD.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sobrenome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; private set; }

        public void AlterarStatusCliente(bool novoStatus)
        {
            Ativo = novoStatus;
        }
    }
}
