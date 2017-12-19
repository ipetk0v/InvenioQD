using Invenio.Data.Models;

namespace Invenio.Web.Helper
{
    public static class PositionEnumDisplay
    {
        public static string GetEnumAsAString(PositionType position)
        {
            switch (position)
            {
                case PositionType.GeneralManager:
                    return "General Manager";
                case PositionType.RegionalManager:
                    return "Regional Manager";
                case PositionType.ProductionCordinator:
                    return "Production Cordinator";
                case PositionType.TeamLeader:
                    return "Team Leader";
                default:
                    return "Customer";
            }
        }
    }
}
