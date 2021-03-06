﻿namespace MaestroApp.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly MaestroAppDbContext _context;

        public InitialHostDbBuilder(MaestroAppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new InitialStateCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
