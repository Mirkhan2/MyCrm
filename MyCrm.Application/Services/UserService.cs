using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interface;
using MyCrm.Application.Security;
using MyCrm.Application.Static_Tools;
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

      

        public async Task<AddMarketerResult> AddMarketer(AddMarketerViewModel marketer, IFormFile imageProfile)
        {

            // Upload Image

            var imageProfileName = "";

            if (imageProfile?.Length > 0)
            {
                imageProfileName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imageProfile.FileName);
                imageProfile.AddImageToServer(imageProfileName, FilePath.UploadImageProfileServer, 280, 280);
            }

            var user = new User()
            {
                FirstName = marketer.FirstName,
                Password = PasswordHelper.EncodePasswordMd5(marketer.Password),
                LastName = marketer.LastName,
                UserName = marketer.UserName,
                Email = marketer.Email,
                MobilePhone = marketer.MobilePhone,
                IntroduceName = marketer.IntroduceName,


            };
            if (!string.IsNullOrEmpty(imageProfileName))
            {
                user.ImageName = imageProfileName;
            }
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



        public async Task<FilterUserViewModel> FilterUser(FilterUserViewModel filter)
        {
            return await _userRepository.FilterUser(filter);
        }

        public async Task<EditMarketerViewModel> GetMarketerForEdit(long marketerId)
        {
            var user = await _userRepository.GetUserDetailById(marketerId);

            if (user == null)
            {
                return null;
            }

            var result = new EditMarketerViewModel()
            {
                UserId = marketerId,
                Age = user.Marketer.Age,
                Education = user.Marketer.Education,
                Email = user.Email,
                FieldStudy = user.Marketer.FieldStudy,
                FirstName = user.FirstName,
                IntroduceName = user.IntroduceName,
                IrCode = user.Marketer.IrCode,
                LastName = user.LastName,
                MobilePhone = user.MobilePhone,
                UserName = user.UserName,
                ImageName = user.ImageName
            };

            return result;
        }
        public async Task<EditMarketerResult> EditMarketer(EditMarketerViewModel marketer, IFormFile imageProfile)
        {
            var user = await _userRepository.GetUserDetailById(marketer.UserId);


            if (user == null)
            {
                return EditMarketerResult.Fail;
            }


            var imageProfileName = "";

            if (imageProfile?.Length > 0)
            {
                imageProfileName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imageProfile.FileName);
                imageProfile.AddImageToServer(imageProfileName, FilePath.UploadImageProfileServer, 280, 280);
            }




            user.Email = marketer.Email;
            //   Password = PasswordHelper.EncodePasswordMd5
            //Password = PasswordHelper.EncodePasswordMd5(marketer.pasw)
            user.FirstName = marketer.FirstName;
            user.LastName = marketer.LastName;
            user.IntroduceName = marketer.IntroduceName;
            user.MobilePhone = marketer.MobilePhone;
            user.Password = user.Password;
            user.UserName = marketer.UserName;
            if (string.IsNullOrEmpty(imageProfileName))
            {
                user.ImageName = imageProfileName;

            }

            await _userRepository.UpdateUser(user);

            var myMarketer = await _userRepository.GetMarketerById(marketer.UserId);

            myMarketer.Age = marketer.Age;
            myMarketer.Education = marketer.Education;
            myMarketer.FieldStudy = marketer.FieldStudy;
            myMarketer.IrCode = marketer.IrCode;

            if (myMarketer == null)
            {
                return EditMarketerResult.Fail;
            }

            await _userRepository.UpdateMarketer(myMarketer);

            await _userRepository.SaveChangeAsync();

            return EditMarketerResult.Success;
        }


        public async  Task<AddCustomerResult> AddCustomer(AddCustomerViewModel customerViewModel , IFormFile imageProfile)
        {

            // Upload Image

            var imageProfileName = "";

            if (imageProfile?.Length > 0)
            {
                imageProfileName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imageProfile.FileName);
                imageProfile.AddImageToServer(imageProfileName, FilePath.UploadImageProfileServer, 280, 280);
            }

            var user = new User()
            {
                FirstName = customerViewModel.FirstName,
                Password = PasswordHelper.EncodePasswordMd5(customerViewModel.Password),
                LastName = customerViewModel.LastName,
                UserName = customerViewModel.UserName,
                Email = customerViewModel.Email,
                MobilePhone = customerViewModel.MobilePhone,
                IntroduceName = customerViewModel.IntroduceName,



            };
            if (!string.IsNullOrEmpty(imageProfileName))
            {
                user.ImageName = imageProfileName;
            }

            await _userRepository.AddUser(user);
            await _userRepository.SaveChangeAsync();

            var customer = new Customer()
            {
                CompanyName = customerViewModel.CompanyName,
                Job = customerViewModel.Job,
                UserId = user.UserId
            };
            await _userRepository.AddCustomer(customer);
            await _userRepository.SaveChangeAsync();

        }

  
    }
}
