using AutoMapper;
using Domain.Argumentos;
using Domain.Entidades;
using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using Sentry.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zicard.API.Common.Extensoes;
using Zicard.API.Common.Recursos;

namespace Infra.Servicos
{
    public class ServicoUsuario : Notifiable, IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario, IMapper mapper, IConfiguration configuration)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string Autenticar(string email, string senha)
        {
            var usuario = _repositorioUsuario.ObterPorEmailSenha(email, senha);

            if (usuario == null)
            {
                AddNotification("Autenticar", "Usuário ou senha inválidos");
                return null;
            }

            // Gera o token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    // Adicione outras claims conforme necessário
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Tempo de expiração do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public UsuarioDTO Adicionar(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                AddNotification("usuarioDTO", Mensagens.X0_NAO_INFORMADO.ToFormat("usuarioDTO"));
                return null;
            }

            var usuario = new Usuario(usuarioDTO);
            _repositorioUsuario.Adicionar(usuario);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public UsuarioDTO Editar(UsuarioDTO usuarioDTO)
        {
            var usuario = _repositorioUsuario.ObterPorId(usuarioDTO.Id);
            if (usuario == null)
            {
                AddNotification("usuarioDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            usuario.Atualizar(usuarioDTO);
            var response = _repositorioUsuario.Editar(usuario).ToMap<Usuario, UsuarioDTO>(_mapper);

            return response;
        }

        public IEnumerable<UsuarioDTO> Listar()
        {
            var usuarios = _repositorioUsuario.Listar();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }

        public UsuarioDTO ObterPorId(int id)
        {
            var usuario = _repositorioUsuario.ObterPorId(id);
            if (usuario == null)
            {
                AddNotification("usuarioDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public void Remover(int id)
        {
            var usuario = _repositorioUsuario.ObterPorId(id);
            if (usuario == null)
            {
                AddNotification("usuarioDTO", Mensagens.DADOS_NAO_ENCONTRADOS);
                return;
            }

            _repositorioUsuario.Remover(id);
        }
    }
}