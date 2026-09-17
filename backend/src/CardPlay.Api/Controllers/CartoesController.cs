using CardPlay.Application.Contratos.Servicos;
using CardPlay.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CardPlay.Api.Controllers;

[ApiController]
[Route("api/cartoes")]
public class CartoesController : ControllerBase
{
    private readonly ICartaoServico _cartaoServico;

    public CartoesController(ICartaoServico cartaoServico)
    {
        _cartaoServico = cartaoServico;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CartaoResposta), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CartaoResposta>> Solicitar(
        [FromBody] SolicitarCartaoRequisicao requisicao,
        CancellationToken cancellationToken)
    {
        var cartao = await _cartaoServico.SolicitarAsync(requisicao, cancellationToken);
        return CreatedAtAction(nameof(Obter), new { id = cartao.Id }, cartao);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CartaoResposta), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CartaoResposta>> Obter(Guid id, CancellationToken cancellationToken)
    {
        var cartao = await _cartaoServico.ObterAsync(id, cancellationToken);
        return Ok(cartao);
    }

    [HttpPost("{id:guid}/recargas")]
    [ProducesResponseType(typeof(CartaoResposta), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CartaoResposta>> Recarregar(
        Guid id,
        [FromBody] RecargaRequisicao requisicao,
        CancellationToken cancellationToken)
    {
        var cartao = await _cartaoServico.RecarregarAsync(id, requisicao, cancellationToken);
        return Ok(cartao);
    }

    [HttpGet("{id:guid}/movimentacoes")]
    [ProducesResponseType(typeof(IReadOnlyCollection<MovimentacaoResposta>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IReadOnlyCollection<MovimentacaoResposta>>> ListarMovimentacoes(
        Guid id,
        CancellationToken cancellationToken)
    {
        var movimentacoes = await _cartaoServico.ListarMovimentacoesAsync(id, cancellationToken);
        return Ok(movimentacoes);
    }
}
