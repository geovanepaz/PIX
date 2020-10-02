using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pix.Application.ViewModels.Cliente;
using Pix.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pix.Application.Services
{
    public interface IClienteAppService : IDisposable
    {
        Task<IEnumerable<ClienteResponse>> ObterTodosAsync();
    }

    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteResponse>> ObterTodosAsync()
        {
            var c = await _clienteRepository.Query().ToListAsync();
            return _mapper.Map<IEnumerable<ClienteResponse>>(c);
        }
        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
