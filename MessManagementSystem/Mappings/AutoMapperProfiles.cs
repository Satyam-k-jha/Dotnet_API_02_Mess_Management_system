using AutoMapper;
using MessManagementSystem.Models.Domain;
using MessManagementSystem.Models.DTO;
namespace MessManagementSystem.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, AddStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            CreateMap<Student, StudentSummaryDto>().ReverseMap();
            CreateMap<Student, StudentWithAttendanceDto>().ReverseMap();
            CreateMap<Attendance, AttendanceDto>().ReverseMap();
            CreateMap<Attendance, AddAttendanceDto>().ReverseMap();
            CreateMap<Attendance, UpdateAttendanceDto>().ReverseMap();
            CreateMap<Attendance, AttendanceSummaryDto>().ReverseMap();
            CreateMap<Attendance, AttendanceResponseByUserDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, AddFoodDto>().ReverseMap();
            CreateMap<Food, UpdateFoodDto>().ReverseMap();
            CreateMap<Food, FoodWithMenuDto>().ReverseMap();
            CreateMap<Food, FoodSummaryDto>().ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Menu, AddMenuDto>().ReverseMap();
            CreateMap<Menu, UpdateMenuDto>().ReverseMap();
            CreateMap<Menu, MenuWithFoodDto>().ReverseMap();
            CreateMap<Menu, MenuSummaryDto>().ReverseMap();
            CreateMap<User, ResponseUserDto>().ReverseMap();


        }
    }
}
