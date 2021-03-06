﻿using System.Threading.Tasks;

namespace HashCode.App.Interfaces
{
    public interface IStatementsProvider<T> where T : class
    {
        public Task<T> GetProblemStatement();
    }
}
