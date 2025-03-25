using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using System.Linq;

namespace MyMvcApp.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(userlist); // Return a view with the user list
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id); // Assuming User has an Id property
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }
            return View(user); // Return the user details view
}

        // GET: User/Create
        public ActionResult Create()
        {
            return View(); // Return the Create view
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (user != null)
            {
                userlist.Add(user); // Add the user to the list
                return RedirectToAction("Index"); // Redirect to the Index action
            }
            return View(user); // Return the Create view with the user model for validation errors
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id); // Retrieve the user by ID
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }
            return View(user); // Return the Edit view with the user model
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            if (ModelState.IsValid)
            {
                existingUser.Name = user.Name; // Update user properties (example: Name)
                existingUser.Email = user.Email; // Update user properties (example: Email)
                return RedirectToAction("Index"); // Redirect to the Index action
            }

            return View(user); // Return the Edit view with the user model for validation errors
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }
            return View(user); // Return the Delete confirmation view with the user model
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            userlist.Remove(user); // Remove the user from the list
            return RedirectToAction("Index"); // Redirect to the Index action
        }
    
    public ActionResult Search(string name)
{
    if (string.IsNullOrEmpty(name))
    {
        return View("Index", userlist); // Si no hay nombre, devuelve la lista completa
    }

    var filteredUsers = userlist.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    return View("Index", filteredUsers); // Devuelve la vista Index con los usuarios filtrados
}        

}
}
