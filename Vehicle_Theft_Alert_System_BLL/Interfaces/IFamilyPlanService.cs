using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface IFamilyPlanService
    {
        IEnumerable<FamilyPlan> GetAllFamilyPlans();
        FamilyPlan AddNewFamilyPlan(FamilyPlan familyPlan);
        void DeleteFamilyPlan(Guid id);
        FamilyPlan UpdateFamilyPlan(FamilyPlan updatedFamilyPlan);
        FamilyPlan GetFamilyPlanById(Guid id);
    }
}
