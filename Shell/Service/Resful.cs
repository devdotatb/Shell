using Shell.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Data;
using Shell.Data.SearchData;

namespace Shell.Service
{
    public interface IResful
    {
        int? AddProductShopping(string shoppingno, string materialcode, int productqty, string shareid, int cpoint, int cbpoint);
        void AddProductInvoice(string invoiceno, string materialcode, int productqty, string userid, string shareid, int cpoint, int cbpoint);
        List<ShoppingSeachData> GetProductShoppingList(int ipage, int ipagenum, string hdfShoppingNo, string hdfproductgroup, string search);
        List<BasketSeachData> GetProductShoppingCart(string hdfShoppingNo, string acode);
        List<OrderEditSearchData> GetProductInvoiceList(string invoiceno, string acode);
        List<OrderInsertSearchData> GetProductInvoiceListAdd(int ipage, int ipagenum, string invoiceno, string acode, string search, string productgroup);
        List<ShoppingPromotionSearchData> GetProductShoppingPromotionList(string shoppingno, string acode, string materialcode);
        List<HistorySearchData> GetInvoiceList(int ipage, int ipagenum, string acode);
        void EditProductShopping(string shoppingno, string materialcode, int productqty);
        void RemoveProductShopping(string shoppingno, string materialcode);
        void EditProductInvoice(string invoiceno, string materialcode, int productqty, string userid);
        void RemoveProductInvoice(string invoiceno, string materialcode, string userid);
    }
    public class Resful : IResful
    {
        public int? AddProductShopping(string shoppingno, string materialcode, int productqty, string shareid, int cpoint, int cbpoint)
        {
            try
            {
                int irow = 0;
                using (var db = new SHELLREGContext())
                {
                    db.ShoppingDetails.Add(new ShoppingDetail()
                    {
                        ShoppingNo = shoppingno,
                        MaterialCode = materialcode,
                        ProductQty = productqty,

                        //MENGGIEUNDONE

                        //cururentpoint
                        //currentbonuspoint
                        //shareid

                    });

                    db.SaveChanges();

                    irow = db.ShoppingDetails.Where(t => t.ShoppingNo == shoppingno).Count();
                    return irow;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void AddProductInvoice(string invoiceno, string materialcode, int productqty, string userid, string shareid, int cpoint, int cbpoint)
        {
            try
            {
                string curr_date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
                string curr_time = DateTime.Now.ToString("HH:mm:ss");
                int irow = 0;
                using (var db = new SHELLREGContext())
                {
                    db.InvoiceDetails.Add(new InvoiceDetail()
                    {
                        InvoiceNo = invoiceno,
                        MaterialCode = materialcode,
                        ProductQty = productqty,
                        AddDate = curr_date,
                        AddTime = curr_time,
                        AddUserId = userid,
                        EditDate = curr_date,
                        EditTime = curr_time,

                        //MENGGIEUNDONE

                        //cururentpoint
                        //currentbonuspoint
                        //shareid
                    });

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }

        public List<ShoppingSeachData> GetProductShoppingList(int ipage, int ipagenum, string hdfShoppingNo, string hdfproductgroup, string search)
        {
            int istart = (ipage * ipagenum) - (ipage - 1);
            int iend = ipage * ipagenum;

            int page = ipagenum - 1;
            int pagesize = ipage;

            using (var db = new SHELLREGContext())
            {
                var shopp = (
                from sh in db.ShoppingHeaders.Where(t => t.ShoppingNo == hdfShoppingNo)
                join sd in db.ShoppingDetails on sh.ShoppingNo equals sd.ShoppingNo
                select new
                {
                    sd.ProductQty,
                    sd.MaterialCode,
                });
                var query = (
                    from p in db.Products.Where(t => true)
                    from SB in shopp.Where(t => t.MaterialCode == p.MaterialCode).DefaultIfEmpty()
                    select new ShoppingSeachData()
                    {
                        ProductQty = SB.ProductQty ?? 0,
                        ProductQuantityLimit = p.ProductQuantityLimit,
                        MaterialCode = p.MaterialCode,
                        ProductPic = p.ProductPic,
                        ProductName = ("SHELL<br/>" + p.ProductModel + " " + p.ProductCarType + "<br/>" + p.ProductVis + "(" + p.ProductSize + ")"),
                        ProductNameTH = p.ProductNameTh,
                        ProductNameEN = p.ProductNameEn,
                        SalesTextCode = p.SalesTextCode,
                        ProductSubPic = p.ProductSub == "สังเคราะแท้ 100%" ? "88564D" :
                                    (p.ProductSub == "น้ำมันแร่คุณภาพสูง" ? "FECB38" : (p.ProductSub == "เทคโนโลยีสังเคราะห์" ? "427D99" : (p.ProductSub == "จารบีคุณภาพสูง" ? "585958" : (p.ProductSub == "ผลิตภัณฑ์อื่นๆ" ? "DDDDDD" : "")))),
                        ProductSub = p.ProductSub,
                        CustShopType = "asd",
                        SHAREID = "a",
                        CurrentPoint = 0,
                        CurrentBonusPoint = 0,
                        ProductUnit = p.ProductUnit,
                        ProductDes = p.ProductDesc,

                        //for filter
                        BestSeller = p.BestSeller,
                        ProductGroup = p.ProductGroup,

                        //binding
                        binding_qty = 1,
                    });
                var query_enu = query.AsEnumerable();
                return GetProductShoppingList_Specify(page, pagesize, query_enu, hdfproductgroup, search);
            }
        }

        public List<ShoppingSeachData> GetProductShoppingList_Specify(int page, int pagesize, IEnumerable<ShoppingSeachData> query, string hdfproductgroup, string search)
        {
            var filtered = query;
            if (!string.IsNullOrWhiteSpace(search))
            {
                filtered = filtered.Where(t => (t.MaterialCode.ToLower().Contains(search.ToLower()) || t.SalesTextCode.ToLower().Contains(search.ToLower()) || t.ProductName.ToLower().Contains(search.ToLower()) || t.ProductNameTH.ToLower().Contains(search.ToLower()) || t.ProductNameEN.ToLower().Contains(search.ToLower())));
            }
            if (!string.IsNullOrWhiteSpace(hdfproductgroup))
            {
                if (hdfproductgroup == "สินค้าขายดี")
                {
                    filtered = filtered.Where(t => t.BestSeller == true);
                }
                else
                {
                    if (hdfproductgroup != "น้ำมันเครื่องรถยนต์" && hdfproductgroup != "น้ำมันเครื่องมอเตอร์ไซค์" && hdfproductgroup != "น้ำมันเครื่องรถบรรทุก" && hdfproductgroup != "น้ำมันเกียร์และเฟืองท้าย" && hdfproductgroup != "จารบี")
                    {
                        string[] list_not_in = { "น้ำมันเครื่องรถยนต์", "น้ำมันเครื่องมอเตอร์ไซค์", "น้ำมันเครื่องรถบรรทุก", "น้ำมันเกียร์และเฟืองท้าย", "จารบี" };
                        filtered = filtered.Where(t => !list_not_in.Contains(t.ProductGroup));
                    }
                    else
                    {
                        filtered = filtered.Where(t => t.ProductGroup == hdfproductgroup);
                    }
                }
            }
            filtered = filtered.Skip(page * pagesize).Take(pagesize);
            return filtered.ToList();
        }
        public List<OrderInsertSearchData> GetProductInvoiceListAdd(int ipage, int ipagenum, string invoiceno, string acode, string search, string productgroup)
        {
            int istart = (ipage * ipagenum) - (ipage - 1);
            int iend = ipage * ipagenum;

            int page = ipagenum - 1;
            int pagesize = ipage;

            //MENGGIEUNDONE

            /*using (var db = new SHELLREGContext())
            {
                var shopp = (
                from sh in db.ShoppingHeaders.Where(t => t.ShoppingNo == hdfShoppingNo)
                join sd in db.ShoppingDetails on sh.ShoppingNo equals sd.ShoppingNo
                select new
                {
                    sd.ProductQty,
                    sd.MaterialCode,
                });
                var query = (
                    from p in db.Products.Where(t => true)
                    from SB in shopp.Where(t => t.MaterialCode == p.MaterialCode).DefaultIfEmpty()
                    select new ShoppingSeachData()
                    {
                        ProductQty = SB.ProductQty ?? 0,
                        ProductQuantityLimit = p.ProductQuantityLimit,
                        MaterialCode = p.MaterialCode,
                        ProductPic = p.ProductPic,
                        ProductName = ("SHELL<br/>" + p.ProductModel + " " + p.ProductCarType + "<br/>" + p.ProductVis + "(" + p.ProductSize + ")"),
                        ProductSubPic = p.ProductSub == "สังเคราะแท้ 100%" ? "88564D" :
                                    (p.ProductSub == "น้ำมันแร่คุณภาพสูง" ? "FECB38" : (p.ProductSub == "เทคโนโลยีสังเคราะห์" ? "427D99" : (p.ProductSub == "จารบีคุณภาพสูง" ? "585958" : (p.ProductSub == "ผลิตภัณฑ์อื่นๆ" ? "DDDDDD" : "")))),
                        ProductSub = p.ProductSub,
                        CustShopType = "asd",
                        SHAREID = "a",
                        CurrentPoint = 0,
                        CurrentBonusPoint = 0,
                        ProductUnit = p.ProductUnit,
                        ProductDes = p.ProductDesc,

                        //for filter
                        BestSeller = p.BestSeller,
                        ProductGroup = p.ProductGroup,

                        //binding
                        binding_qty = 1,
                    });
                var query_enu = query.AsEnumerable();
                return GetProductInvoiceListAdd_Specify(query_enu, productgroup);
            }*/
            return new List<OrderInsertSearchData>();
        }

        public List<OrderInsertSearchData> GetProductInvoiceListAdd_Specify(IEnumerable<OrderInsertSearchData> query, string hdfproductgroup)
        {
            var filtered = query;

            if (hdfproductgroup != "")
            {
                if (hdfproductgroup == "สินค้าขายดี")
                {
                    filtered = filtered.Where(t => t.BestSeller == true);
                }
                else
                {
                    if (hdfproductgroup != "น้ำมันเครื่องรถยนต์" && hdfproductgroup != "น้ำมันเครื่องมอเตอร์ไซค์" && hdfproductgroup != "น้ำมันเครื่องรถบรรทุก" && hdfproductgroup != "น้ำมันเกียร์และเฟืองท้าย" && hdfproductgroup != "จารบี")
                    {
                        string[] list_not_in = { "น้ำมันเครื่องรถยนต์", "น้ำมันเครื่องมอเตอร์ไซค์", "น้ำมันเครื่องรถบรรทุก", "น้ำมันเกียร์และเฟืองท้าย", "จารบี" };
                        filtered = filtered.Where(t => !list_not_in.Contains(t.ProductGroup));
                    }
                    else
                    {
                        filtered = filtered.Where(t => t.ProductGroup == hdfproductgroup);
                    }
                }
            }
            return filtered.ToList();
        }

        public List<ShoppingPromotionSearchData> GetProductShoppingPromotionList(string shoppingno, string acode, string materialcode)
        {
            using (var db = new SHELLREGContext())
            {
                var shopp = (
                from sh in db.ShoppingHeaders.Where(t => t.ShoppingNo == shoppingno)
                join sd in db.ShoppingDetails on sh.ShoppingNo equals sd.ShoppingNo
                select new
                {
                    sd.MaterialCode,
                    sd.ProductQty,
                }).AsEnumerable();
                var inv = (
                from invd in db.InvoiceDetails.Where(t => t.Deleted == false)
                join invh in db.InvoiceHeaders.Where(t => t.Acode == acode && t.InvoiceStatusId != 4) on invd.InvoiceNo equals invh.InvoiceNo
                group invd.ProductQty by new { invd.MaterialCode } into g
                select new
                {
                    MaterialCode = g.Key.MaterialCode,
                    ProductQty = g.Sum(),
                }).AsEnumerable();

                //MENGGIEUNDONE

                /*
                var query_ = (
                    from p in db.Products.Where(t => t.ProductType == "2")
                    // ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> MISSIN ----> join pto in db.productreadeowner
                    );*/

                return new List<ShoppingPromotionSearchData>();
            }
        }




        public List<BasketSeachData> GetProductShoppingCart(string hdfShoppingNo,string acode)
        {
            using (var db = new SHELLREGContext())
            {
                var shopp = (
                from sh in db.ShoppingHeaders.Where(t => t.ShoppingNo == hdfShoppingNo)
                join sd in db.ShoppingDetails on sh.ShoppingNo equals sd.ShoppingNo
                select new
                {
                    sd.ProductQty,
                    sd.MaterialCode,
                });

                var inv = (
                from invd in db.InvoiceDetails.Where(t => t.Deleted == false)
                join invh in db.InvoiceHeaders.Where(t => t.Acode == acode && t.InvoiceStatusId != 4) on invd.InvoiceNo equals invh.InvoiceNo
                group invd.ProductQty by new { invd.MaterialCode } into g
                select new
                {
                    MaterialCode = g.Key.MaterialCode,
                    SumProductQty = g.Sum(),
                }).AsEnumerable();

                var query = (
                    from p in db.Products.Where(t => true)
                    from SB in shopp.Where(t => t.MaterialCode == p.MaterialCode)
                    from IV in inv.Where(t => t.MaterialCode == p.MaterialCode).DefaultIfEmpty()
                    select new BasketSeachData()
                    {
                        ProductQty = SB.ProductQty ?? 0,
                        ProductQuantityLimit = p.ProductType == "2" ?  p.ProductQuantityLimit - (IV.SumProductQty.HasValue ? IV.SumProductQty.Value : 0) : p.ProductQuantityLimit,
                        MaterialCode = p.MaterialCode,
                        ProductPic = p.ProductPic,
                        ProductName = ("SHELL<br/>" + p.ProductModel + " " + p.ProductCarType + "<br/>" + p.ProductVis + "(" + p.ProductSize + ")"),
                        ProductSubPic = p.ProductSub == "สังเคราะแท้ 100%" ? "88564D" :
                                    (p.ProductSub == "น้ำมันแร่คุณภาพสูง" ? "FECB38" : (p.ProductSub == "เทคโนโลยีสังเคราะห์" ? "427D99" : (p.ProductSub == "จารบีคุณภาพสูง" ? "585958" : (p.ProductSub == "ผลิตภัณฑ์อื่นๆ" ? "DDDDDD" : "")))),
                        ProductSub = p.ProductSub,
                        CustShopType = "asd",
                        SHAREID = "a",
                        CurrentPoint = 0,
                        CurrentBonusPoint = 0,
                        ProductUnit = p.ProductUnit,
                        ProductDes = p.ProductDesc,

                        //for filter
                        BestSeller = p.BestSeller,
                        ProductGroup = p.ProductGroup,

                        //binding
                        binding_qty = 1,
                    });
                var query_enu = query.AsEnumerable();
                return query_enu.ToList();
            }
        }
        public List<OrderEditSearchData> GetProductInvoiceList(string invoiceno, string acode)
        {
            using (var db = new SHELLREGContext())
            {
                var inv = (
                from sh in db.InvoiceHeaders.Where(t => t.InvoiceNo == invoiceno)
                join sd in db.InvoiceDetails on sh.InvoiceNo equals sd.InvoiceNo
                select new
                {
                    sd.ProductQty,
                    sd.MaterialCode,
                    InvoiceDetaillID = sd.Id
                });
                var query = (
                    from p in db.Products.Where(t => true)
                    from SB in inv.Where(t => t.MaterialCode == p.MaterialCode)
                    select new OrderEditSearchData()
                    {
                        ProductQty = SB.ProductQty ?? 0,
                        ProductQuantityLimit = p.ProductQuantityLimit,
                        MaterialCode = p.MaterialCode,
                        ProductPic = p.ProductPic,
                        ProductName = ("SHELL<br/>" + p.ProductModel + " " + p.ProductCarType + "<br/>" + p.ProductVis + "(" + p.ProductSize + ")"),
                        ProductSubPic = p.ProductSub == "สังเคราะแท้ 100%" ? "88564D" :
                                    (p.ProductSub == "น้ำมันแร่คุณภาพสูง" ? "FECB38" : (p.ProductSub == "เทคโนโลยีสังเคราะห์" ? "427D99" : (p.ProductSub == "จารบีคุณภาพสูง" ? "585958" : (p.ProductSub == "ผลิตภัณฑ์อื่นๆ" ? "DDDDDD" : "")))),
                        ProductSub = p.ProductSub,
                        CustShopType = "asd",
                        SHAREID = "a",
                        CurrentPoint = 0,
                        CurrentBonusPoint = 0,
                        ProductUnit = p.ProductUnit,
                        ProductDes = p.ProductDesc,

                        //for filter
                        BestSeller = p.BestSeller,
                        ProductGroup = p.ProductGroup,

                        //binding
                        binding_qty = 1,
                    });
                var query_enu = query.AsEnumerable();
                return query_enu.ToList();
            }
        }

        public void EditProductShopping(string shoppingno, string materialcode, int productqty)
        {
            using (var db = new SHELLREGContext())
            {
                var filter = db.ShoppingDetails.Where(t => t.ShoppingNo == shoppingno && t.MaterialCode == materialcode);
                if (filter.Any())
                {
                    var founded = filter.First();
                    founded.ProductQty = productqty;
                    db.SaveChanges();
                }
            }
        }

        public void RemoveProductShopping(string shoppingno, string materialcode)
        {
            using (var db = new SHELLREGContext())
            {
                var filter = db.ShoppingDetails.Where(t => t.ShoppingNo == shoppingno && t.MaterialCode == materialcode);
                if (filter.Any())
                {
                    var founded = filter.First();
                    db.ShoppingDetails.Remove(founded);
                    db.SaveChanges();
                }
            }
        }



        public void EditProductInvoice(string invoiceno, string materialcode, int productqty, string userid)
        {
            string curr_date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
            string curr_time = DateTime.Now.ToString("HH:mm:ss");
            using (var db = new SHELLREGContext())
            {
                var filter = db.InvoiceDetails.Where(t => t.InvoiceNo == invoiceno && t.MaterialCode == materialcode);
                if (filter.Any())
                {
                    var founded = filter.First();
                    founded.ProductQty = productqty;
                    founded.EditDate = curr_date;
                    founded.EditTime = curr_time;
                    founded.EditUserId = userid;
                    db.SaveChanges();
                }
            }
        }

        public void RemoveProductInvoice(string invoiceno, string materialcode, string userid)
        {
            string curr_date = DateTime.Now.ToString("dd/MM/") + DateTime.Now.Year;
            string curr_time = DateTime.Now.ToString("HH:mm:ss");
            using (var db = new SHELLREGContext())
            {
                var filter = db.InvoiceDetails.Where(t => t.InvoiceNo == invoiceno && t.MaterialCode == materialcode);
                if (filter.Any())
                {
                    var founded = filter.First();
                    founded.Deleted = true;
                    founded.EditDate = curr_date;
                    founded.EditTime = curr_time;
                    founded.EditUserId = userid;
                    db.SaveChanges();
                }
            }
        }

        public List<HistorySearchData> GetInvoiceList(int ipage, int ipagenum, string acode)
        {
            int istart = (ipage * ipagenum) - (ipage - 1);
            int iend = ipage * ipagenum;

            int page = ipagenum - 1;
            int pagesize = ipage;

            using (var db = new SHELLREGContext())
            {
                var query_ = (
                    from invh in db.InvoiceHeaders.Where(t => t.Acode == acode)
                    from invs in db.InvoiceStatuses.Where(t => t.InvoiceStatusId == invh.InvoiceStatusId)

                    select new HistorySearchData()
                    {
                        InvoiceNo = invh.InvoiceNo,
                        InvoiceDate = invh.InvoiceDate,
                        InvoiceStatusName = invs.InvoiceStatusName,
                    }
                    ).AsEnumerable();
                var skipped = query_.Skip(page * pagesize).Take(pagesize);
                return skipped.ToList();
            }
        }
    }
}
