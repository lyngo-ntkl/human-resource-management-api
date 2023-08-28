using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.DTOs.Request;
using BusinessLogicLayer.DTOs.Response;
using BusinessLogicLayer.Service.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class LeaveService : ILeaveService
    {
        private static IUnitOfWork _unitOfWork;
        private static IMapper _mapper;

        public LeaveService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public LeaveResponse Delete(string id)
        {
            var leave = _unitOfWork.GetRepository<Leave>().Delete(_mapper.Map<Guid>(id));
            return _mapper.Map<LeaveResponse>(leave);
        }

        public IEnumerable<LeaveResponse> Get()
        {
            var leaves = _unitOfWork.GetRepository<Leave>().Get();
            return _mapper.Map<IEnumerable<Leave>, IEnumerable<LeaveResponse>>(leaves);
        }

        public LeaveResponse GetById(string id)
        {
            var leave = _unitOfWork.GetRepository<Leave>().Get(_mapper.Map<Guid>(id));
            return _mapper.Map<LeaveResponse>(leave);
        }

        public LeaveResponse Insert(LeaveRequest request)
        {
            var leave = _mapper.Map<Leave>(request);
            return _mapper.Map<LeaveResponse>(_unitOfWork.GetRepository<Leave>().Insert(leave));
        }

        public LeaveResponse Update(string id, LeaveRequest request)
        {
            var leave = _unitOfWork.GetRepository<Leave>().Get(_mapper.Map<Guid>(id));
            if (leave == null)
            {
                throw new Exception("Leave id doesn't exist");
            }
            _mapper.Map<LeaveRequest, Leave>(request, leave);
            _unitOfWork.GetRepository<Leave>().Update(leave);
            return _mapper.Map<LeaveResponse>(leave);
        }
    }
}
