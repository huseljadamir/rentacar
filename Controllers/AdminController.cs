using LMXRentACar.Models;
using LMXRentACar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LMXRentACar.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin
        
        public ActionResult Index()
        {
            var pendingRequests = _context.Requests.ToList();
            var vehicles = _context.Vehicles.ToList();

            List<AdminPanelRequestModel> models = new List<AdminPanelRequestModel>();


            foreach (var request in pendingRequests)
            {

                if (request.IsValid == false)
                {
                    models.Add(new AdminPanelRequestModel {
                        request = request,
                        vehicle = _context.Vehicles.Single(c => c.Id == request.VehicleId)
                    });
                }
                
            }
            return View(models);
        }

        public ActionResult Delete(int id)
        {
            Request theRequest = _context.Requests.Single(r => r.Id == id);

            AdminPanelRequestModel model = new AdminPanelRequestModel()
            {
                request = theRequest,
                vehicle = _context.Vehicles.Single(r => r.Id == theRequest.VehicleId)

            };

            return View(model);
        }

        public ActionResult RemoveRequest(int id)
        {
            Request theRequest = _context.Requests.Single(r => r.Id == id);
            _context.Requests.Remove(theRequest);
            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Confirm(int id)
        {

            Request theRequest = _context.Requests.Single(r => r.Id == id);
            Vehicle theVehicle = _context.Vehicles.Single(r => r.Id == theRequest.VehicleId);
            List<Request> theRequests = new List<Request>();
            List<Request> allRequests = _context.Requests.ToList();

            foreach (var req in allRequests)
            {
                if (req.VehicleId == theRequest.VehicleId && req.IsValid == false && req.Id != theRequest.Id) theRequests.Add(req);
            }

            ConfirmRequestModel model = new ConfirmRequestModel()
            {
                request = theRequest,
                vehicle = theVehicle,
                otherRequests = theRequests
            };

            return View(model);
        }

        public ActionResult ConfirmRequest(int id)
        {
            Request theRequest = _context.Requests.Single(r => r.Id == id);
            List<Request> allRequests = _context.Requests.ToList();
            foreach(var curr_request in allRequests)
            {
                if ((curr_request.VehicleId == theRequest.VehicleId) && (curr_request.IsValid == true) && 
                    ((theRequest.StartDate >= curr_request.StartDate && theRequest.StartDate <= curr_request.EndDate) 
                    || (theRequest.StartDate <= curr_request.StartDate && theRequest.EndDate >= curr_request.StartDate) 
                    || (theRequest.EndDate >= curr_request.StartDate && theRequest.EndDate <= curr_request.EndDate) 
                    || ((theRequest.StartDate>=curr_request.StartDate && theRequest.StartDate<=curr_request.EndDate) 
                    &&(theRequest.EndDate>=curr_request.StartDate && theRequest.EndDate<=curr_request.EndDate))))
                    return View("NotRentable");
            }

            theRequest.IsValid = true;
            _context.SaveChanges();

            return View("RequestSuccesful");
        }
    }
}