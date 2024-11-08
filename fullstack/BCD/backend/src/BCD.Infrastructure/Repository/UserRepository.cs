// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BCD.Domain.Entities;
using BCD.Domain.Interfaces.Repositories;

namespace BCD.Infrastructure.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BCDDbContext context) : base(context) { }
}
