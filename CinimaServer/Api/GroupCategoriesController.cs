using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CinimaServer.Models.dbTechX;
using CinimaServer.Tools;

namespace CinimaServer.Api
{
    //[CustomAuthorize]
    public class GroupCategoriesController : ApiController
    {
        private dbTechXEntities db = new dbTechXEntities();

        // GET: api/GroupCategories
        public IQueryable<GroupCategory> GetGroupCategories()
        {
            return db.GroupCategories;
        }

        // GET: api/GroupCategories/5
        [ResponseType(typeof(GroupCategory))]
        public async Task<IHttpActionResult> GetGroupCategory(string id)
        {
            GroupCategory groupCategory = await db.GroupCategories.FindAsync(id);
            if (groupCategory == null)
            {
                return NotFound();
            }

            return Ok(groupCategory);
        }

        // PUT: api/GroupCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroupCategory(string id, GroupCategory groupCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupCategory.id)
            {
                return BadRequest();
            }

            db.Entry(groupCategory).State = System.Data.Entity.EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GroupCategories
        [ResponseType(typeof(GroupCategory))]
        public async Task<IHttpActionResult> PostGroupCategory(GroupCategory groupCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupCategories.Add(groupCategory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GroupCategoryExists(groupCategory.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = groupCategory.id }, groupCategory);
        }

        // DELETE: api/GroupCategories/5
        [ResponseType(typeof(GroupCategory))]
        public async Task<IHttpActionResult> DeleteGroupCategory(string id)
        {
            GroupCategory groupCategory = await db.GroupCategories.FindAsync(id);
            if (groupCategory == null)
            {
                return NotFound();
            }

            db.GroupCategories.Remove(groupCategory);
            await db.SaveChangesAsync();

            return Ok(groupCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupCategoryExists(string id)
        {
            return db.GroupCategories.Count(e => e.id == id) > 0;
        }
    }
}