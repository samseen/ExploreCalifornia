using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExploreCalifornia.DataAccess;
using ExploreCalifornia.DataAccess.Models;
using ExploreCalifornia.DTOs;

namespace ExploreCalifornia.Controllers
{
    public class TourController : ApiController
    {
        private AppDataContext _context = new AppDataContext();
        public List<Tour> Get(bool freeOnly = false)
        {
            var query = _context.Tours.AsQueryable();

            if (freeOnly) query = query.Where(i => i.Price == 0.0m);

            return query.ToList();
        }

        public List<Tour> PostSearch(TourSearchRequestDto request)
        {
            var query = _context.Tours.AsQueryable()
                .Where(i => i.Price >= request.MinPrice && i.Price <= request.MaxPrice);

            return query.ToList();
        }
        
        public IHttpActionResult Put(int id, Tour tour)
        {
            return Ok($"{id}: {tour.Name}");
        }

        public IHttpActionResult Patch()
        {
            return Ok("Patch");
        }
        public IHttpActionResult Delete()
        {
            return Ok("Delete");
        }
    }
}