using Invenio.Data.Models;

namespace Invenio.Web.Helper
{
    public static class PositionEnumDisplay
    {
        public static string GetEnumAsAString(string position)
        {
            switch (position)
            {
                case "GeneralManager":
                    return "General Manager";
                case "RegionalManager":
                    return "Regional Manager";
                case "ProductionCordinator":
                    return "Production Cordinator";
                case "TeamLeader":
                    return "Team Leader";
                default:
                    return "Customer";
            }
        }
    }
}
