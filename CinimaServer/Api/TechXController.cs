using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using CinimaServer.Models.dbTechX;
using CinimaServer.Tools;
using CinimaServer.ViewModel;
using System.Dynamic;
using System.Drawing.Text;

namespace CinimaServer.Api
{   
    public class TechXController : ApiController
    {
        dbTechXEntities db = new dbTechXEntities();

        public string Login(string email, string password)
        {
            if (email == "khaitruong2112@gmail.com" && password == "Cybersoft2109@@")
            {
                // Tạo một instance của JwtTokenGenerator
                var tokenGenerator = new JwtTokenGenerator(KeyToken.secretKey, KeyToken.issuer, KeyToken.audience);
                // Sử dụng instance để tạo token
                string token = tokenGenerator.GenerateToken("techx", "khaitechx@gmail.com", "123");
                return token;
            }
            return "Login fail";
        }

        //[CustomAuthorize]
        [HttpGet]
        public async Task<IHttpActionResult> getMenu()
        {
            var menu = new MenuModel();
            IEnumerable<GroupCategory> lstGroup = db.GroupCategories.ToList();
            var lstCate = db.Categories;
            IEnumerable<Item> lstItem = db.Items.ToList();

             foreach (var itemGroup in lstGroup)
            {

                menu.content[itemGroup.id]= lstCate.Where(n=> n.idGroup == itemGroup.id).Select(n => new CategoryModel { id=n.id,description=n.description,img=n.img,path=n.path,subTitle =n.subTitle,title=n.title});

                int i = 0;
                var newArray = menu.content[itemGroup.id].ToArray();
                foreach (var item in newArray)
                {
                    var lstResultItem = lstItem.Where(p => p.categoryId == item.id).Select(n => new ItemModel {categoryId = n.categoryId,id = n.id,description=n.description,name=n.name,path=n.path,img = n.img,subName = n.subName });
                    dynamic newItem = new ExpandoObject();
                    newItem.id = item.id;
                    newItem.title = item.title;
                    newItem.subTitle = item.subTitle;
                    newItem.img = item.img;
                    newItem.path = item.path;
                    newItem.description = item.description;
                    //newItem[item.id] = new Dictionary<string, ItemModel[]>();
                    AddProperty(newItem, item.id, lstResultItem);
                    //item = newItem;
                    //rs.categoryId = n.categoryId,id = n.id,description = n.description,name = n.name,path = n.path,img = n.img,subName = n.subName
                    //item.items[itemGroup.id] = lstResultItem;

                    //AddProperty(item, item.id, newItem);
               
                    newArray[i] = newItem;

                   
                    i++;

                }
                menu.content[itemGroup.id] = newArray;



            }


            return Content(HttpStatusCode.OK, menu);
        }
        private void AddProperty(dynamic obj, string propertyName, object value)
        {
            IDictionary<string, object> expandoDict = (IDictionary<string, object>)obj;
            expandoDict[propertyName] = value;
        }




    }
}


