using System;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Models
{
    /// <summary>
    ///     https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection
    /// </summary>
    public static class TodoMapper
    {
        public static Todo ToEntity(this TodoCreateRequestModel request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return Mapper.Mapper().Map<Todo>(request);
        }

        public static TodoResponseModel ToDetails(this Todo todo)
        {
            if(todo == null)
                throw new ArgumentException(nameof(todo));

            return Mapper.Mapper().Map<TodoResponseModel>(todo);
        }
    }
}