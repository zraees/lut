// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BCD.Domain.Interfaces;
using BCD.Domain.Interfaces.Services;

namespace BCD.Service.User;
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //public async Task<IEnumerable<User>> GetUsersAsync()
    //{
    //    return await _unitOfWork.Users.GetUsersAsync();
    //}

    //public async Task<int> CreateUserAsync(User User)
    //{
    //    await _unitOfWork.Users.AddAsync(User);
    //    return await _unitOfWork.SaveAsync();
    //}
}
