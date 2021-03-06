﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Darts.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Darts.Data
{
    public class DartsDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public DartsDataInitializer(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            //onderstaande UIT COMMENTAAR zetten om db te resetten (dangereux!)
           //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                string eMailAddress = "dorine.warnez@gmail.be";
                ApplicationUser user = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress };
                await _userManager.CreateAsync(user, "YvesNick63142");
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "speler"));

                eMailAddress = "speler@darts.be";
                user = new ApplicationUser { UserName = eMailAddress, Email = eMailAddress };
                await _userManager.CreateAsync(user, "Darts123");
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "speler"));
            }
        }
    }
}