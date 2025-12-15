using Interview_Test.Infrastructure;
using Interview_Test.Models;
using Interview_Test.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Interview_Test.Repositories;

public class UserRepository : IUserRepository
{
    private readonly InterviewTestDbContext _context;

    public UserRepository(InterviewTestDbContext context)
    {
        _context = context;
    }

    public dynamic GetUserById(string id)
    {
        var user = _context.UserTb
            .Include(u => u.UserProfile)
            .Include(u => u.UserRoleMappings)
                .ThenInclude(urm => urm.Role)
                    .ThenInclude(r => r.Permissions)
            .FirstOrDefault(u => u.UserId == id);

        if (user == null)
        {
            return null;
        }

        // Flatten structure และ distinct permissions
        var allPermissions = user.UserRoleMappings
            .SelectMany(urm => urm.Role.Permissions)
            .Select(p => p.PermissionName)
            .Distinct()
            .OrderBy(p => p)
            .ToList();

        return new
        {
            Id = user.Id,
            UserId = user.UserId,
            Username = user.Username,
            FirstName = user.UserProfile?.FirstName,
            LastName = user.UserProfile?.LastName,
            Age = user.UserProfile?.Age,
            Roles = user.UserRoleMappings.Select(urm => new
            {
                RoleId = urm.Role.RoleId,
                RoleName = urm.Role.RoleName
            }).ToList(),
            Permissions = allPermissions
        };
    }

    public List<dynamic> GetAllUsers()
    {
        var users = _context.UserTb
            .Include(u => u.UserProfile)
            .Include(u => u.UserRoleMappings)
                .ThenInclude(urm => urm.Role)
                    .ThenInclude(r => r.Permissions)
            .OrderBy(u => u.UserId)
            .ToList();

        return users.Select(user =>
        {
            var allPermissions = user.UserRoleMappings
                .SelectMany(urm => urm.Role.Permissions)
                .Select(p => p.PermissionName)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            return (dynamic)new
            {
                Id = user.Id,
                UserId = user.UserId,
                Username = user.Username,
                Name = $"{user.UserProfile?.FirstName} {user.UserProfile?.LastName}",
                Age = user.UserProfile?.Age,
                RoleCount = user.UserRoleMappings.Count,
                PermissionCount = allPermissions.Count
            };
        }).ToList();
    }

    public int CreateUser(UserModel user)
    {
        _context.UserTb.Add(user);
        return _context.SaveChanges();
    }
}