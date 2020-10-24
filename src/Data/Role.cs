namespace GoldenTicket.Data
{
    /// <summary>
    /// Constant variables for data use.
    /// </summary>
    public static class Role
    {
        /// <summary>
        /// The employee role
        /// </summary>
        public const string Employee = "Employee";
        /// <summary>
        /// The finance officer role
        /// </summary>
        public const string FinanceOfficer = "FinanceOfficer";
        /// <summary>
        /// The secretary of chair role
        /// </summary>
        public const string SecretaryOfChair = "SecreteryOfChair";
        /// <summary>
        /// The scientific teaching council role
        /// </summary>
        public const string SecretaryOfScientificTeachingCouncil = "SecretaryOfScientificTeachingCouncil";
        /// <summary>
        /// The head accountant role
        /// </summary>
        public const string HeadAccountant = "HeadAccountant";
        /// <summary>
        /// The vice dean for finance role
        /// </summary>
        public const string ViceDeanForFinance = "ViceDeanForFinance";
        /// <summary>
        /// The role of administrator.
        /// </summary>
        public const string Administrator = "Admin";
        /// <summary>
        /// All
        /// </summary>
        public static string[] AllRoles = { Employee, FinanceOfficer, SecretaryOfChair, SecretaryOfScientificTeachingCouncil, HeadAccountant, ViceDeanForFinance, Administrator };
    }
}