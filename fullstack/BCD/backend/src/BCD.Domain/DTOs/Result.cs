// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BCD.Domain.DTOs;

/// <summary>
/// Result pattern is used to standard return value, with either success or failure.
/// a custom result pattern is used in this project, we can use FluentResult package also.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Result<T>
{
    public T Value { get; set; }

    public string Error { get; set; } = string.Empty;

    public bool IsSuccess { get; set; }

    private Result(T value, string error, bool isSucess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSucess;
    }

    /// <summary>
    /// implicitly convert success into Result-Obj with data also.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Result<T> Success(T value) => new(value, string.Empty, true);

    /// <summary>
    /// implicitly convert failure into Result-Obj with error details.
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public static Result<T> Failure(string error) => new(default!, error, false);
}
