﻿using exo_revisions.DAL.Entities;

namespace exo_revisions.DAL.Interfaces;

public interface IUserRepository
{
    public IEnumerable<User> GetAll();
    public User? GetById(int id);
    public User? GetByEmail(string email);
    public int Create(User user);
    public User? Login(string email);
    public int GetFidelityPoints(int id);
    public void SetFidelityPoints(int id, int fidelityPoints);
}