using AutoMapper;
using Vet_CIMAGT.Core.DTOs;
using Vet_CIMAGT.Core.Models;
using Vet_CIMAGT.DataLayer.Repositorys.Interface;
using Vet_CIMAGT.Service.Service.Interface;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Vet_CIMAGT.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<List<UserDTOs>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return _mapper.Map<List<UserDTOs>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los usuarios: {ex.Message}");
            }
        }

        public async Task<UserDTOs> GetUserByIdAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }
                return _mapper.Map<UserDTOs>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el usuario: {ex.Message}");
            }
        }

        public async Task CreateUserAsync(UserCreateDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.PasswordHash);
                await _userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear el usuario: {ex.Message}");
            }
        }

        public async Task UpdateUserAsync(UserUpdateDTO userDTO)
        {
            try
            {
                var existingUser = await _userRepository.GetByIdAsync(userDTO.Id);
                if (existingUser == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }
                _mapper.Map(userDTO, existingUser);
                await _userRepository.UpdateAsync(existingUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el usuario: {ex.Message}");
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            try
            {
                var existingUser = await _userRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }
                await _userRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el usuario: {ex.Message}");
            }
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                // Buscar usuario por email
                var user = await _userRepository.GetByEmailAsync(loginDTO.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PasswordHash))
                {
                    throw new Exception("Credenciales inválidas.");
                }

                // Generar token JWT
                return GenerateJwtToken(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el login: {ex.Message}");
            }
        }

        private string GenerateJwtToken(User user)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim("id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.UtcNow.AddHours(2),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar el token JWT: {ex.Message}");
            }
        }
    }
}


