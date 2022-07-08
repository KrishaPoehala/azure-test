﻿using dz3Binary.DAL.Entities;
using dz3Binary.DAL.Helpers;

namespace dz3Binary.DAL.DataLoaders;

public abstract class BaseDataLoader<T> : IDataLoader<T>
{
    protected static ICollection<Entities.Task> _tasks;
    protected static ICollection<User> _users;
    protected static ICollection<Project> _projects;
    protected static ICollection<Team> _teams;

    //cannot use await
    static BaseDataLoader()
    {
        _tasks = JsonHelper.Get<Entities.Task>("Tasks").GetAwaiter().GetResult();
        _users = JsonHelper.Get<User>("Users").GetAwaiter().GetResult();
        _projects = JsonHelper.Get<Project>("Projects").GetAwaiter().GetResult();
        _teams = JsonHelper.Get<Team>("Teams").GetAwaiter().GetResult();
    }
    public abstract ICollection<T> Load();
}
