// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using BCD.Domain.Interfaces;
using BCD.Domain.Interfaces.Services;

namespace BCD.Service.Business;
public class BusinessService : IBusinessService
{
    private readonly IUnitOfWork _unitOfWork;

    public BusinessService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Entities.Business>> GetBusinessesAsync()
    {
        return await _unitOfWork.Businesses.GetAllAsync("BusinessPhotos", "Category", "City", "BusinessReviews").ConfigureAwait(false);
    }

    public async Task<IEnumerable<Domain.Entities.Business>> GetFeatureBusinessesAsync()
    {
        return await _unitOfWork.Businesses.GetAsync(x => x.IsFeatured, "BusinessPhotos", "Category", "City", "BusinessReviews").ConfigureAwait(false);
    }

}
