using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Service.Interfaces;
using BusinessLogicLayer.DTOs.Response;
using BusinessLogicLayer.DTOs.Request;

namespace API.Controllers
{
    [Route("api/leave")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeavesController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        // GET: api/Leaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveResponse>>> GetLeaves()
        {
            return Ok(_leaveService.Get());
        }

        // GET: api/Leaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveResponse>> GetLeave(string id)
        {
            var leave = _leaveService.GetById(id);
            if(leave == null)
            {
                return NotFound();
            }
            return leave;
        }

        // PUT: api/Leaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<LeaveResponse>> UpdateLeave(string id, LeaveRequest leave)
        {
            var response = _leaveService.Update(id, leave);
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        // POST: api/Leaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LeaveResponse>> CreateLeave(LeaveRequest leave)
        {
            return _leaveService.Insert(leave);
        }

        // DELETE: api/Leaves/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LeaveResponse>> DeleteLeave(string id)
        {
            var leave = _leaveService.Delete(id);
            if(leave == null)
            {
                return NotFound();
            }
            return Ok(leave);
        }
    }
}
