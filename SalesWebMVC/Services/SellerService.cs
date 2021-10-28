using SalesWebMVC.Data;
using System.Collections.Generic;
using SalesWebMVC.Models;
using System.Linq;

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

    }

}