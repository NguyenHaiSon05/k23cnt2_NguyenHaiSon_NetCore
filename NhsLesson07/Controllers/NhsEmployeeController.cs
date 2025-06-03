using Microsoft.AspNetCore.Mvc;
using NhsLesson07.Models;

namespace NhsLesson07.Controllers
{
    public class NhsEmployeeController : Controller
    {
        private static List<NhsEmployee> nhsListEmployees = new List<NhsEmployee>
        {
            new NhsEmployee { NhsId = 230001122, NhsName = "Nguyễn Hải Sơn", NhsBirthDay = new DateTime(2005, 05, 30), NhsEmail = "sonnguyennr@gmail.com", NhsPhone = "0388604819", NhsSalary = 12000000, NhsStatus = true },
            new NhsEmployee { NhsId = 2, NhsName = "Trần Thị B", NhsBirthDay = new DateTime(1992, 5, 15), NhsEmail = "b@example.com", NhsPhone = "0912233445", NhsSalary = 15000000, NhsStatus = true },
            new NhsEmployee { NhsId = 3, NhsName = "Lê Văn C", NhsBirthDay = new DateTime(1988, 9, 20), NhsEmail = "c@example.com", NhsPhone = "0922123456", NhsSalary = 11000000, NhsStatus = false },
            new NhsEmployee { NhsId = 4, NhsName = "Phạm Thị D", NhsBirthDay = new DateTime(1995, 3, 10), NhsEmail = "d@example.com", NhsPhone = "0933445566", NhsSalary = 13000000, NhsStatus = true },
            new NhsEmployee { NhsId = 5, NhsName = "Đỗ Văn E", NhsBirthDay = new DateTime(1991, 7, 25), NhsEmail = "e@example.com", NhsPhone = "0944567890", NhsSalary = 10000000, NhsStatus = false }
        };

        public IActionResult NhsIndex()
        {
            return View(nhsListEmployees);
        }

        // GET: /NhsEmployee/NhsCreate
        public IActionResult NhsCreate()
        {
            var nhsModel = new NhsEmployee();
            return View(nhsModel);
        }

        // POST: /NhsEmployee/NhsCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhsCreate(NhsEmployee nhsModel)
        {
            try
            {
                // Tự động sinh mã nếu cần
                if (nhsModel.NhsId == 0)
                {
                    nhsModel.NhsId = nhsListEmployees.Max(e => e.NhsId) + 1;
                }
                nhsListEmployees.Add(nhsModel);
                return RedirectToAction(nameof(NhsIndex));
            }
            catch
            {
                return View(nhsModel);
            }
        }

        // GET: /NhsEmployee/NhsEdit/5
        public IActionResult NhsEdit(int id)
        {
            var nhsModel = nhsListEmployees.FirstOrDefault(x => x.NhsId == id);
            return View(nhsModel);
        }

        // POST: /NhsEmployee/NhsEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhsEdit(int id, NhsEmployee nhsModel)
        {
            try
            {
                for (int i = 0; i < nhsListEmployees.Count; i++)
                {
                    if (nhsListEmployees[i].NhsId == id)
                    {
                        nhsListEmployees[i] = nhsModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NhsIndex));
            }
            catch
            {
                return View(nhsModel);
            }
        }

        // GET: /NhsEmployee/NhsDetails/5
        public ActionResult NhsDetails(int id)
        {
            var nhsModel = nhsListEmployees.FirstOrDefault(x => x.NhsId == id);
            return View(nhsModel);
        }

        // GET: /NhsEmployee/NhsDelete/5
        public ActionResult NhsDelete(int id)
        {
            var nhsModel = nhsListEmployees.FirstOrDefault(x => x.NhsId == id);
            return View(nhsModel);
        }

        // POST: /NhsEmployee/NhsDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhsDelete(int id, NhsEmployee nhsModel)
        {
            try
            {
                for (int i = 0; i < nhsListEmployees.Count; i++)
                {
                    if (nhsListEmployees[i].NhsId == id)
                    {
                        nhsListEmployees.RemoveAt(i);
                        break;
                    }
                }
                return RedirectToAction(nameof(NhsIndex));
            }
            catch
            {
                return View(nhsModel);
            }
        }
    }
}
