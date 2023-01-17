using System.CodeDom;

namespace Remoting_Wizard.Class
{
    public class PC
    {
        /// <summary>
        /// Remote PC's Details
        /// </summary>
        public string Alias { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public PC(string _alias, string _name, string _userID)
        {
            Alias = _alias;
            Name = _name;
            UserID = _userID;
        }
        public PC()
        {

        }
    }
}
