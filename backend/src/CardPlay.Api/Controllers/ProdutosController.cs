using CardPlay.Application.Contratos.Servicos;
using CardPlay.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CardPlay.Api.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoServico _produtoServico;

    public ProdutosController(IProdutoServico produtoServico)
    {
        _produtoServico = produtoServico;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<ProdutoResposta>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyCollection<ProdutoResposta>>> Listar(CancellationToken cancellationToken)
    {
        var produtos = await _produtoServico.ListarAsync(cancellationToken);
        return Ok(produtos);
    }
}
