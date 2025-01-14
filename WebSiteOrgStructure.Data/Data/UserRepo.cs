﻿using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OnlyOrgStructure.Data;
using WebSiteOrgStructure.Data.Interface;
using WebSiteOrgStructure.Dtos;
using WebSiteOrgStructure.Models;

namespace WebSiteOrgStructure.Data;

public class UserRepo : IUserRepo
{
    private readonly DbContextConfigurer _context;

    public UserRepo(DbContextConfigurer context)
    {
        _context = context;
    }

    public async Task CreateUserAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        ArgumentNullException.ThrowIfNull(user.Name);
        await _context.AddAsync(user);
    }

    public void DeleteUserAsync(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        _context.Remove(user);
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);
    }

    public async Task<List<DepartmentStruct>> GetCountUserAndRole()
    {
        return await _context.Users
        .AsQueryable()
        .Where(x => x.DepartmentName !=null)
        .GroupBy(x => x.DepartmentName)
        .Select(x => new
        {
            DepartmentName = x.Key,
            Users = x.Select(l => l.Surname).Distinct().Count(),
            Roles = x.Select(l => l.Role).Distinct().Count(),
        })
        .Select(y => new DepartmentStruct()
        {
            DepartmentName = y.DepartmentName,
            Users = y.Users,
            Roles = y.Roles
        })
        .ToListAsync();
    }

    public async Task<List<User>> GetUsersListAsync()
    {
        return await _context.Users
            .AsQueryable()
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
