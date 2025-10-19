using AppSorvesanWeb.Data;
using AppSorvesanWeb.DTOs;
using AppSorvesanWeb.Models;
using Azure.Messaging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace AppSorvesanWeb.Services;

public class PedidoService : IPedidoService
{
    private readonly SorveteriaContext _context;

    public PedidoService(SorveteriaContext context)
    {
        _context = context;
    }

    public async  Task<IEnumerable<Pedido>> GetPedidos()
    {
        var pedido = await _context.Pedidos.ToListAsync();

        return (pedido);
    }

    public async Task<Pedido?> PedidoPorId(Guid id)
    {
        var pedidos = await _context.Pedidos.FindAsync(id);

        return (pedidos);
    }

    public async Task<Pedido> CriarPedido(PedidosCreateDTOs pedidosCreate)
    {
        var pedidoNew = new Pedido()
        {
            NomeCliente = pedidosCreate.NomeCliente,
            TelefoneCliente = pedidosCreate.TelefoneCliente,
            Observacoes = pedidosCreate.Observacoes,
            Status = "novo",
            ValorTotal = 0,
        };

        _context.Pedidos.Add(pedidoNew);
        await _context.SaveChangesAsync();

        return (pedidoNew);

    }

    public async Task<bool> DeletarPedido(int numeroDoPedido)
    {

        var deletPedido = await _context.Pedidos.FirstOrDefaultAsync(del => del.NumeroPedido == numeroDoPedido);

        if(deletPedido == null)
        {
            return false;
        }

        _context.Pedidos.Remove(deletPedido!);
        await _context.SaveChangesAsync();

        return true;
        
    }

    public async Task<Pedido?> AtualizarPedido(int numeroDoPedido, AtualizarPedidoDTO atualizar)
    {
        var pedido = await _context.Pedidos.FirstOrDefaultAsync(ped => ped.NumeroPedido == numeroDoPedido);

        if(pedido == null)
        {
            return null;
        }
        pedido.Status = atualizar.Status!;
        pedido.Observacoes = atualizar.Observacoes;

        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
        return pedido;
    }
}
