



$(document).ready(function () {

    
    

    // Login button in HomePage
    //$("#Login").click(function () {
    //    debugger;
    //    $("#Login").attr("href", "/Home/Home/Login");

    //});


    //$("#AddLabour").click(function (id) {
    //    //var url = "/Labour_Wages/Labour/Add_Labour/" + id;
    //    //window.location = url;
    //    debugger
    //    window.location = '@Url.Action("Add_Labour", "Labour", new { @id = TempData["ID"] })';

    //});





    // New button in FirstPage
    $(".NewProject").click(function () {

        $(".NewProject").attr("href", "/Admin_Page/Admin/Create_Project");

    });

    // Continue button in FirstPage
    $(".ContProject").click(function () {

        $(".ContProject").attr("href", "/Admin_Page/Admin/ChoseProject");

    });


    // Home Page In Admin
    //$("#HomeAdmin").click(function () {

    //    $("#HomeAdmin").attr("href", "/Admin_Page/Admin/Admin_Home");
    //});

    // AddLabour Page In Labour_Wages
    //$("#AddLabour").click(function () {

    //    $("#AddLabour").attr("href", "/Labour_Wages/Labour/Add_Labour");

    //});


    // LabourDetails Page In Labour_Wages
    //$("#LabourDeta").click(function () {

    //    $("#LabourDeta").attr("href", "/Labour_Wages/Labour/Labour_Details");

    //});

    // AddMaterial Page In Material_Expenses
    //$("#AddMaterial").click(function () {

    //    $("#AddMaterial").attr("href", "/Material_Expenses/Material/Add_Material");

    //});

    // MaterialDetails Page In Material_Expenses
    //$("#MaterialDeta").click(function () {

    //    $("#MaterialDeta").attr("href", "/Material_Expenses/Material/Meterial_Details");

    //});





    //$("#Logout").click(function () {

    //    $("#Logout").addClass("active");
    //    window.location = '@Url.Action("Home", "Home", new { area = "Home"})';

    //    alert("God Bye :)");
    //});


    

});




