﻿namespace TimeBilling.Maui.Models;
public sealed class Person
{
  public int PersonId { get; set; }
  public required string Name { get; set; }

  internal static Person? Clone(Person person) => new() { PersonId = person.PersonId, Name = person.Name };
}
