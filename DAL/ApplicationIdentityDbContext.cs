using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualFair.Models;

namespace VirtualFair.Data
{
    public class ApplicationIdentityDbContext:IdentityDbContext<User>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {

        }
        public DbSet<Authorization> Authorization { get; set; }
        public DbSet<Conference> Conference { get; set; }
        public DbSet<Fair> Fair { get; set; }
        public DbSet<FairJoiner> FairJoiner { get; set; }
        public DbSet<FairMedia> FairMedia { get; set; }
        public DbSet<FairType> FairType { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<GroupMember> GroupMember { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Speaker> Speaker { get; set; }
        public DbSet<Stand> Stand { get; set; }
        public DbSet<StandMedia> StandMedia { get; set; }
        public DbSet<StandType> StandType { get; set; }
        //     public DbSet<User> User { get; set; }
        public DbSet<WaitingRoom> WaitingRoom { get; set; }
        public DbSet<WaitingRoomMember> WaitingRoomMember { get; set; }
    }
}
