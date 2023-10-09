namespace SagitarioRhApi.Domain.DTOs
{
    public class FolhaPagamentoDTO
    {

        public int? id { get; set; }
        public int? idempresa { get; set; }
        public int? codevento { get; set; }
        public int? matfuncionario { get; set; }
        public DateTime datapgto { get; set; }
        public decimal? valor { get; set; }
        public string? nome { get; set; }
        public string? funcao { get; set; }
        public string? setor { get; set; }
        public string? evento { get; set; }
    }
}
