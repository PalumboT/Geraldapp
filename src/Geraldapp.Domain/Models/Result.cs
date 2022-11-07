namespace Geraldapp.Domain.Models;

using FluentValidation.Results;

/// <summary>
/// The result
/// </summary>
public partial class Result
{
    /// <summary>
    /// Gets or sets a value indicating whether this result type is success.
    /// </summary>
    /// <value>
    /// <c>true</c> if this result type is success; otherwise, <c>false</c>.
    /// </value>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets the errors.
    /// </summary>
    /// <value>
    /// The errors.
    /// </value>
    public IEnumerable<ResultError> Errors { get; set; }

    /// <summary>
    /// Successes this instance.
    /// </summary>
    /// <returns></returns>
    public static Result Success()
    {
        return new Result
        {
            IsSuccess = true
        };
    }

    /// <summary>
    /// Errors the specified errors.
    /// </summary>
    /// <param name="errors">The errors.</param>
    /// <returns></returns>
    public static Result Error(IEnumerable<ResultError> errors)
    {
        return new Result
        {
            IsSuccess = false,
            Errors = errors
        };
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="List{ResultError}"/> to <see cref="Result"/>.
    /// </summary>
    /// <param name="errors">The errors.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Result(List<ResultError> errors)
    {
        return new Result
        {
            IsSuccess = false,
            Errors = errors
        };
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="ResultError"/> to <see cref="Result"/>.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Result(ResultError error)
    {
        return new Result()
        {
            IsSuccess = false,
            Errors = new List<ResultError> { error }
        };
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="List{ValidationFailure}"/> to <see cref="Result"/>.
    /// </summary>
    /// <param name="errors">The errors.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Result(List<ValidationFailure> errors)
    {
        return new Result()
        {
            IsSuccess = false,
            Errors = errors.Select(e => new ResultError
            {
                Code = int.Parse(e.ErrorCode),
                Description = e.ErrorMessage
            })
        };
    }
}

/// <summary>
/// The result
/// </summary>
/// <typeparam name="TValue">The type of the value.</typeparam>
public partial class Result<TValue>
{
    /// <summary>
    /// Gets or sets a value indicating whether this result type is success.
    /// </summary>
    /// <value>
    /// <c>true</c> if this result type is success; otherwise, <c>false</c>.
    /// </value>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets the errors.
    /// </summary>
    /// <value>
    /// The errors.
    /// </value>
    public IEnumerable<ResultError> Errors { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public TValue Value { get; set; }

    /// <summary>
    /// Performs an implicit conversion from <see cref="TValue"/> to <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Result<TValue>(TValue value)
    {
        return new Result<TValue>()
        {
            IsSuccess = true,
            Value = value
        };
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="List{ResultError}"/> to <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="errors">The errors.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Result<TValue>(List<ResultError> errors)
    {
        return new Result<TValue>
        {
            IsSuccess = false,
            Errors = errors
        };
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="ResultError"/> to <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="error">The error.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Result<TValue>(ResultError error)
    {
        return new Result<TValue>()
        {
            IsSuccess = false,
            Errors = new List<ResultError> { error }
        };
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="List{ValidationFailure}"/> to <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="errors">The errors.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Result<TValue>(List<ValidationFailure> errors)
    {
        return new Result<TValue>()
        {
            IsSuccess = false,
            Errors = errors.Select(e => new ResultError
            {
                Code = int.Parse(e.ErrorCode),
                Description = e.ErrorMessage
            })
        };
    }
}
