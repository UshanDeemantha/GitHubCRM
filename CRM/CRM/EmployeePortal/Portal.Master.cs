using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Common.BL;
namespace HRM.EmployeePortal
{
    public partial class Portal : System.Web.UI.MasterPage
    {

        User users = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // lbu.Text = Session["UserName"].ToString();
                if (!IsPostBack)
                {
                    GetMenu();
                } 
            }
 
        }
        private void GetMenu()
        {

            try
            {
                // image.Src=
                //SubMenu
               var UserType = Session["UserType"];
               var UserId = Session["UserId"];
               var LocationId = Session["LocationId"];
             
                //lbUser.Text = user.UserName;

                //  lbu.Text = user.UserName;
                lbu.Text = "Log Out";
                var maimneu = users.GetMainMenu();
                var hlmlelemnt = "";
                var iclass = "";
                foreach (DataRow row in maimneu.Tables[0].Rows)
                {
                    var dsMenu = users.GetMenubyUser(Convert.ToInt32(UserType),Convert.ToInt32(UserId),Convert.ToInt32(LocationId), row["MenuCode"].ToString()).Tables[0];

                    if (dsMenu.Rows.Count > 0)
                    {


                        if (row["MenuCode"].ToString().Equals("M"))
                          
                            hlmlelemnt = "<li class=\"header\">MAIN NAVIGATION </li> "+
                                  "<li class=\"active\" >"+
                                  "<ul class=\"treeview-menu\">";
                         
                        else if (row["MenuCode"].ToString().Equals("A"))

                        hlmlelemnt = "<li class=\"header\">ADMINISTRATION</li> " +
                                 "<li class=\"active\" >" +
                                 "<ul class=\"treeview-menu\">";
                       


                        var pagepath = "";


                        foreach (DataRow mnrow in dsMenu.Rows)
                        {
                            if (mnrow["FormID"].ToString().Equals("7"))
                                iclass = "fa fa-tasks";
                            else if (mnrow["FormID"].ToString().Equals("8"))
                                iclass = "fa fa-pencil-square-o";
                            else if (mnrow["FormID"].ToString().Equals("9"))
                                iclass = "fa fa-random";
                            else if (mnrow["FormID"].ToString().Equals("10"))
                                iclass = "fa fa-address-book-o";
                            else if (mnrow["FormID"].ToString().Equals("11"))
                                iclass = "fa fa-bank";
                            else if (mnrow["FormID"].ToString().Equals("12"))
                                iclass = "fa fa-briefcase";
                            else if (mnrow["FormID"].ToString().Equals("13"))
                                iclass = "fa fa-users";
                            else if (mnrow["FormID"].ToString().Equals("14"))
                                iclass = "fa fa-share-square-o";                            
                            else if (mnrow["FormID"].ToString().Equals("15"))
                                iclass = "fa fa-list-ul";
                            else if (mnrow["FormID"].ToString().Equals("16"))
                                iclass = "fa fa-history";
                            else if (mnrow["FormID"].ToString().Equals("17"))
                                iclass = "fa fa-handshake-o";
                            else if (mnrow["FormID"].ToString().Equals("18"))
                                iclass = "fa fa-check-square-o";
                            else if (mnrow["FormID"].ToString().Equals("1007"))
                                iclass = "fa fa-cart-plus";
                            else if (mnrow["FormID"].ToString().Equals("2006"))
                                iclass = "fa fa-drivers-license-o";
                            else if (mnrow["FormID"].ToString().Equals("2007"))
                                iclass = "fa fa-user-plus";
                            else if (mnrow["FormID"].ToString().Equals("4007"))
                                iclass = "fa fa-cogs";
                            else if (mnrow["FormID"].ToString().Equals("6007"))
                                iclass = "fa fa-retweet";
                            else if (mnrow["FormID"].ToString().Equals("6008"))
                                iclass = "fa fa-random";

                            if (mnrow["Module"].ToString().Equals("ControlUI"))
                            {
                                hlmlelemnt +=
                                    " <li><a href=\"" + "ControlUI/" + mnrow["PagePath"] + "\"><i class=\" " + iclass + "\"></i>" +
                                    mnrow["PageName"] + "</a></li>";

                            }
                            else
                            {
                                hlmlelemnt +=
                                    " <li><a href=\"" + mnrow["PagePath"] + "\"><i class=\" " + iclass + "\"></i>" +
                                    mnrow["PageName"] + "</a></li>";

                            }
                        }

                        hlmlelemnt = hlmlelemnt + " </ul></li> ";
                        ltString.Text += hlmlelemnt;

                    }

                }



            }
            catch (Exception ex)
            {


            }

        } 

    }
}