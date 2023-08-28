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

        public EmployeeResponse Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeResponse> Get()
        {
            var employees = _unitOfWork.GetRepository<Employee>().Get();
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResponse>>(employees);
        }

        public EmployeeResponse GetById(string id)
        {
            var employee = _unitOfWork.GetRepository<Employee>().Get(id);
            return _mapper.Map<EmployeeResponse>(employee);
        }

        public async Task<EmployeeResponse> GetByEmailAndPassword(AuthenticationRequest request)
        {
            var employee = _unitOfWork.GetRepository<Employee>().GetAsync().Result.Where(x => x.Email.Equals(request.Email)).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception("Email does not exist");
            } else if (!employee.PasswordHash.SequenceEqual(EncryptionUtils.encrypt(request.Password, employee.PasswordKey)))
            {
                throw new Exception("Password does not exist");
            }
            else
            {
                var response = _mapper.Map<EmployeeResponse>(employee);
                response.Token = GenerateJwt(employee);
                return response;
            }
        }

        public EmployeeResponse Insert(EmployeeRequest request)
        {
            var employee = _unitOfWork.GetRepository<Employee>().Get().Where(x => request.IdentityCardNumber.Equals(x.IdentityCardNumber)).FirstOrDefault();
            if (employee != null)
            {
                if(employee.IsFormer)
                {
                    _mapper.Map<EmployeeRequest, Employee>(request,employee);
                    _unitOfWork.GetRepository<Employee>().Update(employee);
                    return _mapper.Map<EmployeeResponse>(employee);
                }
                else
                {
                    throw new Exception("Employee is currently working for the company.");
                }
            }
            else
            {
                employee = _mapper.Map<Employee>(request);
                EncryptionUtils.encrypt(request.Password, out byte[] key, out byte[] hash);
                employee.PasswordHash = hash;
                employee.PasswordKey = key;
                _unitOfWork.GetRepository<Employee>().Insert(employee);
                return _mapper.Map<EmployeeResponse>(employee);
            }
        }

        public EmployeeResponse Update(EmployeeRequest request)
        {
            throw new NotImplementedException();
        }

        private string GenerateJwt(Employee employee)
        {
            // create claim identity
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.PrimarySid, employee.EmployeeId),
                new Claim(ClaimTypes.Sid, employee.IdentityCardNumber)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            // create signing credential
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            // create jwt
            var handler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };
            var securityToken = handler.CreateToken(descriptor);
            var jwt = handler.WriteToken(securityToken);
            return jwt;
        }
    }
}
