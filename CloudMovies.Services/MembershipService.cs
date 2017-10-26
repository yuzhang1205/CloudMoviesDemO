using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudMovies.Services.Abstract;
using CloudMovies.Entities;
using CloudMovies.Repositories;
using CloudMovies.Infrastructure;
using CloudMovies.Extensions;

namespace CloudMovies.Services
{
    public class MembershipService:IMembershipService
    {
        #region Variables
        private readonly IEntityBaseRepository<User> _userRepository;
        private readonly IEntityBaseRepository<Role> _roleRepository;
        private readonly IEntityBaseRepository<UserRole> _userRoleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        public MembershipService(IEntityBaseRepository<User> userRepository,IEntityBaseRepository<Role> roleRepository,
            IEntityBaseRepository<UserRole> userRoleRepository,IEncryptionService encryptionService,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }
        #region Helper methods
        private void addUserToRole(User user,int roleId)
        {
            var role=_roleRepository.GetSingle(roleId);
            if (role==null)
            {
                throw new ApplicationException("Role doesn't exist.");
            }
            var userRole = new UserRole()
            {
                RoleId = roleId,
                UserId = user.ID
            };
            _userRoleRepository.Add(userRole);
        }
        private bool isPasswordValid(User user,string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }
        private bool isUserValid(User user,string password)
        {
            if (isPasswordValid(user,password))
            {
                return !user.IsLocked;
            }
            return false;
        }
        #endregion
        #region IMembershipService Implementation
        public User CreateUser(string username, string email, string password, int[] roles)
        {
            var existingUser = _userRepository.GetSingleByUsername(username);
            if (existingUser!=null)
            {
                throw new ApplicationException("Username is already in use");
            }
            var passwordSalt = _encryptionService.CreateSalt();
            var user = new User()
            {
                Username=username,
                Salt=passwordSalt,
                Email=email,
                IsLocked=false,
                HashedPassword=_encryptionService.EncryptPassword(password,passwordSalt),
                DateCreated=DateTime.Now
                
            };
            _userRepository.Add(user);
            _unitOfWork.Commit();
            if (roles!=null||roles.Length>0)
	        {
		        foreach (var role in roles)
	            {
		            addUserToRole(user,role);
	            }
	        }    
            _unitOfWork.Commit();
            return user;
        }
        #endregion
    }
}
