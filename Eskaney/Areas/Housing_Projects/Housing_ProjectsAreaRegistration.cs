using System.Web.Mvc;
using System.Web.Routing;

namespace Eskaney.Areas.Housing_Projects
{
    public class Housing_ProjectsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Housing_Projects";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
             
            //context.MapRoute(
            //    "Housing_Projects_default",
            //    "Housing_Projects/{controller}/{action}/{id}",
            //    new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            //);


            /************************************************************/

            context.MapRoute(
                name: "aaHousing_Projects_default",
                url: "Housings",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Housings",
                    action = "Chose_Project"
                }
            );

            context.MapRoute(
                name: "Home_Page_default",
                url: "hHome",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Housings",
                    action = "Home_Page",
                }
            );

            //context.MapRoute(
            //    "Info_default",
            //    "Housing_Projects/Hou/{action}/{id}",        1000 %
            //    new { controller = "Housings", action = "Home", id = UrlParameter.Optional }
            //);


            context.MapRoute(
                "Info_default",
                //"hInfo/{action}/{id}",
                "{action}/_/{id}",
                new { controller = "Housings", action = "Housing_Info", id = UrlParameter.Optional }
            );


            context.MapRoute(
                name: "CInfo_default",
                url: "hCInfo",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Housings",
                    action = "Costs_Info",
                }
            );

            context.MapRoute(
                name: "Create_default",
                url: "hCreate",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Housings",
                    action = "Create",
                }
            );

            context.MapRoute(
                name: "Edit_default",
                url: "hEdit",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Housings",
                    action = "Edit",
                }
            );


            context.MapRoute(
                name: "Delete_default",
                url: "hDelete",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Housings",
                    action = "Delete",
                }
            );

            /****************************** ManPower ******************************/

            context.MapRoute(
                name: "Add_ManPower_default",
                url: "hAddMan",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "ManPower",
                    action = "Add_ManPower",
                }
            );

            context.MapRoute(
                name: "DetailsM_default",
                url: "hDetailsM",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "ManPower",
                    action = "ManPower_Details",
                }
            );

            context.MapRoute(
                name: "EditM_default",
                url: "hEditM",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "ManPower",
                    action = "Edit",
                }
            );

            context.MapRoute(
                name: "DeleteM_default",
                url: "hDeleteM",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "ManPower",
                    action = "Delete",
                }
            );


            /***************************  Material *********************************/

            context.MapRoute(
                name: "Add_Material_default",
                url: "hAddMt",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Material",
                    action = "Add_Material",
                }
            );

            context.MapRoute(
                name: "DetailsMt_default",
                url: "hDetailsMt",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Material",
                    action = "Material_Details",
                }
            );

            context.MapRoute(
                name: "EditMt_default",
                url: "hEditMt",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Material",
                    action = "Edit",
                }
            );

            context.MapRoute(
                name: "DeleteMt_default",
                url: "hDeleteMt",
                defaults:
                new
                {
                    area = "Housing_Projects",
                    controller = "Material",
                    action = "Delete",
                }
            );
        }

    }
}