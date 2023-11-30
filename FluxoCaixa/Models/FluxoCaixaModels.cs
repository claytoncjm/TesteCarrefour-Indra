using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.Models
{
    public class FluxoCaixaModels
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Produto")]
        public string ?NomeProduto { get; set; }
        [Display(Name = "Valor do Produto")]
        public double ValorProduto { get; set; }
        [Display(Name = "Forma de Pagamento")]
        public string ?FormaPgto { get; set; }
        

    }
}
