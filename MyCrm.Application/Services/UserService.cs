using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Application.Interface;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.User;

namespace MyCrm.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AddMarketerResult> AddMarketer(AddMarketerViewModel marketer)
        {
            var user = new User()
            {
                FirstName = marketer.FirstName,
                Password = marketer.Password,
                LastName = marketer.LastName,
                UserName = marketer.UserName,
                Email = marketer.Email,
                MobilePhone = marketer.MobilePhone,
                IntroduceName = marketer.IntroduceName,

                CreateDate = DateTime.Now,

            };
                await _userRepository.AddUser(user);
            await _userRepository.SaveChangeAsync();

            var newMarketer = new Marketer()
            {
                FieldStudy = marketer.FieldStudy,
                Age = marketer.Age,
                IrCode = marketer.IrCode,
                Education = marketer.Education,
                UserId = user.UserId
            };
            await _userRepository.AddMarketer(newMarketer);
            await _userRepository.SaveChangeAsync();

            return AddMarketerResult.Success;
        }

        public async  Task<FilterUserViewModel> FilterUSer(FilterUserViewModel filter)
        {
            return await _userRepository.FilterUser(filter);
        }
    }
}
