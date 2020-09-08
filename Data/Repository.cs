using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualFair.Models;

namespace VirtualFair.Data
{
    public class Repository : InterfaceRepository
    {
        private ApplicationIdentityDbContext _context;

        public Repository(ApplicationIdentityDbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationIdentityDbContext> Context => (IQueryable<ApplicationIdentityDbContext>)_context;


        //public IQueryable<ApplicationDbContext> Context => (IQueryable<ApplicationDbContext>)_context;

        //public IQueryable<Authorization> Authorization => _context.Authorization;
        //public IQueryable<Conference> Conference => _context.Conference;
        //public IQueryable<Fair> Fair => _context.Fair;
        //public IQueryable<FairJoiner> FairJoiner => _context.FairJoiner;
        //public IQueryable<FairMedia> FairMedia => _context.FairMedia;
        //public IQueryable<FairType> FairType => _context.FairType;
        //public IQueryable<Group> Group => _context.Group;
        //public IQueryable<GroupMember> GroupMember => _context.GroupMember;
        //public IQueryable<Message> Message => _context.Message;
        //public IQueryable<Speaker> Speaker => _context.Speaker;
        //public IQueryable<Stand> Stand => _context.Stand;
        //public IQueryable<StandMedia> StandMedia => _context.StandMedia;
        //public IQueryable<StandType> StandType => _context.StandType;
        //public IQueryable<User> User => _context.User;
        //public IQueryable<WaitingRoom> WaitingRoom => _context.WaitingRoom;
        //public IQueryable<WaitingRoomMember> WaitingRoomMember => _context.WaitingRoomMember;


    }
}

/*
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class EF_ProductRepository : IProductRepository

    {
        private ApplicationDbContext _context;

        public EF_ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Product> Products => _context.Product;

        public void CreateProduct(Product product)
        {
            product.ID = _context.Product.Count()+1;
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetById(id);
            _context.Product.Remove(product);
            if (product != null)
            {
                _context.Product.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetById(int id)
        {
            return _context.Product.FirstOrDefault(i => i.ID == id);
        }

        public void UpdateProduct(Product product)
        {
            _context.Product.Update(product);
                _context.SaveChanges();
        }
    }
}
 */
