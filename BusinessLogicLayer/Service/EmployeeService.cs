using AutoMapper;
using BusinessLogicLayer.DTOs.Request;
using BusinessLogicLayer.DTOs.Response;
using DataAccessLayer.Common;
using DataAccessLayer.Entities;
using DataAccessLayer.Service.Interfaces;
using DataAccessLayer.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = configuration;
        }

        public void Delete(EmployeeRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            var employees = _unitOfWork.GetRepository<Employee>().Get();
            return employees;
        }

        public EmployeeResponse GetById(string id)
        {
            var employee = _unitOfWork.GetRepository<Employee>().Get(id);
            return _mapper.Map<EmployeeResponse>(employee);
        }

        public async Task<EmployeeResponse> GetByNameAndPassword(AuthenticationRequest request)
        {
            var employee = _unitOfWork.GetRepository<Employee>().GetAsync().Result.Where(x => request.Email.Equals(x.Email)).FirstOrDefault();
            if(employee == null)
            {
                throw new Exception("Invalid email");
            }
            else if (!employee.PasswordHash.SequenceEqual(EncryptionUtils.encrypt(request.Password, employee.PasswordKey)))
            {
                throw new Exception("Invalid password");
            }
            else
            {
                var response = _mapper.Map<EmployeeResponse>(employee);
                response.Token = CreateJwtToken(employee);
                return response;
            }
        }

        public void Insert(EmployeeRequest request)
        {
            var employee = _unitOfWork.GetRepository<Employee>().Get().Where(x => x.IdentityCardNumber.Equals(request.IdentityCardNumber)).FirstOrDefault();
            if(employee != null)
            {
                if (!employee.IsFormer)
                {
                    throw new Exception("Employee has already existed");
                }
                else
                {
                    _mapper.Map<EmployeeRequest, Employee>(request, employee);
                    _unitOfWork.GetRepository<Employee>().Update(employee);
                }
            }
            else
            {
                var employee1 = _mapper.Map<Employee>(request);
                EncryptionUtils.encrypt(request.Password, out byte[] key, out byte[] hash);
                employee.PasswordHash = hash;
                employee.PasswordKey = key;
                _unitOfWork.GetRepository<Employee>().Insert(employee);
            }
        }

        public void Update(EmployeeRequest request)
        {
            throw new NotImplementedException();
        }

        private string CreateJwtToken(Employee employee)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, employee.EmployeeId)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AppSettings:Token"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(descriptor);
            var jwt = handler.WriteToken(securityToken);
            return jwt;
        }
    }
}
