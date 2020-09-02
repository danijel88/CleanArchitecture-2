using System;
using CleanArchitecture.Application.CrossCuttingConcerns.Mapping;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Models
{
    public static class TodoMapper
    {
        public static TodoResponseModel ToDetails(this Todo todo)
        {
            if (todo == null)
                throw new ArgumentException(nameof(todo));

            return AutoMapping.Mapper().Map<TodoResponseModel>(todo);
        }

        public static Todo ToEntity(this TodoCreateRequestModel request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return AutoMapping.Mapper().Map<Todo>(request);
        }
    }
}