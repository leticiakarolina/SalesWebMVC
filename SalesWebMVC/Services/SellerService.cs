using SalesWebMVC.Data;
using System.Collections.Generic;
using SalesWebMVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        public SellerService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller thisObj)
        {
            _context.Add(thisObj);
            _context.SaveChanges();
        }

        public Seller FindbyId(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update (Seller thisObj)
        {
            if(!_context.Seller.Any(x => x.Id == thisObj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(thisObj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }

}
