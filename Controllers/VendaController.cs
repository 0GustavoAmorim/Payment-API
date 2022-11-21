using Microsoft.AspNetCore.Mvc;
using payment_api_desafio.Context;
using payment_api_desafio.Models;

namespace payment_api_desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {

        private readonly VendasContext _context;

        public VendaController(VendasContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            //List<Item> itens = _context.Item.Where(x => x.Id == id).ToList();
            var venda = (from Venda in _context.Venda
                                        join i in _context.Item on Venda.Id equals i.Id
                                        join v in _context.Vendedor on Venda.Vendedor.Id equals v.Id
                                    where(Venda.Id == id)
                                    select new 
                                        {
                                            Id = Venda.Id,
                                            DataVenda = Venda.DataVenda,
                                            ValorVenda = i.Valor * i.Quantidade,
                                            Vendedor = v.Nome,
                                            CpfVendedor = v.Cpf,
                                            Email = v.Email,
                                            Telefone = v.Telefone,
                                            Item = i.NomeItem,
                                            Valor = i.Valor,
                                            Quantidade = i.Quantidade,
                                            Status = Venda.Status
                                        }
                                    );
                if(venda == null)
                    return BadRequest(new { Erro = "Venda não existe"});

            return Ok(venda);
        }

        [HttpPost]
        public IActionResult Criar(Venda venda)
        {
            if (venda.Itens == null){
                return BadRequest(new { Erro = "Venda não existe"});
            }
                _context.Add(venda);
                _context.SaveChanges();

            return CreatedAtAction(nameof(ObterPorId), new {id = venda.Id}, venda);
        }


         [HttpPut("{id}")]
         public IActionResult AtualizarStatus(int id, Venda venda)
         {
             var vendaRealizada = _context.Venda.Find(id);

             if(vendaRealizada == null)
                return NotFound();

            if(vendaRealizada.DataVenda == null)
                return BadRequest(new { Erro = "A data da venda não pode ser nulo"});

            switch(vendaRealizada.Status)
            {
                case Status.AguardandoPagamento:
                    if(venda.Status == Status.PagamentoAprovado || venda.Status == Status.Cancelada)
                    {
                        vendaRealizada.Status = venda.Status;
                    }
                break;
                case Status.PagamentoAprovado:
                    if(venda.Status == Status.EnviadoParaTransportadora || venda.Status == Status.Cancelada)
                    {
                        vendaRealizada.Status = venda.Status;
                    }
                break;
                case Status.EnviadoParaTransportadora:
                    if (venda.Status == Status.Entregue)
                    {   
                        vendaRealizada.Status = venda.Status;
                    }
                break;
            }
            _context.Update(vendaRealizada);
            _context.SaveChanges();
            return Ok();
        }
    }
}