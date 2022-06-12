using Microsoft.AspNetCore.Mvc;
using System;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : Controller
    {
        private IUserService _userService;
        private IAccountService _accountService;
        private IFamilyPlanService _familyPlanService;
        private IFamilyService _familyService;
        private ITrackerService _trackerService;
        private IConnectionService _connectionService;

        public DemoController(IUserService userService, IAccountService accountService,
            IFamilyPlanService familyPlanService, IFamilyService familyService,
            ITrackerService trackerService, IConnectionService connectionService) 
        {
            _userService = userService;
            _accountService = accountService;
            _familyPlanService = familyPlanService;
            _familyService = familyService;
            _trackerService = trackerService;
            _connectionService = connectionService;
        }

        [HttpGet("PrepareData")]
        public IActionResult PrepareData() 
        {
            //Family Plan
            FamilyPlan familyPlan = new FamilyPlan() 
            {
                Discount = 20,
                MaxMemberNumber = 2,
                Name = "StubPlan_Discount20_maxMembers2"
            };
            familyPlan = _familyPlanService.AddNewFamilyPlan(familyPlan);

            //Families
            Family familyWithPlan = new Family()
            {
                FamilyPlanId = familyPlan.Id,
                Name = "Family_With_familyPlan"
            };
            Family familyWithoutPlan = new Family()
            {
                Name = "Family_Without_Plan"
            };
            familyWithPlan = _familyService.AddNewFamily(familyWithPlan);
            familyWithoutPlan = _familyService.AddNewFamily(familyWithoutPlan);

            //Users
            User stubUser = new User()
            {
                BirthDate = DateTime.Now,
                CountryId = Guid.Parse("e9e36907-16bd-4be9-8f02-076c4427c8e9"),
                FullName = "Stub User",
                Gender = "Male",
                PhoneNumber = "+380-00-000-00-0000"
            };

            var stubUser1 = _userService.AddNewUser(stubUser);
            var stubUser2 = _userService.AddNewUser(stubUser);
            var stubUser3 = _userService.AddNewUser(stubUser);
            var stubUser4 = _userService.AddNewUser(stubUser);

            //Accounts
            Account stubAccountWithFamilyplan1 = new Account()
            {
                BillAmount = 150,
                Email = "test@gmail.com",
                UserId = stubUser1.Id,
                FamilyId = familyWithPlan.Id
            }; 
            Account stubAccountWithFamilyplan2 = new Account()
            {
                BillAmount = 100,
                Email = "test@gmail.com",
                UserId = stubUser2.Id,
                FamilyId = familyWithPlan.Id
            };
            Account stubAccountWithFamily1 = new Account()
            {
                BillAmount = 150,
                Email = "test@gmail.com",
                UserId = stubUser3.Id,
                FamilyId = familyWithoutPlan.Id
            };
            Account stubAccountWithFamily2 = new Account()
            {
                BillAmount = 100,
                Email = "test@gmail.com",
                UserId = stubUser4.Id,
                FamilyId = familyWithoutPlan.Id
            };
            stubAccountWithFamilyplan1 = _accountService.AddNewAccount(stubAccountWithFamilyplan1);
            stubAccountWithFamilyplan2 = _accountService.AddNewAccount(stubAccountWithFamilyplan2);
            stubAccountWithFamily1 = _accountService.AddNewAccount(stubAccountWithFamily1);
            stubAccountWithFamily2 = _accountService.AddNewAccount(stubAccountWithFamily2);

            //Trackers
            var stubtracker = new Tracker() 
            {
                ExperationDate = DateTime.Now.AddYears(5),
                IP = "stubIP",
                IsOn = true,
                LastCoordinates = "StubCoordinates",
                SerialNumber = "StubSerialNUmber",
                Mac = "StubMac",
                Name = "trackerForDemo"
            };
            stubtracker = _trackerService.AddNewTracker(stubtracker);

            //Connections
            var ConnectionForFamilyWithPlan = new Connection() 
            {
                FamilyId = familyWithPlan.Id,
                ConnectionType = "StubType",
                Name = "Connection_for_family_with_plan",
                Price = 100,
                TrackerId = stubtracker.Id,
            };

            var ConnectionForFamilyWithoutPlan = new Connection()
            {
                FamilyId = familyWithoutPlan.Id,
                ConnectionType = "StubType",
                Name = "Connection_for_family_without_plan",
                Price = 100,
                TrackerId = stubtracker.Id,
            };

            var ConnectionForAccount = new Connection()
            {
                AccountId = stubAccountWithFamilyplan2.Id,
                ConnectionType = "StubType",
                Name = "Connection_for_Account",
                Price = 50,
                TrackerId = stubtracker.Id,
            };

            ConnectionForAccount = _connectionService.AddNewConnection(ConnectionForAccount);
            ConnectionForFamilyWithPlan = _connectionService.AddNewConnection(ConnectionForFamilyWithPlan);
            ConnectionForFamilyWithoutPlan = _connectionService.AddNewConnection(ConnectionForFamilyWithoutPlan);

            var result = $"User ids: {stubUser1.Id}, {stubUser2.Id}, {stubUser3.Id}, {stubUser4.Id};"
                + $"\n Account With Family plan ids: {stubAccountWithFamilyplan1.Id}, {stubAccountWithFamilyplan2.Id}"
                + $"\n Account Without Family plan ids: {stubAccountWithFamily1.Id}, {stubAccountWithFamily2.Id}"
                + $"\n Tracker Id: {stubtracker.Id}"
                + $"\n Connections ids: {ConnectionForFamilyWithPlan.Id}, {ConnectionForFamilyWithoutPlan.Id}, {ConnectionForAccount.Id}";

            return Ok(result);

        }
    }
}
