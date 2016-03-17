Follow these instructions:

*Always use the filters to restrict your content to the particular user. ( Ex: AdminFilter = Add this to a class and it will only allow an admin 
to call the methods in the class )
*Use Authorize filter for every class which only a logged user can access.
*Before you start designing go to shared folder in views and there you will find a partial views for each role in the system.
 Like this => _ManagerNavigation.cshtml , _AdminNavigation.cshtml etc.
It will be your partial view for the particular user. Whatever the changes you want to do to the navigation bar, do the changes in this partial view.

*Use this code snippet to every new view you create. [ this is how you can render a partial view on your view. => @Html.Partial("_ManagerNavigation", Model); ]


@model templateProj.Models.UserModel
@{
    Layout = null;
    string ProPicPath = Model.ProfilePic;
    string Uname = Model.Username;
}

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Project base | Starter</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="../../Styles/bootstrap/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../../Styles/dist/css/AdminLTE.min.css">
    <!-- AdminLTE Skins. We have chosen the skin-blue for this starter
          page. However, you can choose any other skin. Make sure you
          apply the skin class to the body tag so the changes take effect.
    -->
    <link rel="stylesheet" href="../../Styles/dist/css/skins/skin-blue.min.css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
        <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<!--
BODY TAG OPTIONS:
=================
Apply one or more of the following classes to get the
desired effect
|---------------------------------------------------------|
| SKINS         | skin-blue                               |
|               | skin-black                              |
|               | skin-purple                             |
|               | skin-yellow                             |
|               | skin-red                                |
|               | skin-green                              |
|---------------------------------------------------------|
|LAYOUT OPTIONS | fixed                                   |
|               | layout-boxed                            |
|               | layout-top-nav                          |
|               | sidebar-collapse                        |
|               | sidebar-mini                            |
|---------------------------------------------------------|
-->
<body class="hold-transition skin-blue sidebar-mini">
    <div class="wrapper">
        <!-- Rendering the partial view for the navigation bar-->
    @Html.Partial("_ManagerNavigation", Model); 

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>
                    Dashboard
                    <small></small>
                </h1>
            </section>
            <ol class="breadcrumb" style="left:100px ; top:50px">
                <li><a href="@Url.Action("Home", "Home" )"><i class="fa fa-dashboard"></i> Home</a></li>
                <li class="active">Dashboard</li>
            </ol>
            <!-- Main content -->
            <section class="content">

                <!-- Your Page Content Here -->
            </section><!-- /.content -->
        </div><!-- /.content-wrapper -->

        <!--Rendering the partial view for the footer-->
        @Html.Partial("_ManagerFooter");

    </div><!-- ./wrapper -->
    <!-- REQUIRED JS SCRIPTS -->
    <!-- jQuery 2.1.4 -->
    <script src="../../Styles/plugins/jQuery/jQuery-2.1.4.min.js"></script>
    <!-- Bootstrap 3.3.5 -->
    <script src="../../Styles/bootstrap/js/bootstrap.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../../Styles/dist/js/app.min.js"></script>
    <!-- Optionally, you can add Slimscroll and FastClick plugins.
         Both of these plugins are recommended to enhance the
         user experience. Slimscroll is required when using the
         fixed layout. -->
</body>
</html>

*you may change the model you are passing to the view to your needs. [ @model templateProj.Models.UserModel ]
*if you want to pass a different model from UserModel, please use a view-model and include the UserModel there as well. Coz the profile pic and stuff are from 
that model.
*And ALWAYS use strongly typed views. ALWAYS !! AND DONT AUTOGEN CODES !! 


IMPORTANT !!!!!

*There will be only one home page for the whole system even tho there are several dashboards for different users. use a partial view for the dashboard content 
like shown in the image ive attached here [ Home View breakdown.jpg ]. And according to the user role correct dashboard partial view will be rendered.

to get an idea => 

 if( userRole == "Developer")
 {
	@Html.Partial("_DeveloperDashboard", Model); 
 }
else if (userRole == "ScrumMaster")
{
	@Html.Partial("_ScrumMasterDashboard", Model);
}

******Becoz of this mechanism the complexity of the HomeController might be high..so be careful when u change something in that controller.
And Since we all gonna use the same view we will defa need to use a view-model here..U'll find it in the Models folder in the name of HomeViewModel.cs,
 put all ur other model references there which u need for the dashboard u are working on.


Login credentials

Uname   		pw

* devni			1234   
* nad			""
* ruk			""