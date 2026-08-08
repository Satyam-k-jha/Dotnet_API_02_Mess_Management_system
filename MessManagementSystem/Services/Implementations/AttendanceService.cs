using AutoMapper;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
using MessManagementSystem.Repositories.Implementations;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Interfaces;

namespace MessManagementSystem.Services.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IMapper mapper;
        private readonly IAttendanceRepository attendanceRepository;

        public AttendanceService(IMapper mapper, IAttendanceRepository attendanceRepository)
        {
            this.mapper = mapper;
            this.attendanceRepository = attendanceRepository;
        }

        public async Task<AttendanceDto> AddAttendanceAsync(AddAttendanceDto addAttendanceDto)
        {
            //Dto -> Model
            var attendance = mapper.Map<Attendance>(addAttendanceDto);
            attendance = await attendanceRepository.CreateAsync(attendance);
            //Model to Dto
            return mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<AttendanceDto?> DeleteAttendanceAsync(Guid id)
        {
            var attendance = await attendanceRepository.DeleteAsync(id);
            if (attendance == null)
            {
                return null ;
            }
            //Model to Dto
            return mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<List<AttendanceDto>> GetAllAttendancesAsync()
        {
            var attendances = await attendanceRepository.GetAllAsync();
            return mapper.Map<List<AttendanceDto>>(attendances);
            
        }

        public async Task<AttendanceDto> GetAttendanceByIdAsync(Guid id)
        {
            var attendance = await attendanceRepository.GetByIdAsync(id);
            if (attendance == null)
            {
                return null;

            }
            //Model to Dto
            return mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<List<AttendanceResponseByUserDto>> GetAttendanceByStudentIdAsync(Guid studentId)
        {
            var attendance = await attendanceRepository.GetByStudentIdAsync(studentId);
            if(attendance == null)
            {
                return null;
            }
            return mapper.Map<List<AttendanceResponseByUserDto>>(attendance);
        }

        public async Task<List<AttendanceResponseByUserDto>> GetAttendanceByUserIdAsync(Guid userId)
        {
            var attendance = await attendanceRepository.GetByUserIdAsync(userId);
            if (attendance == null)
            {
                return null;
            }
            return mapper.Map<List<AttendanceResponseByUserDto>>(attendance);
        }

        public async Task<AttendanceDto> UpdateAttendanceAsync(Guid id, UpdateAttendanceDto updateAttendanceDto)
        {
            var attendance = mapper.Map<Attendance>(updateAttendanceDto);
            attendance = await attendanceRepository.UpdateAsync(id, attendance);
            if (attendance == null)
            {
                return null;
            }
            //Model to Dto
            return mapper.Map<AttendanceDto>(attendance);
        }
    }
}
