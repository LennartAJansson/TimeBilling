namespace TimeBilling.Contracts;

using System;
using System.Collections.Generic;

using MediatR;

public record PersonResponse(int PersonId, string Name);

public record CreatePersonCommand(string Name) : IRequest<PersonResponse>;

public record UpdatePersonCommand(int PersonId, string Name) : IRequest<PersonResponse>;

public record DeletePersonCommand(int PersonId) : IRequest<PersonResponse>
{
    public static DeletePersonCommand Create(int id) => new DeletePersonCommand(id);
}

public record GetPersonQuery(int PersonId) : IRequest<PersonResponse>
{
    public static GetPersonQuery Create(int id) => new GetPersonQuery(id);
}

public record GetPeopleQuery() : IRequest<IEnumerable<PersonResponse>>
{
    public static GetPeopleQuery Create() => new GetPeopleQuery();
}
