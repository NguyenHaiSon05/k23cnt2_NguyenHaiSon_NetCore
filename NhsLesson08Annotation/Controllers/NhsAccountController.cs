using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NhsLesson08Annotation.Models;


namespace NhsLesson08Annotation.Controllers
{
    public class NhsAccountController : Controller
    {
        private static List<NhsAccount> nhsListAccount = new List<NhsAccount>()
        {
            new NhsAccount
            {
                NhsId = 23109000,
                NhsFullName = "Nguyễn Hải Sơn",
                NhsEmail = "sonnguyennr111@gmail.com",
                NhsPhone = "0388604819",
                NhsAddress = "Lớp K23CNT2",
                NhsAvatar = "haison.jpg",
                NhsBirthday = new DateTime(2005, 5, 30),
                NhsGender = "Nam",
                NhsPassword = "0978611889",
                NhsFacebook = "https://www.facebook.com/nguyen.hai.son.871540/"
            },
            new NhsAccount
            {
                NhsId = 2,
                NhsFullName = "Trần Thị B",
                NhsEmail = "tranthib@example.com",
                NhsPhone = "0987654321",
                NhsAddress = "456 Đường B, Quận 3, TP.HCM",
                NhsAvatar = "avatar2.jpg",
                NhsBirthday = new DateTime(1992, 8, 15),
                NhsGender = "Nữ",
                NhsPassword = "password2",
                NhsFacebook = "https://facebook.com/tranthib"
            }
            // Thêm nhiều bản ghi khác nếu cần
        };

        // GET: NhsAccountController
        public ActionResult NhsIndex()
        {
            return View(nhsListAccount);
        }

        // GET: NhsAccountController/NhsDetails/5
        public ActionResult NhsDetails(int id)
        {
            var nhs = nhsListAccount.FirstOrDefault(x => x.NhsId == id);
            return nhs != null ? View(nhs) : NotFound();
        }

        // GET: NhsAccountController/NhsCreate
        public ActionResult NhsCreate()
        {
            var nhsModel = new NhsAccount();
            return View(nhsModel);
        }

        // POST: NhsAccountController/NhsCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhsCreate(NhsAccount nhsModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nhsListAccount.Add(nhsModel);
                    return RedirectToAction(nameof(NhsIndex));
                }
                return View(nhsModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm mới: " + ex.Message);
                return View(nhsModel);
            }
        }

        // GET: NhsAccountController/Edit/5
        public ActionResult NhsEdit(int id)
        {
            var nhs = nhsListAccount.FirstOrDefault(x => x.NhsId == id);
            return nhs != null ? View(nhs) : NotFound();
        }

        // POST: NhsAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhsEdit(int id, NhsAccount updatedNhs)
        {
            try
            {
                var nhs = nhsListAccount.FirstOrDefault(x => x.NhsId == id);
                if (nhs == null) return NotFound();

                // Cập nhật thông tin
                nhs.NhsFullName = updatedNhs.NhsFullName;
                nhs.NhsEmail = updatedNhs.NhsEmail;
                nhs.NhsPhone = updatedNhs.NhsPhone;
                nhs.NhsAddress = updatedNhs.NhsAddress;
                nhs.NhsAvatar = updatedNhs.NhsAvatar;
                nhs.NhsBirthday = updatedNhs.NhsBirthday;
                nhs.NhsGender = updatedNhs.NhsGender;
                nhs.NhsPassword = updatedNhs.NhsPassword;
                nhs.NhsFacebook = updatedNhs.NhsFacebook;

                return RedirectToAction(nameof(NhsIndex));
            }
            catch
            {
                return View(updatedNhs);
            }
        }

        // GET: NhsAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var nhs = nhsListAccount.FirstOrDefault(x => x.NhsId == id);
            return nhs != null ? View(nhs) : NotFound();
        }

        // POST: NhsAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var nhs = nhsListAccount.FirstOrDefault(x => x.NhsId == id);
                if (nhs != null)
                {
                    nhsListAccount.Remove(nhs);
                }
                return RedirectToAction(nameof(NhsIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
